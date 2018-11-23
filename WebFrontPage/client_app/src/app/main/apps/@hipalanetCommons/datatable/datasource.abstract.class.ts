import { DataSource } from "@angular/cdk/table";
import { BehaviorSubject, Observable, pipe, of, fromEvent, Subject } from "rxjs";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { merge } from "rxjs";
import { map, mergeMap, takeUntil, debounceTime, distinctUntilChanged, filter } from "rxjs/operators";
import { DatatableAbstractService } from "./datatable.abstract.service";
import { PageResult, SortCollection } from "./model";
import { ElementRef, NgZone } from "@angular/core";



export class DataSourceAbstract<T> extends DataSource<T>
{


    data: T[];
    private _unsubscribeAll: Subject<any>;
    private _filterChange = new BehaviorSubject('');
    private _filteredDataChange = new BehaviorSubject('');

    private _filter: { [key: string]: any; } = {};
    public get filter() {
        return this._filter;
    }

    //filteredCount: number;
    totalCount: number;

    constructor(
        private filterElement: ElementRef<any>
        , private _service: DatatableAbstractService
        , private _matPaginator: MatPaginator
        , private _matSort: MatSort
    ) {
        super();

        this._unsubscribeAll = new Subject();

        fromEvent(this.filterElement.nativeElement, 'keyup')
            .pipe(
            filter(e => { /*console.log('first event: ', e); */return (<any>e).keyCode == 13 }),
                takeUntil(this._unsubscribeAll),
                debounceTime(150),
                distinctUntilChanged()
            )
            .subscribe(() => {
                //debugger;
                //if (!this.dataSource) {
                //    return;
                //}

                this.filter.term = <string>this.filterElement.nativeElement.value;
                this._filterChange.next(this.filter.term);
            });

    }

    connect(): Observable<any[]> {
        //debugger;
        const displayDataChanges = [
            //this._service.onProductsChanged,
            this._matPaginator.page,
            this._filterChange,
            this._matSort.sortChange
        ];

        return merge(...displayDataChanges)
            .pipe(
                mergeMap(() => {
                    //let data = this.filteredData;
                    let pageIndex = this._matPaginator.pageIndex;
                    let pageSize = this._matPaginator.pageSize;
                    let sortObj = this.getSortSelection();

                    return this._service.getData(pageIndex, pageSize, sortObj, this.filter);
                }))
            .pipe(
                mergeMap(result => {
                    //let data = this.filteredData;
                    let pageIndex = this._matPaginator.pageIndex;
                    let pageSize = this._matPaginator.pageSize;
                    let sortObj = this.getSortSelection();

                    return this._service.getData(pageIndex, pageSize, sortObj, this.filter);
                }))

            .pipe(
                mergeMap((result: PageResult<T>) => {
                    this.totalCount = result.totalCount;
                    this.data = result.items;
                    this._matPaginator.length = result.filteredCount;
                    return of(result.items);
                }))
            ;
    }


    getSortSelection(): any {
        let result = new SortCollection();

        if (!this._matSort.active || this._matSort.direction === '') {
            return result;
        }

        result.add(this._matSort.active, this._matSort.direction);

        return result;
    }






    /**
    * Disconnect
    */
    disconnect(): void {
    }
}
