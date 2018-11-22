import { DatatableAbstractService } from "../@hipalanetCommons/datatable/datatable.abstract.service";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";



@Injectable()
export class CustomersListService extends DatatableAbstractService {
    remoteEnpoint: string;

    constructor(http: HttpClient) {
        super(http);
    }

    public getFilter(rawFilterObject: {}): {} {


        let result = {};


        return result;
    }
}