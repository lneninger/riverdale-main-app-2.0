import { Component, OnDestroy, OnInit, ViewEncapsulation, Input } from '@angular/core';
import { FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, takeUntil } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseSidebarService } from '@fuse/components/sidebar/sidebar.service';

import { Todo } from './saleopportunity.view.model';
import { SaleOpportunity, ProductGrid, SaleOpportunityItem } from '../saleopportunity.model';
import { SaleOpportunityViewService } from './saleopportunity.view.service';
import { ISelectedFile } from '../../@hipalanetCommons/fileupload/fileupload.model';
import { SaleOpportunityService } from '../saleopportunity.core.module';

@Component({
    selector: 'saleopportunity-view',
    templateUrl: './saleopportunity.view.component.html',
    styleUrls: ['./saleopportunity.view.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations   : fuseAnimations
})
export class SaleOpportunityViewComponent implements OnInit, OnDestroy
{
    private _currentEntity: SaleOpportunity;

    get currentEntity() {
        return this._currentEntity;
    }

    @Input('entity')
    set currentEntity(value: any) {
        if (this._currentEntity != value) {
            this._currentEntity = new SaleOpportunity(value);
            this.products = this._currentEntity.relatedProducts;
            this.frmMain = this.createFormBasicInfo();
        }
        else {
            this.products = null;
        }
    }

    products: (ProductGrid | ISelectedFile)[];

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
        private route: ActivatedRoute
        , private _fuseSidebarService: FuseSidebarService
        , private _todoService: SaleOpportunityViewService
        , private _formBuilder: FormBuilder
        , private saleOpportunityService: SaleOpportunityService
    )
    {
        // Set the defaults
        this.searchInput = new FormControl('');

        // Set the private defaults
        this._unsubscribeAll = new Subject();

        this.saleOpportunityService.onSaleOpportunityItemAdded.subscribe(this.onSaleOpportunityItemAdded.bind(this));
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void
    {
        //debugger;
        this.currentEntity = this.saleOpportunityService.currentEntity.bag;

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


    onSaleOpportunityItemAdded(item: SaleOpportunityItem) {
        debugger;
        this.currentEntity.relatedProducts.push(item);
    }
}
