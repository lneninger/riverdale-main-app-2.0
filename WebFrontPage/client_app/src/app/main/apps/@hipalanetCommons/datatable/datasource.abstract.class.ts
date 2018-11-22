import { DataSource } from "@angular/cdk/table";
import { BehaviorSubject, Observable, pipe, of } from "rxjs";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { merge } from "rxjs";
import { map, mergeMap } from "rxjs/operators";
import { DatatableAbstractService } from "./datatable.abstract.service";
import { PageResult, SortCollection } from "./model";
import { ElementRef } from "@angular/core";



export class DataSourceAbstract<T> extends DataSource<T>
{
   
    
    private _filterChange = new BehaviorSubject('');
    private _filteredDataChange = new BehaviorSubject('');

    private _filter: {} = {};
    public get filter() {
        return this._filter;
    }

    filteredCount: number;
    totalCount: number;

    constructor(
        private filterElement: ElementRef
        , private _service: DatatableAbstractService
        , private _matPaginator: MatPaginator
        , private _matSort: MatSort
    ) {
        super();


        //this.filteredData = this._service.list;

    }

    connect(): Observable<any[]> {
        // debugger;
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
                mergeMap((result:PageResult<T>) => {
                    //let data = this.filteredData;
                this.totalCount = result.totalCount;
                this.filteredCount = result.filteredCount;
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
