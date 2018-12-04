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
import { UserRoleService } from './userRole.service';
import { EnumItem } from '../@resolveServices/resolve.model';
import { DataSourceAbstract } from '../@hipalanetCommons/datatable/datasource.abstract.class';
import { DataSource } from '@angular/cdk/table';
import { RolePermissionService, RolePermissionGrid } from '../role-permissions/rolepermission.core.module';
import { DeletePopupComponent, DeletePopupData, DeletePopupResult } from '../@hipalanetCommons/popups/delete/delete.popup.module';

@Component({
    selector: 'userRole',
    templateUrl: './userRole.component.html',
    styleUrls: ['./userRole.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations
})
export class UserRoleComponent implements OnInit, OnDestroy {
    // Resolve
    listUser: EnumItem<string>[];
    listPermission: EnumItem<string>[];

    id: string;
    currentEntity: UserRole;
    rolePermissions: RolePermissionGrid[];

    pageType: string;
    displayedColumns = ['options', 'thirdPartyAppTypeId', 'thirdPartyUserRoleId'];

    frmMain: FormGroup;
    frmFreightout: FormGroup;


    @ViewChild('tableThirdParty')
    tableThirdParty: MatTable<RolePermissionGrid>;
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
        , private serviceRolePermission: RolePermissionService
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
        this.listUser = this.route.snapshot.data['listUser'];
        this.listPermission = this.route.snapshot.data['listPermission'];

        // Subscribe to update product on changes
        this.service.onCurrentEntityChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(dataResponse => {

                //debugger;
                this.id = dataResponse.id;
                let currentEntity = dataResponse;
                if (currentEntity) {
                    this.currentEntity = new UserRole(currentEntity);
                    this.rolePermissions = (currentEntity.rolePermissions || []).map(item => new RolePermissionGrid(item));
                    this.pageType = 'edit';
                }
                else {
                    this.pageType = 'new';
                    this.currentEntity = new UserRole();
                }

                this.frmMain = this.createFormBasicInfo();
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
    
    /**
     * Save product
     */
    save(): void {
        const basicInfoData = this.frmMain.getRawValue();

        Observable.create(observer => {
            if (this.disableSaveFrmMain()) {
                return this.update(basicInfoData);
            }
            else {
                return of(false);
            }
        })
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



    getPermission(id: string) {
        return this.listPermission.find(o => o.key == id);

    }

    selectedItem: RolePermissionGrid;
    selectItem(item: RolePermissionGrid) {
        this.selectedItem = item;
    }

    newRolePermissionItem() {
        let item = new RolePermissionGrid({ roleId: this.currentEntity.id });
        this.rolePermissions.push(item);
        this.selectItem(item);
        this.tableThirdParty.renderRows();
    }

    saveRolePermissionItem() {
        //debugger;
        (this.selectedItem && this.selectedItem.id) ? this.updateRolePermissionItem(this.selectedItem) : this.addRolePermissionItem(this.selectedItem);
    }

    addRolePermissionItem(item) {
        debugger;
        this.serviceRolePermission.add(item).then(res => {
            this.rolePermissions.push(<RolePermissionGrid>res);

            this._matSnackBar.open('New UserRole Permission saved', 'OK', {
                verticalPosition: 'top',
                duration: 2000
            });

            this.selectedItem = null;
        });

    }

    updateRolePermissionItem(item: RolePermissionGrid) {
        this.serviceRolePermission.update(item).then(res => {

            let newItem = new RolePermissionGrid(<RolePermissionGrid>res);
            let index = this.rolePermissions.findIndex(listItem => listItem.id == newItem.id);
            if (index != -1) {
                this.rolePermissions.splice(index, 1, newItem);
            }

            this._matSnackBar.open('UserRole Third Party Settings saved', 'OK', {
                verticalPosition: 'top',
                duration: 2000
            });

            this.selectedItem = null;

        });
    }

    deleteThirdPartyItemEdition(item: RolePermissionGrid) {
        const dialogRef = this.matDialog.open(DeletePopupComponent, {
            width: '250px',
            data: <DeletePopupData>{ elementDescription: `${this.getPermission(item.permissionId).value} ${item.roleId}` }
        });

        dialogRef.afterClosed().subscribe((result: DeletePopupResult) => {
            if (result == 'YES') {
                this.deleteThirdPartyItemEditionExecution(item);
            }
        });
    }


    deleteThirdPartyItemEditionExecution(item: RolePermissionGrid) {
        this.serviceRolePermission.update(item).then(res => {

            let newItem = new RolePermissionGrid(<RolePermissionGrid>res);
            let index = this.rolePermissions.findIndex(listItem => listItem.id == newItem.id);
            if (index != -1) {
                this.rolePermissions.splice(index, 1, newItem);
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



    disableSaveFrmMain() {
        return (this.frmMain.invalid || this.frmMain.pristine);
    }

    disableSave() {
        return this.disableSaveFrmMain();
    }
}

