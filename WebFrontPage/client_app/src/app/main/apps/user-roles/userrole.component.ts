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
import { UserRoleService } from './userrole.service';
import { EnumItem } from '../@resolveServices/resolve.model';
import { DataSourceAbstract } from '../@hipalanetCommons/datatable/datasource.abstract.class';
import { DataSource } from '@angular/cdk/table';
import { RolePermissionService, RolePermissionGrid } from '../role-permissions/rolepermission.core.module';
import { DeletePopupComponent, DeletePopupData, DeletePopupResult } from '../@hipalanetCommons/popups/delete/delete.popup.module';
import { RoleUserGrid } from '../role-users/roleuser.model';
import { RoleUserService } from '../role-users/roleuser.service';

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
    roleUsers: RoleUserGrid[];

    pageType: string;
    displayedColumnsRolePermissions = ['options', 'permissionId'];
    displayedColumnsRoleUsers = ['options', 'userId'];

    frmMain: FormGroup;
    frmFreightout: FormGroup;


    @ViewChild('tableRolePermission')
    tableRolePermission: MatTable<RolePermissionGrid>;


    @ViewChild('tableRoleUser')
    tableRoleUser: MatTable<RoleUserGrid>;
    

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
        , private serviceRoleUser: RoleUserService
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
                let currentEntity = dataResponse.bag;
                if (currentEntity) {
                    this.currentEntity = new UserRole(currentEntity);
                    this.rolePermissions = (currentEntity.rolePermissions || []).map(item => new RolePermissionGrid(item));
                    this.roleUsers = (currentEntity.roleUsers || []).map(item => new RoleUserGrid(item));
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
     * Add entity
     */
    update(entity: UserRole): Observable<UserRole> {
        return Observable.create(observer => {
            this.service.update(entity)
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



   
    /*******************Role Permission*************************************************************** */
    getPermission(id: string) {
        return this.listPermission.find(o => o.key == id);
    }

    selectedRolePermissionItem: RolePermissionGrid;
    selectRolePermissionItem(item: RolePermissionGrid) {
        this.selectedRolePermissionItem = item;
    }

    newRolePermissionItem() {
        let item = new RolePermissionGrid({ roleId: this.currentEntity.id });
        this.rolePermissions.push(item);
        this.selectRolePermissionItem(item);
        this.tableRolePermission.renderRows();
    }

    saveRolePermissionItem() {
        //debugger;
        this.addRolePermissionItem(this.selectedRolePermissionItem);
        //(this.selectedRolePermissionItem && this.selectedRolePermissionItem.id) ? this.updateRolePermissionItem(this.selectedRolePermissionItem) : this.addRolePermissionItem(this.selectedRolePermissionItem);
    }

    addRolePermissionItem(item) {
        //debugger;
        this.serviceRolePermission.add(item).then(res => {
            this.rolePermissions.push(<RolePermissionGrid>res);

            this._matSnackBar.open('New UserRole Permission saved', 'OK', {
                verticalPosition: 'top',
                duration: 2000
            });

            this.selectedRolePermissionItem = null;
        });
    }

    //updateRolePermissionItem(item: RolePermissionGrid) {
    //    this.serviceRolePermission.update(item).then(res => {

    //        let newItem = new RolePermissionGrid(<RolePermissionGrid>res);
    //        let index = this.rolePermissions.findIndex(listItem => listItem.id == newItem.id);
    //        if (index != -1) {
    //            this.rolePermissions.splice(index, 1, newItem);
    //        }

    //        this._matSnackBar.open('UserRole Third Party Settings saved', 'OK', {
    //            verticalPosition: 'top',
    //            duration: 2000
    //        });

    //        this.selectedRolePermissionItem = null;

    //    });
    //}

    deleteRolePermissionItemEdition(item: RolePermissionGrid) {
        const dialogRef = this.matDialog.open(DeletePopupComponent, {
            width: '250px',
            data: <DeletePopupData>{ elementDescription: `${this.getPermission(item.permissionId).value} ${item.roleId}` }
        });

        dialogRef.afterClosed().subscribe((result: DeletePopupResult) => {
            if (result == 'YES') {
                this.deleteRolePermissionItemEditionExecution(item);
            }
        });
    }

    deleteRolePermissionItemEditionExecution(item: RolePermissionGrid) {
        this.serviceRolePermission.delete(item).then(res => {

            let newItem = new RolePermissionGrid(<RolePermissionGrid>res);
            let index = this.rolePermissions.findIndex(listItem => listItem.id == newItem.id);
            if (index != -1) {
                this.rolePermissions.splice(index, 1, newItem);
            }

            this._matSnackBar.open('Role permission deleted', 'OK', {
                verticalPosition: 'top',
                duration: 2000
            });

            this.selectedRolePermissionItem = null;

        });
    }

    cancelRolePermissionItemEdition() {
        this.selectedRolePermissionItem = null;
    }
    /*******************Role Permission*************************************************************** */


    /*******************Role User*************************************************************** */
    getUser(id: string) {
        return this.listUser.find(o => o.key == id);
    }

    selectedRoleUserItem: RoleUserGrid;
    selectRoleUserItem(item: RoleUserGrid) {
        this.selectedRoleUserItem = item;
    }


    newRoleUserItem() {
        let item = new RoleUserGrid({ roleId: this.currentEntity.id });
        this.roleUsers.push(item);
        this.selectRoleUserItem(item);
        this.tableRoleUser.renderRows();
    }

    saveRoleUserItem() {
        this.addRoleUserItem(this.selectedRoleUserItem);
        //debugger;
        //(this.selectedRoleUserItem && this.selectedRoleUserItem.id) ? this.updateRoleUserItem(this.selectedRoleUserItem) : this.addRoleUserItem(this.selectedRoleUserItem);
    }

    addRoleUserItem(item) {
        debugger;
        this.serviceRoleUser.add(item).then(res => {
            this.roleUsers.push(<RoleUserGrid>res);

            this._matSnackBar.open('New UserRole User saved', 'OK', {
                verticalPosition: 'top',
                duration: 2000
            });

            this.selectedRoleUserItem = null;
        });

    }

    //updateRoleUserItem(item: RoleUserGrid) {
    //    this.serviceRoleUser.update(item).then(res => {

    //        let newItem = new RoleUserGrid(<RoleUserGrid>res);
    //        let index = this.roleUsers.findIndex(listItem => listItem.id == newItem.id);
    //        if (index != -1) {
    //            this.roleUsers.splice(index, 1, newItem);
    //        }

    //        this._matSnackBar.open('UserRole Third Party Settings saved', 'OK', {
    //            verticalPosition: 'top',
    //            duration: 2000
    //        });

    //        this.selectedRoleUserItem = null;

    //    });
    //}

    deleteRoleUserItemEdition(item: RoleUserGrid) {
        const dialogRef = this.matDialog.open(DeletePopupComponent, {
            width: '250px',
            data: <DeletePopupData>{ elementDescription: `${this.getUser(item.userId).value} ${item.roleId}` }
        });

        dialogRef.afterClosed().subscribe((result: DeletePopupResult) => {
            if (result == 'YES') {
                this.deleteRoleUserItemEditionExecution(item);
            }
        });
    }

    deleteRoleUserItemEditionExecution(item: RoleUserGrid) {
        this.serviceRoleUser.update(item).then(res => {

            let newItem = new RoleUserGrid(<RoleUserGrid>res);
            let index = this.roleUsers.findIndex(listItem => listItem.id == newItem.id);
            if (index != -1) {
                this.roleUsers.splice(index, 1, newItem);
            }

            this._matSnackBar.open('Role user deleted', 'OK', {
                verticalPosition: 'top',
                duration: 2000
            });

            this.selectedRoleUserItem = null;

        });
    }

    cancelRoleUserItemEdition() {
        this.selectedRoleUserItem = null;
    }
    /*******************Role User*************************************************************** */


    disableSaveFrmMain() {
        return (this.frmMain.invalid || this.frmMain.pristine);
    }

    disableSave() {
        return this.disableSaveFrmMain();
    }
}

