import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Location } from '@angular/common';
import { MatSnackBar } from '@angular/material';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import { ProductColor } from './productcolor.model';
import { ProductColorService } from './productcolor.core.module';

@Component({
    selector: 'product-color',
    templateUrl: './productcolor.component.html',
    styleUrls: ['./productcolor.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations   : fuseAnimations
})
export class ProductColorComponent implements OnInit, OnDestroy
{
    id: string;
    currentEntity: ProductColor;
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
        private service: ProductColorService ,
        private _formBuilder: FormBuilder,
        private _location: Location,
        private _matSnackBar: MatSnackBar
    )
    {
        // Set the default
        this.currentEntity = new ProductColor();

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
        this.service.onCurrentEntityChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(dataResponse => {

                //debugger;
                this.id = dataResponse.id;
                let currentEntity = dataResponse;
                if ( currentEntity )
                {
                    this.currentEntity = currentEntity;
                    this.pageType = 'edit';
                }
                else
                {
                    this.pageType = 'new';
                    this.currentEntity = new ProductColor();
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
            id            : [this.currentEntity.id],
            name            : [this.currentEntity.name],
        });
    }

    /**
     * Save product
     */
    save(): void
    {
        const data = this.frmMain.getRawValue();

        this.service.save(data)
            .then(() => {

                // Trigger the subscription with new data
                this.service.onCurrentEntityChanged.next(data);

                // Show the success message
                this._matSnackBar.open('Customer saved', 'OK', {
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

        this.service.add(data)
            .then(() => {

                // Trigger the subscription with new data
                this.service.onCurrentEntityChanged.next(data);

                // Show the success message
                this._matSnackBar.open('Notification Group added', 'OK', {
                    verticalPosition: 'top',
                    duration        : 2000
                });

                // Change the location with new one
                this._location.go('apps/product-colors/' + this.currentEntity.id );
            });
    }
}
