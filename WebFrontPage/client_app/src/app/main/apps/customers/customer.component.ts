import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Location } from '@angular/common';
import { MatSnackBar } from '@angular/material';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import { Customer, Freightout } from './customer.model';
import { CustomerService } from './customer.service';

@Component({
    selector: 'customer',
    templateUrl: './customer.component.html',
    styleUrls: ['./customer.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations   : fuseAnimations
})
export class CustomerComponent implements OnInit, OnDestroy
{
    id: string;
    currentEntity: Customer;
    pageType: string;
    frmMain: FormGroup;
    frmFreightout: FormGroup;

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
        private _service: CustomerService ,
        private _formBuilder: FormBuilder,
        private _location: Location,
        private _matSnackBar: MatSnackBar
    )
    {
        // Set the default
        this.currentEntity = new Customer();

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
        this._service.onCurrentEntityChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(dataResponse => {

                //debugger;
                this.id = dataResponse.id;
                let currentEntity = dataResponse;
                if ( currentEntity )
                {
                    this.currentEntity = currentEntity; //new Product(product);
                    this.pageType = 'edit';
                }
                else
                {
                    this.pageType = 'new';
                    this.currentEntity = new Customer();
                }

                this.frmMain = this.createFormBasicInfo();
                this.frmFreightout = this.createFormFreightout();
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
    createFormBasicInfo(): FormGroup
    {
        return this._formBuilder.group({
            id            : [this.currentEntity.id],
            name            : [this.currentEntity.name],
        });
    }

    createFormFreightout() {
        let freightout = this.currentEntity.freightout || <Freightout>{};
        return this._formBuilder.group({
            id: [this.currentEntity.id],
            cost: [freightout.cost],
            wProtect: [freightout.wProtect],
            surchargeYearly: [freightout.surchargeYearly],
            surchargeHourly: [freightout.surchargeHourly],
            dateBegin: [freightout.dateBegin],
            dateEnd: [freightout.dateEnd],
        });
        
    }

    /**
     * Save product
     */
    save(): void
    {
        const data = this.frmMain.getRawValue();
        data.handle = FuseUtils.handleize(data.name);

        this._service.save(this.id, data)
            .then(() => {

                // Trigger the subscription with new data
                this._service.onCurrentEntityChanged.next(data);

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

        this._service.add(data)
            .then(() => {

                // Trigger the subscription with new data
                this._service.onCurrentEntityChanged.next(data);

                // Show the success message
                this._matSnackBar.open('Notification Group added', 'OK', {
                    verticalPosition: 'top',
                    duration        : 2000
                });

                // Change the location with new one
                this._location.go('apps/customers/' + this.currentEntity.id );
            });
    }
}
