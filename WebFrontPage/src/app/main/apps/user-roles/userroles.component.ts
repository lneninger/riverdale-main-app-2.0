import { Component, ElementRef, OnInit, ViewChild, ViewEncapsulation, Inject } from '@angular/core';
import { MatPaginator, MatSort, MatDialogRef, MAT_DIALOG_DATA, MatDialog, MatSnackBar } from '@angular/material';
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
import { UserRoleGrid, UserRole, UserRoleNewDialogResult } from './userRole.model';
import { environment } from 'environments/environment';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { UserRoleService } from './userrole.service';
import { OperationResponseValued } from '../@hipalanetCommons/messages/messages.model';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'userRoles',
    templateUrl: './userroles.component.html',
    styleUrls: ['./userroles.component.scss'],
    animations: fuseAnimations,
    encapsulation: ViewEncapsulation.None
})
export class UserRolesComponent implements OnInit {
    dataSource: UserRolesDataSource | null;
    displayedColumns = ['name', 'options'];

    @ViewChild(MatPaginator)
    paginator: MatPaginator;

    @ViewChild(MatSort)
    sort: MatSort;

    @ViewChild('filter')
    filter: ElementRef;

    // Private
    private _unsubscribeAll: Subject<any>;


    /* ******************************Custom Notification***********************************************/
    userRoles: any[];

    constructor(
        private service: UserRoleService
        , private route: ActivatedRoute
        , public dialog: MatDialog
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
        this.dataSource = new UserRolesDataSource(this.service, this.filter/*, this._service*/, this.paginator, this.sort);

        this.initializeQueryListeners();
    }

    initializeQueryListeners() {
        this.route.queryParams.subscribe(params => {
            //debugger;
            if (this.route.snapshot.data['action'] == 'new') {
                this.openDialog();
            }
        });
    }


    openDialog(): void {
        const dialogRef = this.dialog.open(UserRoleNewDialogComponent, {
            width: '60%',
            data: {/* name: this.name, animal: this.animal */ }
        });

        dialogRef.afterClosed().subscribe((result: UserRoleNewDialogResult) => {
            if (result && result.goTo == 'Edit') {
                this.service.router.navigate([`apps/userroles/${result.data.id}`]);
            }
            else {
                this.service.router.navigate([`../`], { relativeTo: this.route });
                this.dataSource.dataChanged.next('');
            }
        });
    }
}

export class UserRolesDataSource extends DataSourceAbstract<UserRoleGrid>
{
    /**
     * Constructor
     *
     * @param {UserRolesListService} _service
     * @param {MatPaginator} _matPaginator
     * @param {MatSort} _matSort
     */
    constructor(
        service: UserRoleService
        , filterElement: ElementRef
        , matPaginator: MatPaginator
        , matSort: MatSort
    ) {
        super(service, filterElement, matPaginator, matSort);
    }

    remoteEnpoint: string = `${environment.appApi.apiBaseUrl}userRole/pagequery`;

    public getFilter(rawFilterObject: {}): {} {


        let result = {};


        return result;
    }
}



@Component({
    selector: 'userRolenew-dialog',
    templateUrl: 'userRolenew.dialog.component.html',
})
export class UserRoleNewDialogComponent {

    frmMain: FormGroup;
    constructor(
        private service: UserRoleService
        , private matSnackBar: MatSnackBar
        , private frmBuilder: FormBuilder
        , public dialogRef: MatDialogRef<UserRoleNewDialogComponent>
        , @Inject(MAT_DIALOG_DATA) public data: any
    ) {

        this.frmMain = frmBuilder.group({
            'name': ['', [Validators.required]]
        });
    }

    save() {
        return new Promise((resolve, reject) => {
            this.service.add(this.frmMain.value)
                .then(res => {
                    this.matSnackBar.open('UserRole created', 'OK', {
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
        this.save().then((res: OperationResponseValued<UserRole>) => {
            debugger;
            let result = <UserRoleNewDialogResult>{
                goTo: 'Edit',
                data: res.bag
            }
            this.dialogRef.close(result);
        });
    }
}
