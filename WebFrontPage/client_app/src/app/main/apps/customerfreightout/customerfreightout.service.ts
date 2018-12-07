import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot, Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'environments/environment';


/*************************Custom***********************************/
import { AngularFireDatabase } from '@angular/fire/database';
import { AngularFireAuth } from '@angular/fire/auth';
import { IPageQueryService } from '../@hipalanetCommons/datatable/model';
import { CustomerFreightout } from './customerfreightout.model';
import { SecureHttpClientService } from '../@hipalanetCommons/authentication/secureHttpClient.service';

@Injectable()
export class CustomerFreightoutService implements Resolve<any>, IPageQueryService {
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
                this.getById()
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
    getById(): Promise<any> {
        return new Promise((resolve, reject) => {
            this.http.get(`${environment.appApi.apiBaseUrl}customerfreightout/${this.routeParams.id}`).subscribe(response => {
                this.currentEntity = response;
                this.onCurrentEntityChanged.next(this.currentEntity);
                resolve(this.currentEntity);
            });
        });
    }


    /**
     * Add Customer Third Party App Setting
     *
     * @param product
     * @returns {Promise<any>}
     */
    add(entity): Promise<any> {
        return new Promise((resolve, reject) => {
            this.http.post(`${environment.appApi.apiBaseUrl}customerfreightout`, entity).subscribe((res: any) => {
                resolve(res);
            });

        });
    }

    /**
     * Save Customer Third Party App Setting
     *
     * @param product
     * @returns {Promise<any>}
     */
    update(entity): Promise<any> {
        return new Promise((resolve, reject) => {
            this.http.put(`${environment.appApi.apiBaseUrl}customerfreightout`, entity).subscribe((res: any) => {
                resolve(res);
            });
        });
    }


    delete(entity): Promise<any> {
        return new Promise((resolve, reject) => {
            this.http.delete(`${environment.appApi.apiBaseUrl}customerfreightout`, entity.id).subscribe((res: any) => {
                resolve(res);
            });

        });
    }

}
