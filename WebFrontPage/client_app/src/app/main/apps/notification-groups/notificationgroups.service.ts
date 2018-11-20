import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { AngularFireDatabase } from '@angular/fire/database';
import { AngularFireAuth } from '@angular/fire/auth';

@Injectable()
export class NotificationGroupsService implements Resolve<any>
{
    list: any[];
    onProductsChanged: BehaviorSubject<any>;

    /**
     * Constructor
     *
     * @param {HttpClient} _httpClient
     */
    constructor(
        private _httpClient: HttpClient
        , private database: AngularFireDatabase
        , private auth: AngularFireAuth
    )
    {
        // Set the defaults
        this.onProductsChanged = new BehaviorSubject({});
    }

    /**
     * Resolver
     *
     * @param {ActivatedRouteSnapshot} route
     * @param {RouterStateSnapshot} state
     * @returns {Observable<any> | Promise<any> | any}
     */
    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<any> | Promise<any> | any
    {
        return new Promise((resolve, reject) => {

            Promise.all([
                this.getList()
            ]).then(
                () => {
                    resolve();
                },
                reject
            );
        });
    }

    /**
     * Get products
     *
     * @returns {Promise<any>}
     */
    getList(): Promise<any>
    {
        return new Promise((resolve, reject) => {
            this.auth.auth.onAuthStateChanged(user => {
                debugger;
                this.database.database.ref('accounts').orderByChild("userId").equalTo(user.uid).once('value', snapshot => {
                    //debugger;
                    let accountId = Object.getOwnPropertyNames(snapshot.val())[0];

                    this.database.database.ref('notification-groups').orderByChild("accountId").equalTo(accountId).limitToFirst(1).once('value', res => {
                        //debugger;
                        let resData = res.val() || {};
                        let list = [];
                        for (let property in resData) {
                            list.push({ id: property, data: resData[property] });
                        }

                        // debugger;

                        this.list = list;
                        this.onProductsChanged.next(this.list);
                        resolve(this.list);
                    });
                });
                
            });



            //this._httpClient.get('api/e-commerce-products')
            //    .subscribe((response: any) => {
            //        this.products = response;
            //        this.onProductsChanged.next(this.products);
            //        resolve(response);
            //    }, reject);
        });
    }
}
