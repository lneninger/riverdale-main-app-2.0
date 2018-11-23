import { Component, ElementRef, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { DataSource } from '@angular/cdk/collections';
import { BehaviorSubject, fromEvent, merge, Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, map } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import { CustomersService } from './customers.service';
import { takeUntil } from 'rxjs/internal/operators';


/*************************Custom***********************************/
import { AngularFireAuth } from '@angular/fire/auth';
import { AngularFireDatabase } from '@angular/fire/database';
import { DataSourceAbstract } from '../@hipalanetCommons/datatable/datasource.abstract.class';
import { CustomerGrid } from './customer.model';
import { CustomersListService } from './customers.list.service';

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
        private _service: CustomersListService
        //private _service: CustomersService
        , private database: AngularFireDatabase
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
        this.dataSource = new CustomersDataSource(this.filter, this._service, this.paginator, this.sort);

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
        //private database: AngularFireDatabase
        filterElement: ElementRef
        , service:CustomersListService
        , matPaginator: MatPaginator
        , matSort: MatSort
    ) {
        super(filterElement, service, matPaginator, matSort);
    }

}
