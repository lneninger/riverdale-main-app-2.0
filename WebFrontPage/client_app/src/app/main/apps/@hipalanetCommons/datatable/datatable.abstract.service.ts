import {  } from "./datasource.abstract.class";
import { HttpClient } from "@angular/common/http";
import { SortCollection, PageQueryData } from "./model";
import { SecureHttpClientService } from "../authentication/secureHttpClient.service";

export abstract class DatatableAbstractService {

    constructor(http: SecureHttpClientService) {
        this._http = http;
    }

    private _http: SecureHttpClientService;
    public get http() {
        return this._http;
    }

}

