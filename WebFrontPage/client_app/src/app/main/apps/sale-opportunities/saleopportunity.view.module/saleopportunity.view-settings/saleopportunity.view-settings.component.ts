import { Component, OnDestroy, OnInit, ViewEncapsulation, Input } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs';

import { fuseAnimations } from '@fuse/animations';

import { Todo } from '../saleopportunity.view.model';
import { SaleOpportunityViewService } from '../saleopportunity.view.service';
import { takeUntil } from 'rxjs/operators';
import { SaleOpportunity, ProductGrid } from '../../saleopportunity.model';
import { EnumItem } from 'app/main/apps/@resolveServices/resolve.model';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CustomValidators } from 'ng4-validators';

@Component({
    selector: 'saleopportunity-view-settings',
    templateUrl: './saleopportunity.view-settings.component.html',
    styleUrls: ['./saleopportunity.view-settings.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations   : fuseAnimations
})
export class SaleOpportunityViewSettingsComponent implements OnInit, OnDestroy
{
    private _currentEntity: SaleOpportunity;
    listGrowerType: EnumItem<string>[];
    selectedGrowerType: EnumItem<string>;
    frmMain: FormGroup;
    get selectedGrowers() {
        if (this.selectedGrowerType != null) {
            return this.selectedGrowerType.extras['growers'];
        }
        else {
            return null;
        }
    }

    get currentEntity() {
        return this._currentEntity;
    }

    @Input('entity')
    set currentEntity(value: SaleOpportunity) {
        this._currentEntity = value;
    }

    createForm() {
        this.frmMain = this.formBuilder.group({
            'riverdaleMargin': ['', [CustomValidators.number]],
            'delivered': ['', []],
            'foc': ['', [CustomValidators.number]],
            'growerId': ['', [CustomValidators.number]],
        });
    }


    todos: Todo[];
    currentTodo: Todo;

    // Private
    private _unsubscribeAll: Subject<any>;

    /**
     * Constructor
     *
     * @param {ActivatedRoute} _activatedRoute
     * @param {TodoService} _todoService
     * @param {Location} _location
     */
    constructor(
        private _activatedRoute: ActivatedRoute,
        private _todoService: SaleOpportunityViewService,
        private _location: Location,
        private formBuilder: FormBuilder
    )
    {
        //debugger;
        this.listGrowerType = this._activatedRoute.snapshot.data.listGrowerType;
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
        // Subscribe to update todos on changes
        this._todoService.onTodosChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(todos => {
                this.todos = todos;
            });

        // Subscribe to update current todo on changes
        this._todoService.onCurrentTodoChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(currentTodo => {
                if ( !currentTodo )
                {
                    // Set the current todo id to null to deselect the current todo
                    this.currentTodo = null;

                    // Handle the location changes
                    const tagHandle    = this._activatedRoute.snapshot.params.tagHandle,
                          filterHandle = this._activatedRoute.snapshot.params.filterHandle;

                    if ( tagHandle )
                    {
                        this._location.go('apps/todo/tag/' + tagHandle);
                    }
                    else if ( filterHandle )
                    {
                        this._location.go('apps/todo/filter/' + filterHandle);
                    }
                    else
                    {
                        this._location.go('apps/todo/all');
                    }
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
     * Read todo
     *
     * @param todoId
     */
   

    /**
     * On drop
     *
     * @param ev
     */
    onDrop(ev): void
    {

    }
}
