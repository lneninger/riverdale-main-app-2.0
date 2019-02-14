import { Injectable } from "@angular/core";
import {
    Resolve,
    ActivatedRouteSnapshot,
    RouterStateSnapshot
} from "@angular/router";
import { environment } from "environments/environment";
import {
    SecureHttpClientService,
    OperationResponse
} from "../@hipalanetCommons/authentication/securehttpclient.service";
import { EnumItem } from "./resolve.model";
import { Subject, Observable, of, merge, BehaviorSubject } from "rxjs";
import { mergeMap } from "rxjs/operators";

export abstract class BaseResolveService implements Resolve<any> {
    list: EnumItem<any>[];
    onList: BehaviorSubject<EnumItem<any>[]> = new BehaviorSubject<EnumItem<any>[]>([]);

    endpoint = `${environment.appApi.apiBaseUrl}masters/`;

    constructor(protected http: SecureHttpClientService) {}

    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<boolean> {
        return merge(this.noDependencyResolve()).pipe(
            mergeMap(() => {
                return of(true);
            })
        );
    }

    noDependencyResolve(forceReload: boolean = false): Observable<boolean> {
        if (this.list != null && !forceReload) {
            // this.onList.next(this.list);
            return of(true);
        } else {
            return Observable.create(observer => {
                this.http.get(this.endpoint).subscribe(res => {
                    // debugger;
                    this.list = (<OperationResponse<EnumItem<any>[]>>res).bag;
                    this.onList.next(this.list);
                    observer.next(true);
                    observer.complete();
                });
            });
        }
    }

    reloadCache(): void {
        // this.list = [];
        if (this.list !== null) {
            this.noDependencyResolve(true);
        }
    }
}
