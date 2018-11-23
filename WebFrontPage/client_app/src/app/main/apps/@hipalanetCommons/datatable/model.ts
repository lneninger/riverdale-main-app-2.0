import { HttpClient } from "@angular/common/http";



declare type SortDirection = '' | 'asc' | 'desc';
declare type SortObject = { [key: string]: SortDirection; };

export class SortCollection {

    sortObject: SortObject = {};

    add(property: string, direction: SortDirection) {
        this.sortObject[property] = direction;
    }
}


export interface IPageQueryService {
    http: HttpClient,
}


export class PageQueryData {

    customFilter: {};
    sort: SortObject;

    constructor(public pageIndex: number, public pageSize: number, sortCollection: SortCollection, filter: {}) {
        this.sort = sortCollection.sortObject;
        this.customFilter = filter;
    }
}


export class PageResult<T>{
    totalCount: number;
    filteredCount: number;
    items: T[];
}