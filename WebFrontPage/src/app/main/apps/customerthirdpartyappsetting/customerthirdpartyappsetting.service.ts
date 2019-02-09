import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot, Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'environments/environment';


/*************************Custom***********************************/
import { IPageQueryService } from '../@hipalanetCommons/datatable/model';
import { ThirdPartyGrid } from './customerthirdpartyappsetting.model';
import { SecureHttpClientService } from '../@hipalanetCommons/authentication/securehttpclient.service';

@Injectable()
export class CustomerThirdPartyAppSettingService implements Resolve<any>, IPageQueryService {
    routeParams: any;
    currentEntity: any;
    onCurrentEntityChanged: BehaviorSubject<any>;

    /**
     * Constructor
     *
     * @param _httpClient HttpClient Provider
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
     * @param route Current route
     * @param state Current state
     * @returns Resolve data result
     */
    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<any> | Promise<any> | any {
        this.routeParams = route.params;

        return new Promise((resolve, reject) => {

            Promise.all([
                this.getEntity()
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
     * @returns Entity
     */
    getEntity(): Promise<any> {
        return new Promise((resolve, reject) => {
            this.http.get(`${environment.appApi.apiBaseUrl}customerthirdpartyappsetting/${this.routeParams.id}`).subscribe(response => {
                this.currentEntity = response;
                this.onCurrentEntityChanged.next(this.currentEntity);
                resolve(this.currentEntity);
            });
        });
    }


    /**
     * Add Customer Third Party App Setting
     *
     * @param product Product
     * @returns Entity
     */
    add(entity): Promise<any> {
        return new Promise((resolve, reject) => {
            this.http.post(`${environment.appApi.apiBaseUrl}customerthirdpartyappsetting`, entity).subscribe((res: any) => {
                resolve(res);
            });

        });
    }

    /**
     * Save Customer Third Party App Setting
     *
     * @param product Product
     * @returns Update Product Result
     */
    update(entity): Promise<any> {
        return new Promise((resolve, reject) => {
            this.http.put(`${environment.appApi.apiBaseUrl}customerthirdpartyappsetting`, entity).subscribe((res: any) => {
                resolve(res);
            });
        });
    }


    delete(entity): Promise<any> {
        return new Promise((resolve, reject) => {
            this.http.delete(`${environment.appApi.apiBaseUrl}customerthirdpartyappsetting`, entity.id).subscribe((res: any) => {
                resolve(res);
            });

        });
    }

}
