import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot, Router } from '@angular/router';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { environment } from 'environments/environment';


/*************************Custom***********************************/
//import { AngularFireDatabase } from '@angular/fire/database';
//import { AngularFireAuth } from '@angular/fire/auth';
import { IPageQueryService } from '../@hipalanetCommons/datatable/model';
import { SecureHttpClientService, OperationResponse } from '../@hipalanetCommons/authentication/securehttpclient.service';
import { CompositionItem } from './product.model';

@Injectable()
export class ProductService implements Resolve<any>, IPageQueryService {

    routeParams: any;
    currentEntity: any;
    onCurrentEntityChanged: BehaviorSubject<any>;


    onCompositionItemAdded: Subject<CompositionItem> = new Subject<CompositionItem>();

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
     * Get entity
     *
     * @returns {Promise<any>}
     */
    getEntity(): Promise<any> {
        return new Promise((resolve, reject) => {
            this.http.get(`${environment.appApi.apiBaseUrl}product/${this.routeParams.id}`).subscribe(response => {
                this.currentEntity = response;
                this.onCurrentEntityChanged.next(this.currentEntity);
                resolve(this.currentEntity);
            });
        });
    }

    /**
     * Save entity
     *
     * @param entity
     * @returns {Promise<any>}
     */
    save(entity): Promise<any> {
        return new Promise((resolve, reject) => {
            this.http.put(`${environment.appApi.apiBaseUrl}product`, entity).subscribe(
                (res: any) => {
                    resolve(res);
                },
                error => {
                    reject(error);
                }
            );
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
            this.http.post(`${environment.appApi.apiBaseUrl}product`, entity).subscribe(
                (res: any) => {
                    resolve(res);
                },
                error => {
                    reject(error);
                }
            );

        });
    }

    delete(id: number): any {
        return new Promise((resolve, reject) => {
            this.http.delete(`${environment.appApi.apiBaseUrl}product/{id}`).subscribe((res: any) => {
                resolve(res);
            },
            error => {
                reject(error);
            });

        });
    }

    addCompositionItem(item: CompositionItem): any {
        return new Promise((resolve, reject) => {
            this.http.post<OperationResponse<CompositionItem>>(`${environment.appApi.apiBaseUrl}productbridge`, item).subscribe((res: OperationResponse<CompositionItem>) => {
                const responseItem = res.bag; 
                this.onCompositionItemAdded.next(responseItem);
                resolve(res);
            },
                error => {
                    reject(error);
                });

        });
    }
}
