import { Component, OnDestroy, OnInit, ViewEncapsulation, Input } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { Subject, Subscription } from 'rxjs';

import { fuseAnimations } from '@fuse/animations';

import { Todo } from '../saleopportunity.view.model';
import { SaleOpportunityViewService } from '../saleopportunity.view.service';
import { takeUntil } from 'rxjs/operators';
import { SaleOpportunity, ProductGrid, TargetPriceItem, TargetPriceProductItem } from '../../saleopportunity.model';
import { Form, FormArray } from '@angular/forms';
import { SaleOpportunityService } from '../../saleopportunity.service';

@Component({
    selector: 'saleopportunity-view-list-targetpriceproducts',
    templateUrl: './saleopportunity.view-list.component.html',
    styleUrls: ['./saleopportunity.view-list.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations   : fuseAnimations
})
export class SaleOpportunityViewListTargetPriceProductComponent implements OnInit, OnDestroy
{
    private _currentEntity: SaleOpportunity;
    get currentEntity(): SaleOpportunity {
        return this._currentEntity;
    }
    @Input('entity')
    set currentEntity(value: SaleOpportunity) {
        this._currentEntity = value;
    }

    _currentTargetPrice: TargetPriceItem;
    onTargetPriceProductSelected: Subscription;
    get currentTargetPrice(): TargetPriceItem{
        return this._currentTargetPrice;
    }

    get listOfSubItems(): TargetPriceProductItem[]{
        return (this._currentTargetPrice && this._currentTargetPrice.saleOpportunityTargetPriceProducts) || [];
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
     * 
     * @param _activatedRoute Active route service
     * @param _location Location service
     * @param saleOpportunityService Sale opportunity service
     */
    constructor(
        private _activatedRoute: ActivatedRoute
        , private _location: Location
        , private saleOpportunityService: SaleOpportunityService
    )
    {
        // Set the private defaults
        this._unsubscribeAll = new Subject();

        this.onTargetPriceProductSelected = this.saleOpportunityService.onTargetPriceSelected.subscribe(targetPrice => {
            this._currentTargetPrice = targetPrice;
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
     * 
     */
    onDrop(ev: any): void
    {

    }
}
