import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import * as firebase from 'firebase';


/*************************Custom***********************************/
import { AngularFireDatabase } from '@angular/fire/database';

@Injectable()
export class NotificationGroupSettingsService implements Resolve<any>
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
        , private database: AngularFireDatabase
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
                (resolveArray) => {
                    resolve(resolveArray[0]);
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
            if (this.routeParams.id != null) {
                this.database.database.ref(`notification-groups/${this.routeParams.id}`).on('value', res => {
                    this.entity = res.val();
                    resolve({ id: res.key, entity: this.entity });
                }, reject);

                
            }
            else {
                resolve(null);
            }
        });
    }

}
