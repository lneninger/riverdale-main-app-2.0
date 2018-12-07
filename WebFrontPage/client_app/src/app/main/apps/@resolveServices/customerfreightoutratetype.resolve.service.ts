import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { HttpClient } from "@angular/common/http";
import { environment } from 'environments/environment';
import { SecureHttpClientService, OperationResponse } from "../@hipalanetCommons/authentication/securehttpclient.service";



@Injectable()
export class CustomerFreightoutRateTypeResolveService implements Resolve<any> {
    list: any[];
    endpoint = `${environment.appApi.apiBaseUrl}masters/customerfreightoutratetype`;

    constructor(private http: SecureHttpClientService) { }

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (this.list != null) {
            return Promise.resolve(this.list);
        }
        else {
            return new Promise((resolve, reject) => {
                this.http.get(this.endpoint).toPromise()
                    .then(res => {
                        this.list = (<OperationResponse<any[]>>res).bag;
                        resolve(this.list);
                    })
                    .catch(error => reject(error));
            });
        }
    }


}