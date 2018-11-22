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
    displayedColumns = [/*'id', 'image', */'name'/*, 'category', 'price', 'quantity', 'active'*/, 'erpId', 'createdAt', 'options'];

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

        fromEvent(this.filter.nativeElement, 'keyup')
            .pipe(
                takeUntil(this._unsubscribeAll),
                debounceTime(150),
                distinctUntilChanged()
            )
            .subscribe(() => {
                if (!this.dataSource) {
                    return;
                }

                //this.dataSource.filter = this.filter.nativeElement.value;
            });
    }
}

export class CustomersDataSource extends DataSourceAbstract<CustomerGrid>
//export class CustomersDataSource extends DataSource<any>
{
    //private _filterChange = new BehaviorSubject('');
    //private _filteredDataChange = new BehaviorSubject('');

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


        //this.filteredData = this._service.list;

        

    }

    /**
     * Connect function called by the table to retrieve one stream containing the data to render.
     *
     * @returns {Observable<any[]>}
     */
    //connect(): Observable<any[]> {
    //    // debugger;
    //    const displayDataChanges = [
    //         //this._service.onProductsChanged,
    //        this._matPaginator.page,
    //        this._filterChange,
    //        this._matSort.sortChange
    //    ];

    //    return merge(...displayDataChanges)
    //        .pipe(
    //            map(() => {
    //                let data = this.filteredData;

    //                data = this.filterData(data);

    //                this.filteredData = [...data];

    //                data = this.sortData(data);

    //                // Grab the page's slice of data.
    //                const startIndex = this._matPaginator.pageIndex * this._matPaginator.pageSize;
    //                return data.splice(startIndex, this._matPaginator.pageSize);
    //            }
    //            ));
    //}

    // -----------------------------------------------------------------------------------------------------
    // @ Accessors
    // -----------------------------------------------------------------------------------------------------

    // Filtered data
    //get filteredData(): any {
    //    return this._filteredDataChange.value;
    //}

    //set filteredData(value: any) {
    //    this._filteredDataChange.next(value);
    //}

    //// Filter
    //get filter(): string {
    //    return this._filterChange.value;
    //}

    //set filter(filter: string) {
    //    this._filterChange.next(filter);
    //}

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * Filter data
     *
     * @param data
     * @returns {any}
     */
    //filterData(data): any {
    //    if (!this.filter) {
    //        return data;
    //    }
    //    return FuseUtils.filterArrayByString(data, this.filter);
    //}

    /**
     * Sort data
     *
     * @param data
     * @returns {any[]}
     */
    //sortData(data): any[] {
    //    if (!this._matSort.active || this._matSort.direction === '') {
    //        return data;
    //    }

    //    return data.sort((a, b) => {
    //        let propertyA: number | string = '';
    //        let propertyB: number | string = '';

    //        switch (this._matSort.active) {
    //            case 'id':
    //                [propertyA, propertyB] = [a.id, b.id];
    //                break;
    //            case 'name':
    //                [propertyA, propertyB] = [a.name, b.name];
    //                break;
    //            case 'categories':
    //                [propertyA, propertyB] = [a.categories[0], b.categories[0]];
    //                break;
    //            case 'price':
    //                [propertyA, propertyB] = [a.priceTaxIncl, b.priceTaxIncl];
    //                break;
    //            case 'quantity':
    //                [propertyA, propertyB] = [a.quantity, b.quantity];
    //                break;
    //            case 'active':
    //                [propertyA, propertyB] = [a.active, b.active];
    //                break;
    //        }

    //        const valueA = isNaN(+propertyA) ? propertyA : +propertyA;
    //        const valueB = isNaN(+propertyB) ? propertyB : +propertyB;

    //        return (valueA < valueB ? -1 : 1) * (this._matSort.direction === 'asc' ? 1 : -1);
    //    });
    //}

    
   
}
