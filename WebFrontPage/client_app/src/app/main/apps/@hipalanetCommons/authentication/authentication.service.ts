import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { LocalStorageService, SessionStorageService } from 'ngx-webstorage';

import { Register, Authenticate, AuthenticationInfo } from "./authentication.model";
import { environment } from "environments/environment";
import { of, Observable, Subject } from "rxjs";
import { mergeMap } from "rxjs/operators";
import { SecureHttpClientService } from "./securehttpclient.service";


@Injectable()
export class AuthenticationService {

    static tokenKey = 'hipalanet|riverdale';
    onChangedUserInfo: Subject<AuthenticationInfo>;

    _userData: AuthenticationInfo;
    get userData(): AuthenticationInfo {
        return this._userData;
    }

    set userData(value: AuthenticationInfo) {
        this._userData = value;
        this.accessToken = this._userData.accessToken;
        this.onChangedUserInfo.next(this._userData);
    }

    _accessToken: string;
    get accessToken() {
        return this.localStorageService.retrieve(AuthenticationService.tokenKey);
    }

    set accessToken(accessToken) {
        this.localStorageService.store(AuthenticationService.tokenKey, accessToken);
    }

    constructor(
        private http: SecureHttpClientService
        , private localStorageService: LocalStorageService
    ) {
        this.onChangedUserInfo = new Subject<AuthenticationInfo>();
    }

    register(model: Register): Promise<any> {
        return new Promise((resolve, reject) => {
            this.http.post(`${environment.appApi.apiBaseUrl}user/register`, model).subscribe((res: any) => {
                resolve(res);
            });
        });
    }


    login(model: Authenticate): Promise<any> {
        return new Promise((resolve, reject) => {
            this.http.post(`${environment.appApi.apiBaseUrl}accounts/authenticate`, model).subscribe((res: any) => {
                this.userData = res;
                resolve(res);
            });
        });
    }

    isAuthenticated(): any {
        // debugger;
        let userDataObservable = of((this.userData || null))
            .pipe<AuthenticationInfo>(mergeMap(data => {
                // debugger;
                if (data != null) {
                    return of(data);
                }
                else if (this.accessToken) {
                    return this.retrieveAuthenticationInfo(this.accessToken);
                }
                else {
                    return of(null);
                }
            }));

        let resultPromise = userDataObservable.pipe(mergeMap(userData => {
            // debugger;

            if (this.userData == null) {
                return of(false);
            }

            if (new Date() > this.userData.expiresAt) {
                return of(false);
            }

            return of(true);
        }));


        return resultPromise;
    }

    retrieveAuthenticationInfo(token): Observable<AuthenticationInfo> {
        return Observable.create(observer => {
            this.http.get(`${environment.appApi.apiBaseUrl}accounts/authenticationInfo`).subscribe((res: any) => {
                this.userData = res;

                observer.next(res);
                observer.complete();
            });
        });
    }
}