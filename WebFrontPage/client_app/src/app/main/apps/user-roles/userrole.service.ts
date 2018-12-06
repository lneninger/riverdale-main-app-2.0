import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot, Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'environments/environment';


/*************************Custom***********************************/
import { AngularFireDatabase } from '@angular/fire/database';
import { AngularFireAuth } from '@angular/fire/auth';
import { IPageQueryService } from '../@hipalanetCommons/datatable/model';
import { RolePermissionGrid } from '../role-permissions/rolepermission.core.module';
import { SecureHttpClientService } from '../@hipalanetCommons/authentication/secureHttpClient.service';

@Injectable()
export class UserRoleService implements Resolve<any>, IPageQueryService {
    
    routeParams: any;
    currentEntity: any;
    onCurrentEntityChanged: BehaviorSubject<any>;

    /**
     * Constructor
     *
     * @param {HttpClient} _httpClient
     */
    constructor(
        public http: SecureHttpClientService
        , public router: Router
    ) {
        // Set the defaults
        this.onCurrentEntityChanged = new BehaviorSubject({});
    }

    /**
     * Resolver
     *
     * @param {ActivatedRouteSnapshot} route
     * @param {RouterStateSnapshot} state
     * @returns {Observable<any> | Promise<any> | any}
     */
    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<any> | Promise<any> | any {
        this.routeParams = route.params;

        return new Promise((resolve, reject) => {

            Promise.all([
                this.getProduct()
            ]).then(
                () => {
                    resolve();
                },
                reject
            );
        });
    }

    /**
     * Get product
     *
     * @returns {Promise<any>}
     */
    getProduct(): Promise<any> {
        return new Promise((resolve, reject) => {
            this.http.get(`${environment.appApi.apiBaseUrl}userRole/${this.routeParams.id}`).subscribe(response => {
                this.currentEntity = response;
                this.onCurrentEntityChanged.next(this.currentEntity);
                resolve(this.currentEntity);
            });
        });
    }

    /**
     * Save product
     *
     * @param product
     * @returns {Promise<any>}
     */
    save(entity): Promise<any> {
        return new Promise((resolve, reject) => {
            this.http.put(`${environment.appApi.apiBaseUrl}userRole`, entity).subscribe((res: any) => {
                resolve(res);
            },
            error => {
                reject(error);
            });
        });
    }

    /**
     * Add product
     *
     * @param product
     * @returns {Promise<any>}
     */
    add(entity): Promise<any> {
        return new Promise((resolve, reject) => {
            this.http.post(`${environment.appApi.apiBaseUrl}userRole`, entity).subscribe((res: any) => {
                resolve(res);
            },
            error => {
                reject(error);
            });

        });
    }

    delete(id: number): any {
        return new Promise((resolve, reject) => {
            this.http.delete(`${environment.appApi.apiBaseUrl}userRole/{id}`).subscribe((res: any) => {
                resolve(res);
            },
            error => {
                reject(error);
            });

        });
    }

    //addThirdPartyUserRole(model: ThirdPartyGrid) {
    //    return new Promise((resolve, reject) => {
    //        this.http.post(`${environment.appApi.apiBaseUrl}userRole/addThirdParty`, model).subscribe((res: any) => {
    //            resolve(res);
    //        });

    //    });
    //}

    //updateThirdPartyUserRole(model: ThirdPartyGrid) {
    //    return new Promise((resolve, reject) => {
    //        this.http.post(`${environment.appApi.apiBaseUrl}userRole/updateThirdParty`, model).subscribe((res: any) => {
    //            resolve(res);
    //        });

    //    });
    //}

    //removeThirdPartyUserRole(model: ThirdPartyGrid) {
    //    return new Promise((resolve, reject) => {
    //        this.http.post(`${environment.appApi.apiBaseUrl}userRole/removeThirdParty`, model).subscribe((res: any) => {
    //            resolve(res);
    //        });

    //    });
    //}
}
