import { Component, OnDestroy, OnInit, ViewEncapsulation, Input } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { Subject, Subscription } from 'rxjs';

import { fuseAnimations } from '@fuse/animations';

import { Todo } from '../saleopportunity.view.model';
import { SaleOpportunityViewService } from '../saleopportunity.view.service';
import { takeUntil } from 'rxjs/operators';
import { SaleOpportunity, ProductGrid, SampleBoxItem, SampleBoxProductItem } from '../../saleopportunity.model';
import { Form, FormArray } from '@angular/forms';
import { SaleOpportunityService } from '../../saleopportunity.service';

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
    get currentEntity(): SaleOpportunity {
        return this._currentEntity;
    }
    @Input('entity')
    set currentEntity(value: SaleOpportunity) {
        this._currentEntity = value;
    }

    _currentSampleBoxProduct: SampleBoxProductItem;
    onSampleBoxProductSelected: Subscription;
    get currentSampleBoxProduct(): SampleBoxProductItem{
        return this._currentSampleBoxProduct;
    }
   
    


    private _formItems: FormArray;
    get formItems(): FormArray {
        return this._formItems;
    }
    @Input('formItems')
    set formItems(value: FormArray) {
        this._formItems = value;
    }



    todos: Todo[];
    currentTodo: Todo;

    // Private
    private _unsubscribeAll: Subject<any>;

    /**
     * Constructor
     *
     * @param _activatedRoute
     * @param _todoService
     * @param _location
     */
    constructor(
        private _activatedRoute: ActivatedRoute
        , private _location: Location
        , private saleOpportunityService: SaleOpportunityService
    )
    {
        // Set the private defaults
        this._unsubscribeAll = new Subject();

        this.onSampleBoxProductSelected = this.saleOpportunityService.onSampleBoxProductSelected.subscribe(sampleBoxProduct => {
            this._currentSampleBoxProduct = sampleBoxProduct;
        });
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void
    {
       
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
     * On drop
     *
     * @param ev
     */
    onDrop(ev): void
    {

    }
}
