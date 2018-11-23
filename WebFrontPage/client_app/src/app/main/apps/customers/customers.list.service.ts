import { DatatableAbstractService } from "../@hipalanetCommons/datatable/datatable.abstract.service";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from 'environments/environment';



@Injectable()
export class CustomersListService extends DatatableAbstractService {
    remoteEnpoint: string = `${environment.appApi.apiBaseUrl}customer/pagequery`;

    constructor(http: HttpClient) {
        super(http);
    }

    
    public getFilter(rawFilterObject: {}): {} {


        let result = {};


        return result;
    }
}