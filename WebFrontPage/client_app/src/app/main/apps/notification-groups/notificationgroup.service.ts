import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import * as firebase from 'firebase';


/*************************Custom***********************************/
import { AngularFireDatabase } from '@angular/fire/database';
import { AngularFireAuth } from '@angular/fire/auth';

@Injectable()
export class NotificationGroupService implements Resolve<any>
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
        , private auth: AngularFireAuth

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
                this.database.database.ref(`notification-groups/${this.routeParams.id}`).on('value', res => {
                    this.entity = res.val();
                    this.onProductChanged.next({id: res.key, entity: this.entity });
                    resolve({ id: res.key, entity: this.entity });
                }, reject);

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
            this.database.database.ref(`notification-groups/${id}`).set(entity);
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
            entity.accountId = this.auth.auth.currentUser.uid;
            entity.createdAt = firebase.database.ServerValue.TIMESTAMP;
            let id = this.database.database.ref(`notification-groups`).push().key;
            this.database.database.ref(`notification-groups/${id}`).set(entity);
            this.database.database.ref(`notification-groups/${id}`).on('value', res => {
                let result = res.val();
                resolve(result);
            });
        });
    }
}
