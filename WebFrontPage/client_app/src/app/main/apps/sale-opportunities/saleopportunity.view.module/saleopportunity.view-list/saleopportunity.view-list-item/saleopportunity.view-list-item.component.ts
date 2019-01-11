import { Component, HostBinding, Input, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs';
import { Todo } from '../../saleopportunity.view.model';
import { SaleOpportunityViewService } from '../../saleopportunity.view.service';
import { takeUntil } from 'rxjs/operators';
import { SaleOpportunityItem } from '../../../saleopportunity.model';
import { FormArray, FormGroup } from '@angular/forms';

@Component({
    selector: 'saleopportunity-view-list-item',
    templateUrl: './saleopportunity.view-list-item.component.html',
    styleUrls: ['./saleopportunity.view-list-item.component.scss'],
    encapsulation: ViewEncapsulation.None
})
export class SaleOpportunityViewListItemComponent implements OnInit, OnDestroy
{
    tags: any[];

    @Input('entity')
    currentEntity: SaleOpportunityItem;

    @Input('formGroup')
    formGroup: FormGroup;

    @HostBinding('class.selected')
    selected: boolean;

    @HostBinding('class.completed')
    completed: boolean;

    @HostBinding('class.move-disabled')
    moveDisabled: boolean;

    // Private
    private _unsubscribeAll: Subject<any>;

    /**
     * Constructor
     *
     * @param {TodoService} _todoService
     * @param {ActivatedRoute} _activatedRoute
     */
    constructor(
        private _todoService: SaleOpportunityViewService,
        private _activatedRoute: ActivatedRoute
    )
    {
        // Disable move if path is not /all
        if ( _activatedRoute.snapshot.url[0].path !== 'all' )
        {
            this.moveDisabled = true;
        }

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
        // Set the initial values
        this.currentEntity = new SaleOpportunityItem(this.currentEntity);
        //this.completed = this.todo.completed;

        // Subscribe to update on selected todo change
        this._todoService.onSelectedTodosChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(selectedTodos => {
                this.selected = false;

                if ( selectedTodos.length > 0 )
                {
                    for ( const todo of selectedTodos )
                    {
                        if ( todo.id === this.currentEntity.id )
                        {
                            this.selected = true;
                            break;
                        }
                    }
                }
            });

        // Subscribe to update on tag change
        this._todoService.onTagsChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(tags => {
                this.tags = tags;
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
     * On selected change
     */
    onSelectedChange(): void
    {
        console.log(`Selected changed`, this.currentEntity, this.formGroup.value);
        //this._todoService.toggleSelectedTodo(this.currentEntity.id);
    }

    /**
     * Toggle star
     */
    toggleStar(event): void
    {
        event.stopPropagation();

        //this.todo.toggleStar();
        //this._todoService.updateTodo(this.todo);
    }

    /**
     * Toggle Important
     */
    toggleImportant(event): void
    {
        event.stopPropagation();

        //this.todo.toggleImportant();
        //this._todoService.updateTodo(this.todo);
    }

    /**
     * Toggle Completed
     */
    toggleCompleted(event): void
    {
        event.stopPropagation();

        //this.todo.toggleCompleted();
        //this._todoService.updateTodo(this.todo);
    }
}
