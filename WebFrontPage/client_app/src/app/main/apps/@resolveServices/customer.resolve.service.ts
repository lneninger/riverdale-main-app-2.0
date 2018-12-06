import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { HttpClient } from "@angular/common/http";
import { environment } from 'environments/environment';
import { SecureHttpClientService } from "../@hipalanetCommons/authentication/secureHttpClient.service";



@Injectable()
export class ThirdPartyAppTypeResolveService implements Resolve<any> {
    protected _list: any[];
    public get list() {
        return this._list;
    }

    public set list(value) {
        this._list = value;
    }

    endpoint = `${environment.appApi.apiBaseUrl}masters/customer`;

    constructor(private http: SecureHttpClientService) {

    }

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (this.list != null) {
            return Promise.resolve(this.list);
        }
        else {
            return new Promise((resolve, reject) => {
                this.http.get(this.endpoint).toPromise()
                    .then(res => {
                        this.list = <any[]>res;
                        resolve(res);
                    })
                    .catch(error => reject(error));
            });
        }
    }

    clearCache() {
        this.list = [];
    }


}