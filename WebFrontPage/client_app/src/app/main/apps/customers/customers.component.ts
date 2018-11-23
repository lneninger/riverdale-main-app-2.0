import { Component, ElementRef, OnInit, ViewChild, ViewEncapsulation, Inject } from '@angular/core';
import { MatPaginator, MatSort, MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material';
import { DataSource } from '@angular/cdk/collections';
import { BehaviorSubject, fromEvent, merge, Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, map } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

//import { CustomersService } from './customers.service';
import { takeUntil } from 'rxjs/internal/operators';


/*************************Custom***********************************/
import { AngularFireAuth } from '@angular/fire/auth';
import { AngularFireDatabase } from '@angular/fire/database';
import { DataSourceAbstract } from '../@hipalanetCommons/datatable/datasource.abstract.class';
import { CustomerGrid, Customer } from './customer.model';
//import { CustomersListService } from './customers.list.service';
import { HttpClient } from '@angular/common/http';
import { environment } from 'environments/environment';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { CustomerService } from './customer.service';

@Component({
    selector: 'customers',
    templateUrl: './customers.component.html',
    styleUrls: ['./customers.component.scss'],
    animations: fuseAnimations,
    encapsulation: ViewEncapsulation.None
})
export class CustomersComponent implements OnInit {
    dataSource: CustomersDataSource | null;
    displayedColumns = [/*'id', 'image', */'name'/*, 'category', 'price', 'quantity', 'active'*/, 'erpId', 'salesforceId', 'createdAt', 'options'];

    @ViewChild(MatPaginator)
    paginator: MatPaginator;

    @ViewChild(MatSort)
    sort: MatSort;

    @ViewChild('filter')
    filter: ElementRef;

    // Private
    private _unsubscribeAll: Subject<any>;


    /* ******************************Custom Notification***********************************************/
    customers: any[];

    constructor(
        //private list: CustomersService
         private service: CustomerService
        //private http: HttpClient
        //private _service: CustomersService
        , private database: AngularFireDatabase
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
        this.dataSource = new CustomersDataSource(this.service, this.filter/*, this._service*/, this.paginator, this.sort);

        //fromEvent(this.filter.nativeElement, 'keyup')
        //    .pipe(
        //        takeUntil(this._unsubscribeAll),
        //        debounceTime(150),
        //        distinctUntilChanged()
        //    )
        //    .subscribe(() => {
        //        if (!this.dataSource) {
        //            return;
        //        }

        //        //this.dataSource.filter = this.filter.nativeElement.value;
        //    });
    }

    openDialog(): void {
        const dialogRef = this.dialog.open(CustomerNewDialogComponent, {
            width: '60%',
            data: {/* name: this.name, animal: this.animal */}
        });

        dialogRef.afterClosed().subscribe(result => {
            console.log('The dialog was closed with', result);
            //this.animal = result;
        });
    }
}

export class CustomersDataSource extends DataSourceAbstract<CustomerGrid>
{
    /**
     * Constructor
     *
     * @param {CustomersListService} _service
     * @param {MatPaginator} _matPaginator
     * @param {MatSort} _matSort
     */
    constructor(
        service: CustomerService
        , filterElement: ElementRef
        //, service:CustomersListService
        , matPaginator: MatPaginator
        , matSort: MatSort
    ) {
        super(service, filterElement/*, service*/, matPaginator, matSort);
    }

    remoteEnpoint: string = `${environment.appApi.apiBaseUrl}customer/pagequery`;

    public getFilter(rawFilterObject: {}): {} {


        let result = {};


        return result;
    }
}




@Component({
    selector: 'customernew-dialog',
    templateUrl: 'customernew.dialog.component.html',
})
export class CustomerNewDialogComponent {

    frmMain: FormGroup;
    constructor(
        private service: CustomerService
        , private frmBuilder: FormBuilder
        ,public dialogRef: MatDialogRef<CustomerNewDialogComponent>
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
                    this._matSnackBar.open('Customer created', 'OK', {
                        verticalPosition: 'top',
                        duration: 2000
                    });

                    resolve(res);
                })
                .catch(error => reject(error));
        });
    }

    create(): void {
        this.save().then(res => {
            this.dialogRef.close();
        });
    }

    createEdit(): void {
        this.save().then((res: Customer) => {
            this.service.router.navigate([`apps/customers/${res.id}`]);
            this.dialogRef.close();
        });
    }
}
