/// <reference path="../customerthirdpartyappsetting/customerthirdpartyappsetting.service.ts" />
import { Component, OnDestroy, OnInit, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Location } from '@angular/common';
import { MatSnackBar, MatPaginator, MatSort, MatTable, MatDialog } from '@angular/material';
import { Subject, Observable, of } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import { Customer } from './customer.model';
import { ThirdPartyGrid } from '../customerthirdpartyappsetting/customerthirdpartyappsetting.model';
import { CustomerService } from './customer.service';
import { EnumItem } from '../@resolveServices/resolve.model';
import { DataSourceAbstract } from '../@hipalanetCommons/datatable/datasource.abstract.class';
import { DataSource } from '@angular/cdk/table';
import { CustomerThirdPartyAppSettingService } from '../customerthirdpartyappsetting/customerthirdpartyappsetting.service';
import { DeletePopupComponent, DeletePopupData, DeletePopupResult } from '../@hipalanetCommons/popups/delete/delete.popup.module';
import { CustomerFreightoutService, CustomerFreightout } from '../customerfreightout/customerfreightout.core.module';
import { OperationResponse } from '../@hipalanetCommons/authentication/securehttpclient.service';

@Component({
    selector: 'customer',
    templateUrl: './customer.component.html',
    styleUrls: ['./customer.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations
})
export class CustomerComponent implements OnInit, OnDestroy {
    // Resolve
    listCustomerFreightoutRateType: EnumItem<string>[];
    listThirdParty: EnumItem<string>[];

    id: string;
    currentEntity: Customer;
    thirdPartySettings: ThirdPartyGrid[];
    freightout: CustomerFreightout;

    pageType: string;
    displayedColumns = ['options', 'thirdPartyAppTypeId', 'thirdPartyCustomerId'];

    frmMain: FormGroup;
    frmFreightout: FormGroup;


    @ViewChild('tableThirdParty')
    tableThirdParty: MatTable<ThirdPartyGrid>;
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
        , private serviceFreightout: CustomerFreightoutService
        , private serviceThirdParty: CustomerThirdPartyAppSettingService
        , private _formBuilder: FormBuilder
        , private _location: Location
        , private _matSnackBar: MatSnackBar
        , private matDialog: MatDialog
    ) {
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
    ngOnInit(): void {
        // Resolve
        this.listCustomerFreightoutRateType = this.route.snapshot.data['listCustomerFreightoutRateType'];
        this.listThirdParty = this.route.snapshot.data['listThirdParty'];

        // Subscribe to update product on changes
        this.service.onCurrentEntityChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(dataResponse => {

                //debugger;
                let currentEntity = dataResponse.bag;
                this.id = currentEntity.id;
                if (currentEntity) {
                    this.currentEntity = new Customer(currentEntity);
                    this.thirdPartySettings = (currentEntity.thirdPartySettings || []).map(item => new ThirdPartyGrid(item));
                    this.freightout = (currentEntity.freightout || <CustomerFreightout>{});
                    this.pageType = 'edit';
                }
                else {
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
    ngOnDestroy(): void {
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
        return this._formBuilder.group({
            id: [this.currentEntity.id],
            name: [this.currentEntity.name],
        });
    }

    createFormFreightout() {
        //debugger;
        let freightout = this.freightout || <CustomerFreightout>{};
        return this._formBuilder.group({
            id: [freightout.id],
            customerFreightoutRateTypeId: [freightout.customerFreightoutRateTypeId],
            customerId: [this.currentEntity.id],
            cost: [freightout.cost],
            wProtect: [freightout.wProtect],
            secondLeg: [freightout.secondLeg],
            surchargeYearly: [freightout.surchargeYearly],
            surchargeHourly: [freightout.surchargeHourly],
            dateFrom: [freightout.dateFrom],
            dateTo: [freightout.dateTo],
        });

    }

    /**
     * Save product
     */
    save(): void {
        const basicInfoData = this.frmMain.getRawValue();
        //debugger;
        Observable.create(observer => {
            if (this.disableSaveFrmMain()) {
                observer.next(null);
                observer.complete();
            }
            else {
                this.service.save(basicInfoData).then(response => {
                    observer.next(response);
                    observer.complete();
                });
            }
        })
            .toPromise()
            .then((response: OperationResponse<Customer>) => {
                //debugger;
                // Trigger the subscription with new data
                this.service.onCurrentEntityChanged.next(basicInfoData);

                // Show the success message
                this._matSnackBar.open('Customer saved', 'OK', {
                    verticalPosition: 'top',
                    duration: 2000
                });

                // Change the location with new one
                //this.service.router.navigate([`../`], { relativeTo: this.route });
            });
    }

    delete() {
        const dialogRef = this.matDialog.open(DeletePopupComponent, {
            width: '250px',
            data: <DeletePopupData>{ elementDescription: this.currentEntity.name }
        });

        dialogRef.afterClosed().subscribe((result: DeletePopupResult) => {
            if (result == 'YES') {
                this.deleteExecution();
            }
        });
    }

    deleteExecution() {
        this.service.delete(this.currentEntity.id)
            .then(() => {

                // Show the success message
                this._matSnackBar.open('Customer deleted', 'OK', {
                    verticalPosition: 'top',
                    duration: 2000
                });

                // Change the location with new one
                this._location.go('apps/customers');
            });
    }





    getThirdPartyAppType(id: string) {
        return this.listThirdParty.find(o => o.key == id);

    }

    selectedItem: ThirdPartyGrid;
    selectItem(item: ThirdPartyGrid) {
        this.selectedItem = item;
    }

    newThirdPartyItem() {
        let item = new ThirdPartyGrid({ customerId: this.currentEntity.id });
        this.thirdPartySettings.push(item);
        this.selectItem(item);
        this.tableThirdParty.renderRows();
    }

    saveThirdPartyItem() {
        //debugger;
        (this.selectedItem && this.selectedItem.id) ? this.updateThirdPartyItem(this.selectedItem) : this.addThirdPartyItem(this.selectedItem);
    }

    addThirdPartyItem(item) {
        debugger;
        this.serviceThirdParty.add(item).then(res => {
            this.thirdPartySettings.push(<ThirdPartyGrid>res);

            this._matSnackBar.open('New Customer Third Party Settings saved', 'OK', {
                verticalPosition: 'top',
                duration: 2000
            });

            this.selectedItem = null;
        });

    }

    updateThirdPartyItem(item: ThirdPartyGrid) {
        this.serviceThirdParty.update(item).then(res => {

            let newItem = new ThirdPartyGrid(<ThirdPartyGrid>res);
            let index = this.thirdPartySettings.findIndex(listItem => listItem.id == newItem.id);
            if (index != -1) {
                this.thirdPartySettings.splice(index, 1, newItem);
            }

            this._matSnackBar.open('Customer Third Party Settings saved', 'OK', {
                verticalPosition: 'top',
                duration: 2000
            });

            this.selectedItem = null;

        });
    }

    deleteThirdPartyItemEdition(item: ThirdPartyGrid) {
        const dialogRef = this.matDialog.open(DeletePopupComponent, {
            width: '250px',
            data: <DeletePopupData>{ elementDescription: `${this.getThirdPartyAppType(item.thirdPartyAppTypeId).value} ${item.thirdPartyCustomerId}` }
        });

        dialogRef.afterClosed().subscribe((result: DeletePopupResult) => {
            if (result == 'YES') {
                this.deleteThirdPartyItemEditionExecution(item);
            }
        });
    }


    deleteThirdPartyItemEditionExecution(item: ThirdPartyGrid) {
        this.serviceThirdParty.update(item).then(res => {

            let newItem = new ThirdPartyGrid(<ThirdPartyGrid>res);
            let index = this.thirdPartySettings.findIndex(listItem => listItem.id == newItem.id);
            if (index != -1) {
                this.thirdPartySettings.splice(index, 1, newItem);
            }

            this._matSnackBar.open('Customer Third Party Settings deleted', 'OK', {
                verticalPosition: 'top',
                duration: 2000
            });

            this.selectedItem = null;

        });
    }

    cancelThirdPartyItemEdition() {
        this.selectedItem = null;
    }


    saveCustomerFreightout() {
        const freightoutData = this.frmFreightout.getRawValue();
        Observable.create(observer => {
            if (!this.disableSaveFrmFreightout()) {
                if (freightoutData.id) {
                    this.serviceFreightout.update(freightoutData)
                        .then(response => {
                            observer.next(response);
                            observer.complete();
                        });
                }
                else {
                    return this.serviceFreightout.add(freightoutData)
                        .then(response => {
                            observer.next(response);
                            observer.complete();
                        });
                }
            }
            else {
                observer.next(null);
                observer.complete();
            }
        })
            .toPromise()
            .then(() => {
                //debugger;

                // Show the success message
                this._matSnackBar.open('Customer freighout saved', 'OK', {
                    verticalPosition: 'top',
                    duration: 5000
                });
            });
    }



    disableSaveFrmMain() {
        return (this.frmMain.invalid || this.frmMain.pristine);
    }

    disableSaveFrmFreightout() {
        return (this.frmFreightout.invalid || this.frmFreightout.pristine);
    }

    disableSave() {
        return this.disableSaveFrmMain() && this.disableSaveFrmFreightout();
    }
}

