


declare type SortDirection = '' | 'asc' | 'desc';
declare type SortObject = { [key: string]: SortDirection; };

export class SortCollection {

    sortObject: SortObject = {};

    add(property: string, direction: SortDirection) {
        this.sortObject[property] = direction;
    }
}



export class PageQueryData {

    customFilter: {};
    rawSort: SortCollection;

    constructor(public pageIndex: number, public pageSize: number, sort: SortCollection, filter: {}) {
        this.rawSort = sort;
        this.customFilter = filter;
    }
}


export class PageResult<T>{
    totalCount: number;
    filteredCount: number;
    items: T[];
}