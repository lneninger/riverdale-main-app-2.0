import {
    Component,
    OnDestroy,
    OnInit,
    ViewEncapsulation,
    ViewChild
} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Location } from '@angular/common';
import {
    MatSnackBar,
    MatPaginator,
    MatSort,
    MatTable,
    MatDialog
} from '@angular/material';
import { Subject, Observable, of } from 'rxjs';
import { takeUntil, mergeMap, switchMap } from 'rxjs/operators';
import { CustomValidators } from 'ngx-custom-validators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import { User } from './user.model';
import { UserService } from './user.service';
import { EnumItem } from '../@resolveServices/resolve.model';
import { DataSourceAbstract } from '../@hipalanetCommons/datatable/datasource.abstract.class';
import { DataSource } from '@angular/cdk/table';
import {
    DeletePopupComponent,
    DeletePopupData,
    DeletePopupResult
} from '../@hipalanetCommons/popups/delete/delete.popup.module';
import { RoleUserGrid } from '../role-users/roleuser.model';
import { RoleUserService } from '../role-users/roleuser.core.module';
import { RoleResolveService } from '../@resolveServices/resolve.module';

@Component({
    selector: 'user',
    templateUrl: './user.component.html',
    styleUrls: ['./user.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations
})
export class UserComponent implements OnInit, OnDestroy {
    // Resolve
    listRole$: Observable<EnumItem<string>[]>;

    id: string;
    currentEntity: User;
    userRoles: RoleUserGrid[];

    pageType: string;
    displayedColumnsRoleUsers = ['options', 'userId'];

    frmMain: FormGroup;
    frmPassword: FormGroup;

    selectedRoleUserItem: RoleUserGrid;

    @ViewChild('tableRoleUser')
    tableRoleUser: MatTable<RoleUserGrid>;

    // Private
    private _unsubscribeAll: Subject<any>;

    /**
     * Constructor
     *
     * @param EcommerceProductService _ecommerceProductService
     * @param FormBuilder _formBuilder
     * @param Location _location
     * @param MatSnackBar _matSnackBar
     */
    constructor(
        private route: ActivatedRoute,
        private service: UserService,
        private serviceRoleUser: RoleUserService,
        private _formBuilder: FormBuilder,
        private _location: Location,
        private _matSnackBar: MatSnackBar,
        private matDialog: MatDialog,
        private roleResolveService: RoleResolveService
    ) {
        // Set the default
        this.currentEntity = new User();

        this.listRole$ = this.roleResolveService.onList;
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
        // this.listRole = this.route.snapshot.data['listRole'];

        // Subscribe to update product on changes
        this.service.onCurrentEntityChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(dataResponse => {
                // debugger;
                this.id = dataResponse.id;
                const currentEntity = dataResponse;
                if (currentEntity) {
                    this.currentEntity = new User(currentEntity);
                    this.userRoles = (currentEntity.userRoles || []).map(
                        item => new RoleUserGrid(item)
                    );
                    this.pageType = 'edit';
                } else {
                    this.pageType = 'new';
                    this.currentEntity = new User();
                }

                this.frmMain = this.createFormBasicInfo();
                this.frmPassword = this.createFormPassword();
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
     * @returns FormGroup
     */
    createFormBasicInfo(): FormGroup {
        const result = this._formBuilder.group({
            id: [this.currentEntity.id],
            userName: [this.currentEntity.userName, [Validators.required]],
            firstName: [this.currentEntity.firstName],
            lastName: [this.currentEntity.lastName],
            email: [
                this.currentEntity.email,
                [Validators.required, Validators.email]
            ],
            pictureUrl: [this.currentEntity.pictureUrl, [CustomValidators.url]]
        });

        result.controls['userName'].disable();
        result.controls['email'].disable();

        return result;
    }

    createFormPassword(): FormGroup {
        const result = this._formBuilder.group({
            password: ['', Validators.required],
            passwordConfirm: ['', Validators.required]
        });

        result.controls['passwordConfirm'].setValidators(
            CustomValidators.equalTo(result.controls['password'])
        );

        return result;
    }

    /**
     * Save user
     */
    save(): void {
        const basicInfoData = this.frmMain.value;

        this.update(basicInfoData)
            .toPromise()
            .then(() => {
                // debugger;
                // Trigger the subscription with new data
                this.service.onCurrentEntityChanged.next(basicInfoData);

                // Show the success message
                this._matSnackBar.open('User saved', 'OK', {
                    verticalPosition: 'top',
                    duration: 5000
                });
            });
    }

    update(entity: User): Observable<User> {
        return Observable.create(observer => {
            this.service.save(entity).then((result: User) => {
                observer.next(result);
                observer.complete();
            });
        });
    }

    /**
     * Update user's password
     */
    updatePassword(): void {
        // debugger;
        const passwordData = this.frmPassword.value;

        this.service
            .updatePassword(this.id, passwordData)
            .then((result: User) => {
                this.frmPassword.reset();
                this._matSnackBar.open('Password reset was success', 'OK', {
                    verticalPosition: 'top',
                    duration: 5000
                });
            });
    }

    delete(): void {
        const dialogRef = this.matDialog.open(DeletePopupComponent, {
            width: '250px',
            data: <DeletePopupData>{
                elementDescription: this.currentEntity.userName
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
            this._matSnackBar.open('user deleted', 'OK', {
                verticalPosition: 'top',
                duration: 2000
            });

            // Change the location with new one
            this._location.go('apps/users');
        });
    }

    disableSaveFrmMain(): boolean {
        return this.frmMain.invalid || this.frmMain.pristine;
    }

    disableSave(): boolean {
        return this.disableSaveFrmMain();
    }

    /*******************Role User*************************************************************** */
    async getRole(id: string): Promise<EnumItem<string>> {
        return await this.listRole$.pipe(mergeMap(listRole => of(listRole.find(o => o.key === id)))).toPromise();
    }

    selectRoleUserItem(item: RoleUserGrid): void {
        this.selectedRoleUserItem = item;
    }

    newRoleUserItem(): void {
        const item = new RoleUserGrid({ userId: this.currentEntity.id });
        this.userRoles.push(item);
        this.selectRoleUserItem(item);
        this.tableRoleUser.renderRows();
    }

    saveRoleUserItem(): void {
        this.addRoleUserItem(this.selectedRoleUserItem);
    }

    addRoleUserItem(item): void {
        // debugger;
        this.serviceRoleUser.add(item).then(res => {
        this.tableRoleUser.renderRows();
        this._matSnackBar.open('New UserRole User saved', 'OK', {
                verticalPosition: 'top',
                duration: 2000
            });

            this.selectedRoleUserItem = null;
        });
    }

    async deleteRoleUserItemEdition(item: RoleUserGrid) {
        const userId = (await this.getRole(item.userId)).value;
        const dialogRef = this.matDialog.open(DeletePopupComponent, {
            width: '250px',
            data: <DeletePopupData>{
                elementDescription: `${userId} ${
                    item.roleId
                }`
            }
        });

        dialogRef.afterClosed().subscribe((result: DeletePopupResult) => {
            if (result === 'YES') {
                this.deleteRoleUserItemEditionExecution(item);
            }
        });
    }

    deleteRoleUserItemEditionExecution(item: RoleUserGrid): void {
        this.serviceRoleUser.update(item).then(res => {
            const newItem = new RoleUserGrid(<RoleUserGrid>res);
            const index = this.userRoles.findIndex(
                listItem => listItem.id === newItem.id
            );
            if (index !== -1) {
                this.userRoles.splice(index, 1, newItem);
            }

            this._matSnackBar.open('Role user deleted', 'OK', {
                verticalPosition: 'top',
                duration: 2000
            });

            this.selectedRoleUserItem = null;
        });
    }

    cancelRoleUserItemEdition(): void {
        this.selectedRoleUserItem = null;
    }
    /*******************Role User*************************************************************** */
}
