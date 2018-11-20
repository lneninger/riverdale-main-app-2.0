import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'environments/environment';


/*************************Custom***********************************/
import { AngularFireDatabase } from '@angular/fire/database';
import { AngularFireAuth } from '@angular/fire/auth';

@Injectable()
export class CustomerService implements Resolve<any>
{
    routeParams: any;
    entity: any;
    onProductChanged: BehaviorSubject<any>;

    /**
     * Constructor
     *
     * @param {HttpClient} _httpClient
     */
    constructor(
        private _httpClient: HttpClient
    ) {
        // Set the defaults
        this.onProductChanged = new BehaviorSubject({});
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
            if (this.routeParams.id === 'new') {
                this.onProductChanged.next(false);
                resolve(false);
            }
            else {
                debugger;
                this._httpClient.get(`${environment.appApi.apiBaseUrl}customer/${this.routeParams.id}`).subscribe(res => {
                    resolve(res);
                });

                //this._httpClient.get('api/e-commerce-products/' + this.routeParams.id)
                //    .subscribe((response: any) => {
                //        this.product = response;
                //        this.onProductChanged.next(this.product);
                //        resolve(response);
                //    }, reject);
            }
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
            this._httpClient.put(`${environment.appApi.apiBaseUrl}customer`, entity).subscribe((res: any) => {
                debugger;
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
            this._httpClient.post(`${environment.appApi.apiBaseUrl}customer`, entity).subscribe((res: any) => {
                debugger;
                resolve(res);
            });
            
        });
    }
}
