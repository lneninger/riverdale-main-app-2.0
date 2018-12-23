import { Component, ElementRef, OnInit, ViewChild, ViewEncapsulation, Inject } from '@angular/core';
import { MatPaginator, MatSort, MatDialogRef, MAT_DIALOG_DATA, MatDialog, MatSnackBar, MatTable } from '@angular/material';
import { DataSource } from '@angular/cdk/collections';
import { BehaviorSubject, fromEvent, merge, Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, map } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import { takeUntil } from 'rxjs/internal/operators';


/*************************Custom***********************************/
//import { AngularFireAuth } from '@angular/fire/auth';
//import { AngularFireDatabase } from '@angular/fire/database';
import { DataSourceAbstract } from '../@hipalanetCommons/datatable/datasource.abstract.class';
import { UserGrid, User } from './user.model';
import { environment } from 'environments/environment';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { UserService } from './user.service';
import { AuthenticationService, Register } from '../@hipalanetCommons/authentication/authentication.core.module';
import { DeletePopupComponent, DeletePopupData, DeletePopupResult } from '../@hipalanetCommons/popups/delete/delete.popup.module';

@Component({
    selector: 'users',
    templateUrl: './users.component.html',
    styleUrls: ['./users.component.scss'],
    animations: fuseAnimations,
    encapsulation: ViewEncapsulation.None
})
export class usersComponent implements OnInit {
    dataSource: UsersDataSource | null;
    displayedColumns = ['options', 'userName', 'email', 'firstName', 'lastName'];

    @ViewChild(MatPaginator)
    paginator: MatPaginator;

    @ViewChild(MatSort)
    sort: MatSort;

    @ViewChild('filter')
    filter: ElementRef;

    // Private
    private _unsubscribeAll: Subject<any>;

    @ViewChild('tableMain')
    tableMain: MatTable<UserGrid>;

    /* ******************************Custom Notification***********************************************/
    users: any[];

    constructor(
        private service: UserService
        //, private database: AngularFireDatabase
        , private _matSnackBar: MatSnackBar
        , private matDialog: MatDialog
    ) {

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
        // debugger;
        this.dataSource = new UsersDataSource(this.service, this.filter/*, this._service*/, this.paginator, this.sort);

    }

    openDialog(): void {
        const dialogRef = this.matDialog.open(UserNewDialogComponent, {
            width: '60%',
            data: {/* name: this.name, animal: this.animal */ }
        });

        dialogRef.afterClosed().subscribe(result => {
            console.log('The dialog was closed with', result);
            debugger;
            this.dataSource.dataChanged.next('');
        });
    }

    delete(item: UserGrid) {
        const dialogRef = this.matDialog.open(DeletePopupComponent, {
            width: '250px',
            data: <DeletePopupData>{ elementDescription: `${item.email}` }
        });

        dialogRef.afterClosed().subscribe((result: DeletePopupResult) => {
            if (result == 'YES') {
                this.deleteExecution(item);
            }
        });
    }

    deleteExecution(item: UserGrid) {
        this.service.delete(item.id)
            .then(() => {

                // Show the success message
                this._matSnackBar.open('User deleted', 'OK', {
                    verticalPosition: 'top',
                    duration: 2000
                });

                //this.dataSource.filter[];
                // Change the location with new one
                //this._location.go('apps/users');

            });
    }
}

export class UsersDataSource extends DataSourceAbstract<UserGrid>
{
    /**
     * Constructor
     *
     * @param {usersListService} _service
     * @param {MatPaginator} _matPaginator
     * @param {MatSort} _matSort
     */
    constructor(
        service: UserService
        , filterElement: ElementRef
        , matPaginator: MatPaginator
        , matSort: MatSort
    ) {
        super(service, filterElement, matPaginator, matSort);
    }

    remoteEnpoint: string = `${environment.appApi.apiBaseUrl}user/pagequery`;

    public getFilter(rawFilterObject: {}): {} {


        let result = {};


        return result;
    }
}



@Component({
    selector: 'usernew-dialog',
    templateUrl: 'usernew.dialog.component.html',
})
export class UserNewDialogComponent {

    frmMain: FormGroup;
    constructor(
        private service: UserService
        , private authenticationService: AuthenticationService
        , private matSnackBar: MatSnackBar
        , private frmBuilder: FormBuilder
        , public dialogRef: MatDialogRef<UserNewDialogComponent>
        , @Inject(MAT_DIALOG_DATA) public data: any
    ) {

        this.frmMain = frmBuilder.group({
            'userName': ['', [Validators.required]],
            'firstName': ['', [Validators.required]],
            'lastName': ['', [Validators.required]],
            'email': ['', [Validators.required]],
            'password': ['', [Validators.required]],
            'confirmPassword': ['', [Validators.required]]
        });
    }

    save() {
        //debugger;
        let formData = this.frmMain.value;
        let registerData = new Register(formData);

        return new Promise((resolve, reject) => {
            this.authenticationService.register(registerData)
                .then(res => {
                    this.matSnackBar.open('User created', 'OK', {
                        verticalPosition: 'top',
                        duration: 2000
                    });

                    resolve(res);
                })
                .catch(error => reject(error));
        });
    }

    cancel(): void {
        this.dialogRef.close();
    }

    create(): void {
        this.save().then(res => {
            this.dialogRef.close();
        });
    }

    createEdit(): void {
        this.save().then((res: User) => {
            this.service.router.navigate([`apps/users/${res.id}`]);
            this.dialogRef.close();
        });
    }
}
