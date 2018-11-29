import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot, Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'environments/environment';


/*************************Custom***********************************/
import { AngularFireDatabase } from '@angular/fire/database';
import { AngularFireAuth } from '@angular/fire/auth';
import { IPageQueryService } from '../@hipalanetCommons/datatable/model';
import { ThirdPartyGrid } from '../customerthirdpartyappsetting/customerthirdpartyappsetting.model';

@Injectable()
export class CustomerService implements Resolve<any>, IPageQueryService {
    routeParams: any;
    currentEntity: any;
    onCurrentEntityChanged: BehaviorSubject<any>;

    /**
     * Constructor
     *
     * @param {HttpClient} _httpClient
     */
    constructor(
        public http: HttpClient
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
            this.http.get(`${environment.appApi.apiBaseUrl}customer/${this.routeParams.id}`).subscribe(response => {
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
    save(id, entity): Promise<any> {
        return new Promise((resolve, reject) => {
            this.http.put(`${environment.appApi.apiBaseUrl}customer`, entity).subscribe((res: any) => {
                resolve(res);
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
            this.http.post(`${environment.appApi.apiBaseUrl}customer`, entity).subscribe((res: any) => {
                resolve(res);
            });

        });
    }


    addThirdPartyCustomer(model: ThirdPartyGrid) {
        return new Promise((resolve, reject) => {
            this.http.post(`${environment.appApi.apiBaseUrl}customer/addThirdParty`, model).subscribe((res: any) => {
                resolve(res);
            });

        });
    }

    updateThirdPartyCustomer(model: ThirdPartyGrid) {
        return new Promise((resolve, reject) => {
            this.http.post(`${environment.appApi.apiBaseUrl}customer/updateThirdParty`, model).subscribe((res: any) => {
                resolve(res);
            });

        });
    }

    removeThirdPartyCustomer(model: ThirdPartyGrid) {
        return new Promise((resolve, reject) => {
            this.http.post(`${environment.appApi.apiBaseUrl}customer/removeThirdParty`, model).subscribe((res: any) => {
                resolve(res);
            });

        });
    }
}
