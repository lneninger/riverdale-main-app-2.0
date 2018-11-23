import {  } from "./datasource.abstract.class";
import { HttpClient } from "@angular/common/http";
import { SortCollection, PageQueryData } from "./model";

export abstract class DatatableAbstractService {

    constructor(http: HttpClient) {
        this._http = http;
    }

    private _http: HttpClient;
    public get http() {
        return this._http;
    }

}

