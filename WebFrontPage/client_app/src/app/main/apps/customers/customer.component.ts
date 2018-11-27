import { Component, OnDestroy, OnInit, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Location } from '@angular/common';
import { MatSnackBar, MatPaginator, MatSort, MatTable } from '@angular/material';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import { Customer, Freightout, ThirdPartyGrid } from './customer.model';
import { CustomerService } from './customer.service';
import { EnumItem } from '../@resolveServices/resolve.model';
import { DataSourceAbstract } from '../@hipalanetCommons/datatable/datasource.abstract.class';
import { DataSource } from '@angular/cdk/table';

@Component({
    selector: 'customer',
    templateUrl: './customer.component.html',
    styleUrls: ['./customer.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations   : fuseAnimations
})
export class CustomerComponent implements OnInit, OnDestroy
{
    // Resolve
    listCustomerFreightoutRateType: EnumItem<string>[];
    listThirdParty: EnumItem<string>[];

    id: string;
    currentEntity: Customer;
    pageType: string;
    displayedColumns = ['options', 'thirdPartyAppTypeId', 'thirdPartyCustomerId'];

    frmMain: FormGroup;
    frmFreightout: FormGroup;


    @ViewChild('tableThirdParty')
    tableThirdParty: MatTable;
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
        private route: ActivatedRoute
        , private service: CustomerService
        , private _formBuilder: FormBuilder
        , private _location: Location
        , private _matSnackBar: MatSnackBar
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
        // Resolve
        this.listCustomerFreightoutRateType = this.route.snapshot.data['listCustomerFreightoutRateType'];
        this.listThirdParty = this.route.snapshot.data['listThirdParty'];

        // Subscribe to update product on changes
        this.service.onCurrentEntityChanged
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

        this.service.save(this.id, data)
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
                this._location.go('apps/customers/' + this.currentEntity.id );
            });
    }

    getThirdPartyAppType(id: string) {
        return this.listThirdParty.find(o => o.key == id);

    }

    selectedItem: ThirdPartyGrid;
    selectItem(item: ThirdPartyGrid) {
        this.selectedItem = item;
    }

    addThirdPartyItem() {
        let item = new ThirdPartyGrid();
        this.currentEntity.thirdPartySettings.push(item);
        this.selectItem(item);
        this.tableThirdParty.renderRows();
    }

    saveThirdPartyItem(item) {
        this.service.addThirdPartyCustomer(item);
    }

    cancelThirdPartyItemEdition() {
        this.selectedItem = null;
    }
}

