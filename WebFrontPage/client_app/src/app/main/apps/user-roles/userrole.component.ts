/// <reference path="../userRolethirdpartyappsetting/userRolethirdpartyappsetting.service.ts" />
import { Component, OnDestroy, OnInit, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Location } from '@angular/common';
import { MatSnackBar, MatPaginator, MatSort, MatTable, MatDialog } from '@angular/material';
import { Subject, Observable, of } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import { UserRole } from './userRole.model';
import { ThirdPartyGrid } from '../userRolethirdpartyappsetting/userRolethirdpartyappsetting.model';
import { UserRoleService } from './userRole.service';
import { EnumItem } from '../@resolveServices/resolve.model';
import { DataSourceAbstract } from '../@hipalanetCommons/datatable/datasource.abstract.class';
import { DataSource } from '@angular/cdk/table';
import { UserRoleThirdPartyAppSettingService } from '../userRolethirdpartyappsetting/userRolethirdpartyappsetting.service';
import { DeletePopupComponent, DeletePopupData, DeletePopupResult } from '../@hipalanetCommons/popups/delete/delete.popup.module';
import { UserRoleFreightoutService, UserRoleFreightout } from '../userRolefreightout/userRolefreightout.core.module';

@Component({
    selector: 'userRole',
    templateUrl: './userRole.component.html',
    styleUrls: ['./userRole.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations
})
export class UserRoleComponent implements OnInit, OnDestroy {
    // Resolve
    listUserRoleFreightoutRateType: EnumItem<string>[];
    listThirdParty: EnumItem<string>[];

    id: string;
    currentEntity: UserRole;
    thirdPartySettings: ThirdPartyGrid[];
    freightout: UserRoleFreightout;

    pageType: string;
    displayedColumns = ['options', 'thirdPartyAppTypeId', 'thirdPartyUserRoleId'];

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
        , private service: UserRoleService
        , private serviceFreightout: UserRoleFreightoutService
        , private serviceThirdParty: UserRoleThirdPartyAppSettingService
        , private _formBuilder: FormBuilder
        , private _location: Location
        , private _matSnackBar: MatSnackBar
        , private matDialog: MatDialog
    ) {
        // Set the default
        this.currentEntity = new UserRole();

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
        this.listUserRoleFreightoutRateType = this.route.snapshot.data['listUserRoleFreightoutRateType'];
        this.listThirdParty = this.route.snapshot.data['listThirdParty'];

        // Subscribe to update product on changes
        this.service.onCurrentEntityChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(dataResponse => {

                //debugger;
                this.id = dataResponse.id;
                let currentEntity = dataResponse;
                if (currentEntity) {
                    this.currentEntity = new UserRole(currentEntity);
                    this.thirdPartySettings = (currentEntity.thirdPartySettings || []).map(item => new ThirdPartyGrid(item));
                    this.freightout = (currentEntity.freightout || <UserRoleFreightout>{});
                    this.pageType = 'edit';
                }
                else {
                    this.pageType = 'new';
                    this.currentEntity = new UserRole();
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
        let freightout = this.freightout || <UserRoleFreightout>{};
        return this._formBuilder.group({
            id: [freightout.id],
            userRoleFreightoutRateTypeId: [freightout.userRoleFreightoutRateTypeId],
            userRoleId: [this.currentEntity.id],
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
        const freightoutData = this.frmFreightout.getRawValue();

        Observable.create(observer => {
            if (!this.disableSaveFrmMain()) {
                return of(false);
            }
            else {
                return this.update(freightoutData);
            }
        })
        .pipe(() =>
            Observable.create(observer => {
                if (!this.disableSaveFrmFreightout()) {
                    if (freightoutData.id) {
                        return this.serviceFreightout.update(freightoutData)
                    }
                    else {
                        return this.serviceFreightout.add(freightoutData)
                    }
                }
                else {
                    return of(false);
                }
            })
        )
        .toPromise()
        .then(() => {
            //debugger;
            // Trigger the subscription with new data
            this.service.onCurrentEntityChanged.next(basicInfoData);

            // Show the success message
            this._matSnackBar.open('UserRole saved', 'OK', {
                verticalPosition: 'top',
                duration: 2000
            });
        });
    }

    /**
     * Add product
     */
    update(entity: UserRole): Observable<UserRole> {
        return Observable.create(observer => {
            this.service.save(entity)
                .then((result: UserRole) => {
                    observer.next(result);
                    observer.complete();
                });
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
                this._matSnackBar.open('UserRole deleted', 'OK', {
                    verticalPosition: 'top',
                    duration: 2000
                });

                // Change the location with new one
                this._location.go('apps/userRoles');
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
        let item = new ThirdPartyGrid({ userRoleId: this.currentEntity.id });
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

            this._matSnackBar.open('New UserRole Third Party Settings saved', 'OK', {
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

            this._matSnackBar.open('UserRole Third Party Settings saved', 'OK', {
                verticalPosition: 'top',
                duration: 2000
            });

            this.selectedItem = null;

        });
    }

    deleteThirdPartyItemEdition(item: ThirdPartyGrid) {
        const dialogRef = this.matDialog.open(DeletePopupComponent, {
            width: '250px',
            data: <DeletePopupData>{ elementDescription: `${this.getThirdPartyAppType(item.thirdPartyAppTypeId).value} ${item.thirdPartyUserRoleId}` }
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

            this._matSnackBar.open('UserRole Third Party Settings deleted', 'OK', {
                verticalPosition: 'top',
                duration: 2000
            });

            this.selectedItem = null;

        });
    }

    cancelThirdPartyItemEdition() {
        this.selectedItem = null;
    }




    addUserRoleFreightout(item: UserRoleFreightout) {
        //debugger;
        return this.serviceFreightout.update(item);

    }

    updateUserRoleFreightout(item: UserRoleFreightout) {
        this.serviceThirdParty.update(item).then(res => {

            let newItem = new ThirdPartyGrid(<ThirdPartyGrid>res);
            let index = this.thirdPartySettings.findIndex(listItem => listItem.id == newItem.id);
            if (index != -1) {
                this.thirdPartySettings.splice(index, 1, newItem);
            }

            this._matSnackBar.open('UserRole Third Party Settings saved', 'OK', {
                verticalPosition: 'top',
                duration: 2000
            });

            this.selectedItem = null;

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

