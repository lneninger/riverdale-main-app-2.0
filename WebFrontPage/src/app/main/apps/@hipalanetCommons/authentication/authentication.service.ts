import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LocalStorageService, SessionStorageService } from 'ngx-webstorage';
import * as moment from 'moment';

import { Register, Authenticate, AuthenticationInfo, INavigationAccessRights } from './authentication.model';
import { environment } from 'environments/environment';
import { of, timer, Observable, Subject, Subscription, BehaviorSubject } from 'rxjs';
import { mergeMap, catchError } from 'rxjs/operators';
import { SecureHttpClientService } from './securehttpclient.service';


@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {

    static tokenKey = 'hipalanet|riverdale';
    onChangedUserInfo: BehaviorSubject<AuthenticationInfo>;
    refreshTokenSubscription: Subscription;

    _userData: AuthenticationInfo;
    get userData(): AuthenticationInfo {
        return this._userData;
    }

    set userData(value: AuthenticationInfo) {
        this._userData = value;
        if (this._userData) {
            this.accessToken = this._userData.accessToken;
        }
        else {
            this.accessToken = null;
        }

        this.onChangedUserInfo.next(this._userData);
    }

    _accessToken: string;
    get accessToken(): string {
        return this.localStorageService.retrieve(AuthenticationService.tokenKey);
    }

    set accessToken(accessToken) {
        this.localStorageService.store(AuthenticationService.tokenKey, accessToken);
    }

    constructor(
        private http: SecureHttpClientService
        , private localStorageService: LocalStorageService
    ) {
        this.onChangedUserInfo = new BehaviorSubject<AuthenticationInfo>(null);
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
                this.scheduleRefreshToken();

                resolve(res);
            },
            error => reject(error) );
        });
    }

    logout(): Promise<boolean> {
        this.accessToken = null;
        // debugger;
        this.userData = null;
        return of(true).toPromise();
    }

    isAuthenticated(): any {
        // debugger;
        const userDataObservable = of((this.userData || null))
            .pipe<AuthenticationInfo>(mergeMap(data => {
                // debugger;
                if (data != null) {
                    return of(data);
                }
                else if (this.accessToken) {
                    return this.retrieveAuthenticationInfo(this.accessToken).pipe(catchError(val => {
                        // debugger;
                        console.log('Error try to verify authenticated token');
                        return of(null);
                    }));
                }
                else {
                    return of(null);
                }
            }));
            

        const resultPromise = userDataObservable.pipe(mergeMap(userData => {
            // debugger;

            if (this.userData == null) {
                return of(false);
            }

            if (new Date() > moment(this.userData.expiresAt).toDate()) {
                return of(false);
            }

            return of(true);
        }));
        return resultPromise;
    }

    retrieveAuthenticationInfo(token?: string): Observable<AuthenticationInfo> {
        return this.http.get(`${environment.appApi.apiBaseUrl}accounts/authenticationInfo`)
            .pipe(catchError(error => {
                return of(null);
            }))
            .pipe(mergeMap(res => {
                // debugger;
                this.userData = res;
                return of(res);
            }));
    }


    public scheduleRefreshToken(): void {
        const schedule = this.isAuthenticated()
            .pipe(mergeMap(isAuthenticated => {
                if (!isAuthenticated) {
                    return of(null);
                }

                this.unscheduleRefreshToken();
                const expiresAt = moment(this.userData.expiresAt).toDate();
            }))
            .pipe(mergeMap((expiresAt: Date) => {
                if (!expiresAt) {
                    return of(null);
                }

                const now = moment();
                const expiresAtSubtracted = moment(expiresAt).subtract(30, 'seconds');
                const dateDiff = expiresAtSubtracted.diff(now);
                return timer(Math.max(1, dateDiff));
            }));


        this.refreshTokenSubscription = schedule
            .pipe(mergeMap(() => {
                return this.refreshToken();
            }))
            .subscribe(execute => {
                this.scheduleRefreshToken();
            });
    }

    unscheduleRefreshToken(): void {
        if (!this.refreshTokenSubscription)
        {
            return;
        } 

        this.refreshTokenSubscription.unsubscribe();
    }

    refreshToken = (): Observable<boolean> => {
        return Observable.create(observer => {
            this.retrieveAuthenticationInfo(this.accessToken)
                .subscribe(info => {
                    observer.next(true);
                    observer.complete();
                });
            
        });

    }

    validateNavigationPermissions(navigationItem: INavigationAccessRights): boolean {
        if (!navigationItem) {
            return true;
        }

        let permissions: string[] = [];
        let roles: string[] = [];
        let accessExtraFilter: (userInfo: AuthenticationInfo) => boolean = null;

        if (navigationItem.permissions) {
            permissions = navigationItem.permissions;
        }

        if (navigationItem.roles) {
            roles = navigationItem.roles;
        }

        if (navigationItem.accessExtraFilter) {
            accessExtraFilter = navigationItem.accessExtraFilter;
        }

        // No restriction for this route
        if (permissions.length === 0 && roles.length === 0 && accessExtraFilter == null) {
            return true;
        }

        let result = true;
        if (permissions.length > 0 || roles.length > 0) {
            const resultPermissions = permissions.length > 0 && this.userHasPermissions(permissions);
            const resultRoles = roles.length > 0 && this.userHasRoles(roles);

            result = resultPermissions || resultRoles;
        }

        if (result && accessExtraFilter != null) {
            result = accessExtraFilter(this.userData);
        }

        if (!result) {
            console.log(`No access allowed : ${JSON.stringify(permissions)}, userData: ${JSON.stringify(this.userData)}`);
        }
       

        return result;
    }

    userHasPermissions(requestedPermissions: string[], atLeastOne = true): boolean {
        const grantedPermissions = ((this.userData || <AuthenticationInfo>{}).permissions || []);

        // match all requested permissions to user profile
        if (!atLeastOne) {
            return requestedPermissions.every(requested => grantedPermissions.some(grantedPermission => grantedPermission === requested || !!grantedPermission.match(requested)));
        }
        else {
            // match one requested permissions to user profile
            return requestedPermissions.some(requested => grantedPermissions.some(grantedPermission => grantedPermission === requested || !!grantedPermission.match(requested)));
        }
    }

    userHasRoles(requestedRoles: string[], atLeastOne = true): boolean {
        const grantedRoles = ((this.userData || <AuthenticationInfo>{}).roles || []);

        if (!atLeastOne) {
            return requestedRoles.every(requested => grantedRoles.includes(requested));
        }
        else {
            // match one requested permissions to user profile
            return requestedRoles.some(requested => grantedRoles.includes(requested));
        }
    }
}
