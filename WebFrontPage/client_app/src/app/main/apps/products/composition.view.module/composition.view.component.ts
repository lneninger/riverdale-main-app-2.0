import { Component, OnDestroy, OnInit, ViewEncapsulation, Input } from '@angular/core';
import { FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, takeUntil } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseSidebarService } from '@fuse/components/sidebar/sidebar.service';

import { Todo } from './composition.view.model';
import { Product, IProductMedia, ProductMediaGrid } from '../product.model';
import { CompositionViewService } from './composition.view.service';
import { ISelectedFile } from '../../@hipalanetCommons/fileupload/fileupload.model';

@Component({
    selector: 'composition-view',
    templateUrl: './composition.view.component.html',
    styleUrls: ['./composition.view.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations   : fuseAnimations
})
export class CompositionViewComponent implements OnInit, OnDestroy
{
    private _currentEntity: Product;

    get currentEntity() {
        return this._currentEntity;
    }

    @Input('entity')
    set currentEntity(value: Product) {
        this._currentEntity = value;
        if (this._currentEntity != null) {
            this.medias = (this._currentEntity.medias || []).map(item => new ProductMediaGrid(item));
            this.frmMain = this.createFormBasicInfo();
        }
        else {
            this.medias = null;
        }
    }

    medias: (ProductMediaGrid | ISelectedFile)[];

    frmMain: FormGroup;


    hasSelectedTodos: boolean;
    isIndeterminate: boolean;
    filters: any[];
    tags: any[];
    searchInput: FormControl;
    currentTodo: Todo;

    // Private
    private _unsubscribeAll: Subject<any>;

    /**
     * Constructor
     *
     * @param {FuseSidebarService} _fuseSidebarService
     * @param {TodoService} _todoService
     */
    constructor(
        private _fuseSidebarService: FuseSidebarService
        , private _todoService: CompositionViewService
        , private _formBuilder: FormBuilder
    )
    {
        // Set the defaults
        this.searchInput = new FormControl('');

        // Set the private defaults
        this._unsubscribeAll = new Subject();
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void
    {
        this._todoService.onSelectedTodosChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(selectedTodos => {

                if (selectedTodos && (this._todoService.todos && this._todoService.todos.length)) {
                    setTimeout(() => {
                        this.hasSelectedTodos = selectedTodos.length > 0;
                        this.isIndeterminate = (selectedTodos.length !== this._todoService.todos.length && selectedTodos.length > 0);
                    }, 0);
                }
            });

        this._todoService.onFiltersChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(folders => {
                this.filters = this._todoService.filters;
            });

        this._todoService.onTagsChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(tags => {
                this.tags = this._todoService.tags;
            });

        this.searchInput.valueChanges
            .pipe(
                takeUntil(this._unsubscribeAll),
                debounceTime(300),
                distinctUntilChanged()
            )
            .subscribe(searchText => {
                this._todoService.onSearchTextChanged.next(searchText);
            });

        this._todoService.onCurrentTodoChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(([currentTodo, formType]) => {
                if ( !currentTodo )
                {
                    this.currentTodo = null;
                }
                else
                {
                    this.currentTodo = currentTodo;
                }
            });
    }

    /**
     * On destroy
     */
    ngOnDestroy(): void
    {
        // Unsubscribe from all subscriptions
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------
    /**
     * Create product form
     *
     * @returns {FormGroup}
     */
    createFormBasicInfo(): FormGroup {
        //debugger;
        return this._formBuilder.group({
            id: [this.currentEntity.id],
            name: [this.currentEntity.name],
        });
    }


    /**
     * Deselect current todo
     */
    deselectCurrentTodo(): void
    {
        this._todoService.onCurrentTodoChanged.next([null, null]);
    }

    /**
     * Toggle select all
     */
    toggleSelectAll(): void
    {
        this._todoService.toggleSelectAll();
    }

    /**
     * Select todos
     *
     * @param filterParameter
     * @param filterValue
     */
    selectTodos(filterParameter?, filterValue?): void
    {
        this._todoService.selectTodos(filterParameter, filterValue);
    }

    /**
     * Deselect todos
     */
    deselectTodos(): void
    {
        this._todoService.deselectTodos();
    }

    /**
     * Toggle tag on selected todos
     *
     * @param tagId
     */
    toggleTagOnSelectedTodos(tagId): void
    {
        this._todoService.toggleTagOnSelectedTodos(tagId);
    }

    /**
     * Toggle the sidebar
     *
     * @param name
     */
    toggleSidebar(name): void
    {
        this._fuseSidebarService.getSidebar(name).toggleOpen();
    }
}
