import { DataSource } from "@angular/cdk/table";
import { BehaviorSubject, Observable, pipe, of, fromEvent, Subject } from "rxjs";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { merge } from "rxjs";
import { map, mergeMap, takeUntil, debounceTime, distinctUntilChanged, filter } from "rxjs/operators";
import { DatatableAbstractService } from "./datatable.abstract.service";
import { PageResult, SortCollection, IPageQueryService, PageQueryData } from "./model";
import { ElementRef, NgZone } from "@angular/core";
import { HttpClient } from "@angular/common/http";



export abstract class DataSourceAbstract<T> extends DataSource<T>
{
    private _unsubscribeAll: Subject<any>;

    private _filterChange = new BehaviorSubject('');

    private _dataChanged = new BehaviorSubject('');
    get dataChanged() {
        return this._dataChanged;
    }

    private _filteredDataChange = new BehaviorSubject('');

    private _filter: { [key: string]: any; } = {};
    public get filter() {
        return this._filter;
    }

    totalCount: number;

    constructor(
        private service: IPageQueryService
        , private filterElement: ElementRef<any>
        , private _matPaginator: MatPaginator
        , private _matSort: MatSort
    ) {
        super();

        this._unsubscribeAll = new Subject();

        if (this.filterElement) {
            fromEvent(this.filterElement.nativeElement, 'keyup')
                .pipe(
                    filter(e => { /*console.log('first event: ', e); */return (<any>e).keyCode == 13 }),
                    takeUntil(this._unsubscribeAll),
                    debounceTime(150),
                    distinctUntilChanged()
                )
                .subscribe(() => {
                    this.filter.term = <string>this.filterElement.nativeElement.value;
                    this._filterChange.next(this.filter.term);
                });
        }
    }

    connect(): Observable<any[]> {
        //debugger;
        const displayDataChanges = [
            this._matPaginator.page,
            this._filterChange,
            this._dataChanged,
            this._matSort.sortChange
        ];

        return merge(...displayDataChanges)
            .pipe(
            mergeMap(() => {
                //debugger;
                    let pageIndex = this._matPaginator.pageIndex;
                    let pageSize = this._matPaginator.pageSize;
                    let sortObj = this.getSortSelection();

                    return this.getData(pageIndex, pageSize, sortObj, this.filter);
                }))
            .pipe(
                mergeMap((result: { bag: PageResult<T> }) => {
                    this.totalCount = result.bag.totalCount;
                    this._matPaginator.length = result.bag.filteredCount;
                    return of(result.bag.items);
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

    public abstract get remoteEnpoint(): string;

    getData(pageIndex: number, pageSize: number, sortObj: SortCollection, filter: {}) {
        let postData = new PageQueryData(pageIndex, pageSize, sortObj, filter);

        return this.service.http.post(this.remoteEnpoint, postData);
    }

    public abstract getFilter(rawFilterObject: {}): {};

    /**
    * Disconnect
    */
    disconnect(): void {
    }
}
