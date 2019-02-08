import { HttpClient } from '@angular/common/http';
import { SecureHttpClientService } from '../authentication/securehttpclient.service';



declare type SortDirection = '' | 'asc' | 'desc';
declare type SortObject = { 
    [key: string]: SortDirection; 
};

export class SortCollection {

    sortObject: SortObject = {};

    add(property: string, direction: SortDirection): void {
        this.sortObject[property] = direction;
    }
}


export interface IPageQueryService {
    http: SecureHttpClientService;
}


export class PageQueryData {

    customFilter: {};
    sort: SortObject;

    constructor(public pageIndex: number, public pageSize: number, sortCollection: SortCollection, filter: any) {
        this.sort = sortCollection.sortObject;
        this.customFilter = filter;
    }
}


export class PageResult<T>{
    totalCount: number;
    filteredCount: number;
    items: T[];
}

