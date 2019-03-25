import { Injectable } from '@angular/core';
import {
    Resolve,
    ActivatedRouteSnapshot,
    RouterStateSnapshot
} from '@angular/router';
import { environment } from 'environments/environment';
import {
    SecureHttpClientService,
    OperationResponse
} from '../@hipalanetCommons/authentication/securehttpclient.service';
import { EnumItem } from './resolve.model';
import { Subject, Observable, of, merge, BehaviorSubject } from 'rxjs';
import { mergeMap } from 'rxjs/operators';

export abstract class BaseResolveService<T = EnumItem<any>[]> implements Resolve<any> {
    list: T;
    onList: BehaviorSubject<T> = new BehaviorSubject<T>((<T><unknown>[] || <T>{} ));

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
                    this.list = (<OperationResponse<T>>res).bag;
                    console.log(`List Resolved`, this.list);
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
