import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Location } from '@angular/common';
import { MatSnackBar } from '@angular/material';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import { Product } from 'app/main/apps/e-commerce/product/product.model';
import { NotificationGroupService } from 'app/main/apps/notification-groups/notificationgroup.service';

@Component({
    selector: 'notificationgroup',
    templateUrl: './notificationgroup.component.html',
    styleUrls: ['./notificationgroup.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations   : fuseAnimations
})
export class NotificationGroupComponent implements OnInit, OnDestroy
{
    id: string;
    currentEntity: Product;
    pageType: string;
    frmMain: FormGroup;

    // Private
    private _unsubscribeAll: Subject<any>;

    /**
     * Constructor
     *
     * @param {EcommerceProductService} _ecommerceProductService
     * @param {FormBuilder} _formBuilder
     * @param {Location} _location
     * @param {MatSnackBar} _matSnackBar
     */
    constructor(
        private _notificationGroupService: NotificationGroupService ,
        private _formBuilder: FormBuilder,
        private _location: Location,
        private _matSnackBar: MatSnackBar
    )
    {
        // Set the default
        this.currentEntity = new Product();

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
        // Subscribe to update product on changes
        this._notificationGroupService.onProductChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(dataResponse => {

                this.id = dataResponse.id;
                let currentEntity = dataResponse.entity;
                if ( currentEntity )
                {
                    this.currentEntity = currentEntity; //new Product(product);
                    this.pageType = 'edit';
                }
                else
                {
                    this.pageType = 'new';
                    this.currentEntity = new Product();
                }

                this.frmMain = this.createForm();
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
    createForm(): FormGroup
    {
        return this._formBuilder.group({
            id              : [this.currentEntity.id],
            name            : [this.currentEntity.name],
            handle          : [this.currentEntity.handle],
            description     : [this.currentEntity.description],
            categories      : [this.currentEntity.categories],
            tags            : [this.currentEntity.tags],
            images          : [this.currentEntity.images],
            priceTaxExcl    : [this.currentEntity.priceTaxExcl],
            priceTaxIncl    : [this.currentEntity.priceTaxIncl],
            taxRate         : [this.currentEntity.taxRate],
            comparedPrice   : [this.currentEntity.comparedPrice],
            quantity        : [this.currentEntity.quantity],
            sku             : [this.currentEntity.sku],
            width           : [this.currentEntity.width],
            height          : [this.currentEntity.height],
            depth           : [this.currentEntity.depth],
            weight          : [this.currentEntity.weight],
            extraShippingFee: [this.currentEntity.extraShippingFee],
            active          : [this.currentEntity.active]
        });
    }

    /**
     * Save product
     */
    save(): void
    {
        const data = this.frmMain.getRawValue();
        data.handle = FuseUtils.handleize(data.name);

        this._notificationGroupService.save(this.id, data)
            .then(() => {

                // Trigger the subscription with new data
                this._notificationGroupService.onProductChanged.next(data);

                // Show the success message
                this._matSnackBar.open('Notification Group saved', 'OK', {
                    verticalPosition: 'top',
                    duration        : 2000
                });
            });
    }

    /**
     * Add product
     */
    add(): void
    {
        const data = this.frmMain.getRawValue();
        data.handle = FuseUtils.handleize(data.name);

        this._notificationGroupService.add(data)
            .then(() => {

                // Trigger the subscription with new data
                this._notificationGroupService.onProductChanged.next(data);

                // Show the success message
                this._matSnackBar.open('Notification Group added', 'OK', {
                    verticalPosition: 'top',
                    duration        : 2000
                });

                // Change the location with new one
                this._location.go('apps/e-commerce/products/' + this.currentEntity.id + '/' + this.currentEntity.handle);
            });
    }
}
