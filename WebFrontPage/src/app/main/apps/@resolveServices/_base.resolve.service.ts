import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { environment } from 'environments/environment';
import { SecureHttpClientService, OperationResponse } from '../@hipalanetCommons/authentication/securehttpclient.service';
import { EnumItem } from './resolve.model';
import { Subject } from 'rxjs';

export abstract class BaseResolveService implements Resolve<any> {
    list: EnumItem<any>[] = null;
    onList: Subject<EnumItem<any>[]> = new Subject<EnumItem<any>[]>();

    endpoint = `${environment.appApi.apiBaseUrl}masters/`;

    constructor(protected http: SecureHttpClientService) { }

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<EnumItem<any>[]> {
        return this.noDependencyResolve();
    }

    noDependencyResolve(forceReload: boolean = false): Promise<EnumItem<any>[]> {
        if (this.list != null && !forceReload) {
            return Promise.resolve(this.list);
        }
        else {
            return new Promise<EnumItem<any>[]>((resolve, reject) => {
                this.http.get(this.endpoint).toPromise()
                    .then(res => {
                        // debugger;
                        this.list = (<OperationResponse<EnumItem<any>[]>>res).bag;
                        resolve(this.list);
                    })
                    .catch(error => reject(error));
            });
        }
    }


    clearCache(): void {
        // this.list = [];
        if (this.list !== null) {
            this.noDependencyResolve(true).then((o: EnumItem<any>[]) => {
                this.onList.next(o);
            });
        }
    }

}
