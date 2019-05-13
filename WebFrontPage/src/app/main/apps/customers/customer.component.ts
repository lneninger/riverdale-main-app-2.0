/// <reference path='../customerthirdpartyappsetting/customerthirdpartyappsetting.service.ts' />
import {
    Component,
    OnDestroy,
    OnInit,
    ViewEncapsulation,
    ViewChild
} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Location } from '@angular/common';
import {
    MatSnackBar,
    MatPaginator,
    MatSort,
    MatTable,
    MatDialog
} from '@angular/material';
import { Subject, Observable, of } from 'rxjs';
import { takeUntil, map } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import {
    ThirdPartyAppTypeResolveService,
    CustomerFreightoutRateTypeResolveService
} from '../@resolveServices/resolve.module';

import { Customer } from './customer.model';
import { ThirdPartyGrid } from '../customerthirdpartyappsetting/customerthirdpartyappsetting.model';
import { CustomerService } from './customer.service';
import { EnumItem } from '../@resolveServices/resolve.model';
import { DataSourceAbstract } from '../@hipalanetCommons/datatable/datasource.abstract.class';
import { DataSource } from '@angular/cdk/table';
import { CustomerThirdPartyAppSettingService } from '../customerthirdpartyappsetting/customerthirdpartyappsetting.service';
import {
    DeletePopupComponent,
    DeletePopupData,
    DeletePopupResult
} from '../@hipalanetCommons/popups/delete/delete.popup.module';
import {
    CustomerFreightoutService,
    CustomerFreightout
} from '../customerfreightout/customerfreightout.core.module';
import { OperationResponse } from '../@hipalanetCommons/authentication/securehttpclient.service';
import { OperationResponseValued } from '../@hipalanetCommons/messages/messages.model';

@Component({
    selector: 'customer',
    templateUrl: './customer.component.html',
    styleUrls: ['./customer.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations
})
export class CustomerComponent implements OnInit, OnDestroy {
    // Resolve
    listThirdParty$ = this.thirdPartyAppTypeResolveService.onList;
    listCustomerFreightoutRateType$ = this
        .customerFreightoutRateTypeResolveService.onList;

    id: string;
    currentEntity: Customer;
    thirdPartySettings: ThirdPartyGrid[];
    freightout: CustomerFreightout;

    selectedItem: ThirdPartyGrid;
    pageType: string;
    displayedColumns = [
        'options',
        'thirdPartyAppTypeId',
        'thirdPartyCustomerId'
    ];

    frmMain: FormGroup;
    frmFreightout: FormGroup;

    @ViewChild('tableThirdParty')
    tableThirdParty: MatTable<ThirdPartyGrid>;
    // Private
    private _unsubscribeAll: Subject<any>;

    /**
     *
     * @param route Activated route
     * @param service Service
     * @param serviceFreightout Freightout service
     * @param serviceThirdParty ThirdParty service
     * @param _formBuilder Form builder
     * @param _location Location service
     * @param thirdPartyAppTypeResolveService Third party resolve service
     * @param customerFreightoutRateTypeResolveService customer freightout resolve service
     * @param _matSnackBar Snackbar service
     * @param matDialog Dialog service
     */
    constructor(
        private route: ActivatedRoute,
        private service: CustomerService,
        private serviceFreightout: CustomerFreightoutService,
        private serviceThirdPartyService: CustomerThirdPartyAppSettingService,
        private _formBuilder: FormBuilder,
        private _location: Location,
        private thirdPartyAppTypeResolveService: ThirdPartyAppTypeResolveService,
        private customerFreightoutRateTypeResolveService: CustomerFreightoutRateTypeResolveService,
        private _matSnackBar: MatSnackBar,
        private matDialog: MatDialog
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

        // Subscribe to update product on changes
        this.service.onCurrentEntityChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(dataResponse => {
                // debugger;
                const currentEntity = dataResponse.bag;
                this.id = currentEntity.id;
                if (currentEntity) {
                    this.currentEntity = new Customer(currentEntity);
                    this.setThirdPartySettings(currentEntity);
                    this.freightout =
                        currentEntity.freightout || <CustomerFreightout>{};
                    this.pageType = 'edit';
                } else {
                    this.pageType = 'new';
                    this.currentEntity = new Customer();
                }

                this.frmMain = this.createFormBasicInfo();
                this.frmFreightout = this.createFormFreightout();
            });
    }

    setThirdPartySettings(response: any): void {
        this.thirdPartySettings = (response.thirdPartySettings || []).map(
            item => new ThirdPartyGrid(item)
        );
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
     * @returns Form Group for Reactive Form
     */
    createFormBasicInfo(): FormGroup {
        return this._formBuilder.group({
            id: [this.currentEntity.id],
            name: [this.currentEntity.name]
        });
    }

    createFormFreightout(): FormGroup {
        // debugger;
        const freightout = this.freightout || <CustomerFreightout>{};
        return this._formBuilder.group({
            id: [freightout.id],
            customerFreightoutRateTypeId: [
                freightout.customerFreightoutRateTypeId
            ],
            customerId: [this.currentEntity.id],
            cost: [freightout.cost],
            wProtect: [freightout.wProtect],
            secondLeg: [freightout.secondLeg],
            surchargeYearly: [freightout.surchargeYearly],
            surchargeHourly: [freightout.surchargeHourly],
            dateFrom: [freightout.dateFrom],
            dateTo: [freightout.dateTo]
        });
    }

    /**
     * Save product
     */
    save(): void {
        const basicInfoData = this.frmMain.getRawValue();
        // debugger;
        Observable.create(observer => {
            if (this.disableSaveFrmMain()) {
                observer.next(null);
                observer.complete();
            } else {
                this.service.save(basicInfoData).then(response => {
                    observer.next(response);
                    observer.complete();
                });
            }
        })
            .toPromise()
            .then((response: OperationResponse<Customer>) => {
                // debugger;
                // Trigger the subscription with new data
                this.service.onCurrentEntityChanged.next(basicInfoData);

                // Show the success message
                this._matSnackBar.open('Customer saved', 'OK', {
                    verticalPosition: 'top',
                    duration: 2000
                });

                // Change the location with new one
                // this.service.router.navigate([`../`], { relativeTo: this.route });
            });
    }

    delete(): void {
        const dialogRef = this.matDialog.open(DeletePopupComponent, {
            width: '250px',
            data: <DeletePopupData>{
                elementDescription: this.currentEntity.name
            }
        });

        dialogRef.afterClosed().subscribe((result: DeletePopupResult) => {
            if (result === 'YES') {
                this.deleteExecution();
            }
        });
    }

    deleteExecution(): void {
        this.service.delete(this.currentEntity.id).then(() => {
            // Show the success message
            this._matSnackBar.open('Customer deleted', 'OK', {
                verticalPosition: 'top',
                duration: 2000
            });

            // Change the location with new one
            this._location.go('apps/customers');
        });
    }

    getThirdPartyAppType(id: string): Observable<EnumItem<string>> {
        return this.listThirdParty$
            .asObservable()
            .pipe<EnumItem<string>>(
                map(listThirdParty => listThirdParty.find(o => o.key === id))
            );
    }

    selectItem(item: ThirdPartyGrid): void {
        this.selectedItem = item;
    }

    newThirdPartyItem(): void {
        const item = new ThirdPartyGrid({ customerId: this.currentEntity.id });
        this.thirdPartySettings.push(item);
        this.selectItem(item);
        this.tableThirdParty.renderRows();
    }

    saveThirdPartyItem(): void {
        // debugger;
        this.selectedItem && this.selectedItem.id
            ? this.updateThirdPartyItem(this.selectedItem)
            : this.addThirdPartyItem(this.selectedItem);
    }

    addThirdPartyItem(item: ThirdPartyGrid): void {
        // debugger;
        this.serviceThirdPartyService.add(item).then(res => {
            const newItemIndex = this.thirdPartySettings.findIndex(
                arrayItem => arrayItem.id === null
            );
            if (newItemIndex > -1) {
                this.thirdPartySettings[newItemIndex] = <ThirdPartyGrid>res.bag;
            }

            this._matSnackBar.open(
                'New Customer Third Party Settings saved',
                'OK',
                {
                    verticalPosition: 'top',
                    duration: 2000
                }
            );

            this.selectedItem = null;
            // this.setThirdPartySettings();
        });
    }

    updateThirdPartyItem(item: ThirdPartyGrid): void {
        this.serviceThirdPartyService.update(item).then(res => {
            const newItem = new ThirdPartyGrid(<ThirdPartyGrid>res);
            const index = this.thirdPartySettings.findIndex(
                listItem => listItem.id === newItem.id
            );
            if (index !== -1) {
                this.thirdPartySettings.splice(index, 1, newItem);
            }

            this._matSnackBar.open(
                'Customer Third Party Settings saved',
                'OK',
                {
                    verticalPosition: 'top',
                    duration: 2000
                }
            );

            this.selectedItem = null;
            // this.setThirdPartySettings();
        });
    }

    deleteThirdPartyItemEdition(item: ThirdPartyGrid): void {
        this.getThirdPartyAppType(item.thirdPartyAppTypeId).subscribe(
            thirdParty => {
                const dialogRef = this.matDialog.open(DeletePopupComponent, {
                    width: '250px',
                    data: <DeletePopupData>{
                        elementDescription: `${thirdParty.value} ${
                            item.thirdPartyCustomerId
                        }`
                    }
                });

                dialogRef
                    .afterClosed()
                    .subscribe((result: DeletePopupResult) => {
                        if (result === 'YES') {
                            this.deleteThirdPartyItemEditionExecution(item);
                        }
                    });
            }
        );
    }

    deleteThirdPartyItemEditionExecution(item: ThirdPartyGrid): void {
        this.serviceThirdPartyService.update(item).then(res => {
            const newItem = new ThirdPartyGrid(<ThirdPartyGrid>res);
            const index = this.thirdPartySettings.findIndex(
                listItem => listItem.id === newItem.id
            );
            if (index !== -1) {
                this.thirdPartySettings.splice(index, 1, newItem);
            }

            this._matSnackBar.open(
                'Customer Third Party Settings deleted',
                'OK',
                {
                    verticalPosition: 'top',
                    duration: 2000
                }
            );

            this.selectedItem = null;
        });
    }

    cancelThirdPartyItemEdition(): void {
        this.selectedItem = null;
    }

    saveCustomerFreightout(): void {
        const freightoutData = this.frmFreightout.getRawValue();
        Observable.create(observer => {
            if (!this.disableSaveFrmFreightout()) {
                if (freightoutData.id) {
                    this.serviceFreightout
                        .update(freightoutData)
                        .then(response => {
                            observer.next(response);
                            observer.complete();
                        });
                } else {
                    return this.serviceFreightout
                        .add(freightoutData)
                        .then(response => {
                            observer.next(response);
                            observer.complete();
                        });
                }
            } else {
                observer.next(null);
                observer.complete();
            }
        })
            .toPromise()
            .then(() => {
                // debugger;

                // Show the success message
                this._matSnackBar.open('Customer freighout saved', 'OK', {
                    verticalPosition: 'top',
                    duration: 5000
                });
            });
    }

    disableSaveFrmMain(): boolean {
        return this.frmMain.invalid || this.frmMain.pristine;
    }

    disableSaveFrmFreightout(): boolean {
        return this.frmFreightout.invalid || this.frmFreightout.pristine;
    }

    disableSave(): boolean {
        return this.disableSaveFrmMain() && this.disableSaveFrmFreightout();
    }
}
