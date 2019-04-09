import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot, Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'environments/environment';


/*************************Custom***********************************/
//import { AngularFireDatabase } from '@angular/fire/database';
//import { AngularFireAuth } from '@angular/fire/auth';
import { IPageQueryService } from '../@hipalanetCommons/datatable/model';
import { SecureHttpClientService } from '../@hipalanetCommons/authentication/securehttpclient.service';
import { OperationResponseValued } from '../@hipalanetCommons/messages/messages.model';
import { User } from './user.model';

@Injectable()
export class UserService implements Resolve<any>, IPageQueryService {
    
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
     * @returns {Promise<any>}
     */
    getEntity(): Promise<any> {
        return new Promise((resolve, reject) => {
            this.http.get<OperationResponseValued<User>>(`${environment.appApi.apiBaseUrl}user/${this.routeParams.id}`).subscribe(response => {
                this.currentEntity = response.bag;
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
            this.http.put(`${environment.appApi.apiBaseUrl}user`, entity).subscribe(
                (res: any) => {
                resolve(res);
                },
                error => {
                    reject(error);
                });
        });
    }

    updatePassword(id: string, passwordData: { password: string, passwordConfirm: string}): any {
        return new Promise((resolve, reject) => {
            let data = {
                userId: id
                , password: passwordData.password
                , confirmPassword: passwordData.passwordConfirm
            };
            this.http.put(`${environment.appApi.apiBaseUrl}user/updatePassword`, data).subscribe(
                (res: any) => {
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
     * @param entity
     * @returns {Promise<any>}
     */
    add(entity): Promise<any> {
        return new Promise((resolve, reject) => {
            this.http.post(`${environment.appApi.apiBaseUrl}user`, entity).subscribe(
                (res: any) => {
                    resolve(res);
                },
                error => {
                    reject(error);
                });

        });
    }

    delete(id: string): any {
        return new Promise((resolve, reject) => {
            this.http.delete(`${environment.appApi.apiBaseUrl}user/${id}`).subscribe((res: any) => {
                resolve(res);
            },
            error => {
                reject(error);
            });

        });
    }

}
