import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {
    ActivatedRouteSnapshot,
    Resolve,
    RouterStateSnapshot,
    Router
} from '@angular/router';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { environment } from 'environments/environment';

/*************************Custom***********************************/
import { IPageQueryService } from '../@hipalanetCommons/datatable/model';
import {
    SecureHttpClientService,
    OperationResponse
} from '../@hipalanetCommons/authentication/securehttpclient.service';
import { SaleOpportunityItem } from './saleopportunity.model';

@Injectable()
export class SaleOpportunityService implements Resolve<any>, IPageQueryService {
    routeParams: any;
    currentEntity: any;
    onCurrentEntityChanged: BehaviorSubject<any>;

    onSaleOpportunityItemAdded: Subject<SaleOpportunityItem> = new Subject<
        SaleOpportunityItem
    >();
    onSaleOpportunityItemUpdated: Subject<SaleOpportunityItem> = new Subject<
        SaleOpportunityItem
    >();

    /**
     * Constructor
     *
     * @param _httpClient Http Client
     */
    constructor(public http: SecureHttpClientService, public router: Router) {
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
    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<any> | Promise<any> | any {
        this.routeParams = route.params;

        return new Promise((resolve, reject) => {
            Promise.all([this.getEntity()]).then(() => {
                resolve();
            }, reject);
        });
    }

    /**
     * Get entity
     *
     * @returns Get entity
     */
    getEntity(): Promise<any> {
        return new Promise((resolve, reject) => {
            this.http
                .get(
                    `${environment.appApi.apiBaseUrl}saleopportunity/${
                        this.routeParams.id
                    }`
                )
                .subscribe(response => {
                    this.currentEntity = response;
                    this.onCurrentEntityChanged.next(this.currentEntity);
                    resolve(this.currentEntity);
                });
        });
    }

    /**
     * Save entity
     *
     * @param entity Item to save
     * @returns Save result
     */
    save(entity): Promise<any> {
        return new Promise((resolve, reject) => {
            this.http
                .put(`${environment.appApi.apiBaseUrl}saleopportunity`, entity)
                .subscribe(
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
     * @param product Product
     * @returns Add entity
     */
    add(entity): Promise<any> {
        return new Promise((resolve, reject) => {
            this.http
                .post(`${environment.appApi.apiBaseUrl}saleopportunity`, entity)
                .subscribe(
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
            this.http
                .delete(`${environment.appApi.apiBaseUrl}saleopportunity/{id}`)
                .subscribe(
                    (res: any) => {
                        resolve(res);
                    },
                    error => {
                        reject(error);
                    }
                );
        });
    }

    addSaleOpportunityProductItem(item: SaleOpportunityItem): any {
        return new Promise((resolve, reject) => {
            this.http
                .post<OperationResponse<SaleOpportunityItem>>(
                    `${environment.appApi.apiBaseUrl}saleopportunityproduct`,
                    item
                )
                .subscribe(
                    (res: OperationResponse<SaleOpportunityItem>) => {
                        const responseItem = res.bag;
                        this.onSaleOpportunityItemAdded.next(responseItem);
                        resolve(res);
                    },
                    error => {
                        reject(error);
                    }
                );
        });
    }

    updateSaleOpportunityProductItem(item: SaleOpportunityItem): any {
        return new Promise((resolve, reject) => {
            this.http
                .put<OperationResponse<SaleOpportunityItem>>(
                    `${environment.appApi.apiBaseUrl}saleopportunityproduct`,
                    item
                )
                .subscribe(
                    (res: OperationResponse<SaleOpportunityItem>) => {
                        const responseItem = res.bag;
                        this.onSaleOpportunityItemUpdated.next(responseItem);
                        resolve(res);
                    },
                    error => {
                        reject(error);
                    }
                );
        });
    }
}
