import { Component, OnDestroy, OnInit, ViewEncapsulation, Input } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs';

import { fuseAnimations } from '@fuse/animations';

import { Todo } from '../saleopportunity.view.model';
import { SaleOpportunityViewService } from '../saleopportunity.view.service';
import { takeUntil } from 'rxjs/operators';
import { SaleOpportunity, ProductGrid } from '../../saleopportunity.model';

@Component({
    selector: 'saleopportunity-view-list',
    templateUrl: './saleopportunity.view-list.component.html',
    styleUrls: ['./saleopportunity.view-list.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations   : fuseAnimations
})
export class SaleOpportunityViewListComponent implements OnInit, OnDestroy
{
    private _currentEntity: SaleOpportunity;

    get currentEntity() {
        return this._currentEntity;
    }

    @Input('entity')
    set currentEntity(value: SaleOpportunity) {
        this._currentEntity = value;
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
        private _location: Location
    )
    {
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
    readTodo(todoId): void
    {
        // Set current todo
        this._todoService.setCurrentTodo(todoId);
    }

    /**
     * On drop
     *
     * @param ev
     */
    onDrop(ev): void
    {

    }
}
