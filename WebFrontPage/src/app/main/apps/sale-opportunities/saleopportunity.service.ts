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
import { SampleBoxItem, SampleBoxProductItem, SaleOpportunity, SampleBoxProductSubItem } from './saleopportunity.model';

@Injectable()
export class SaleOpportunityService implements Resolve<any>, IPageQueryService {
    
    routeParams: any;
    currentEntity: SaleOpportunity;
    currentSampleBox: SampleBoxItem;
    currentSampleBoxProduct: SampleBoxProductItem;
    onCurrentEntityChanged: BehaviorSubject<any>;

    onSampleBoxItemAdded: Subject<SampleBoxItem> = new Subject<SampleBoxItem>();
    onSampleBoxProductItemAdded: Subject<SampleBoxProductItem> = new Subject<SampleBoxProductItem>();
    onSampleBoxProductSubItemAdded: Subject<SampleBoxProductSubItem> = new Subject<SampleBoxProductSubItem>();

    onSampleBoxItemUpdated: Subject<SampleBoxItem> = new Subject<SampleBoxItem>();
    onSampleBoxProductItemUpdated: Subject<SampleBoxProductItem> = new Subject<SampleBoxProductItem>();
    onSampleBoxProductSubItemUpdated: Subject<SampleBoxProductSubItem> = new Subject<SampleBoxProductSubItem>();

    onSampleBoxSelected: BehaviorSubject<SampleBoxItem> = new BehaviorSubject<SampleBoxItem>(null);
    onSampleBoxProductSelected: Subject<SampleBoxProductItem> = new Subject<SampleBoxProductItem>();
    onSampleBoxProductSubItemSelected: Subject<SampleBoxProductSubItem> = new Subject<SampleBoxProductSubItem>();


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
    getEntity(): Promise<SaleOpportunity> {
        return new Promise((resolve, reject) => {
            this.http
                .get<OperationResponse<SaleOpportunity>>(
                    `${environment.appApi.apiBaseUrl}saleopportunity/${this.routeParams.id}`
                )
                .subscribe(response => {
                    this.currentEntity = response.bag;
                    this.onCurrentEntityChanged.next(this.currentEntity);
                    resolve(this.currentEntity);
                }, 
                
                errorResponse => {
                    reject(errorResponse);
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

    addSampleBoxItem(item: SampleBoxItem): any {
        return new Promise((resolve, reject) => {
            this.http
                .post<OperationResponse<SampleBoxItem>>(
                    `${environment.appApi.apiBaseUrl}samplebox`,
                    item
                )
                .subscribe(
                    (res: OperationResponse<SampleBoxItem>) => {
                        const responseItem = res.bag;
                        this.onSampleBoxItemAdded.next(responseItem);
                        resolve(res);
                    },
                    error => {
                        reject(error);
                    }
                );
        });
    }

    addSampleBoxProductItem(item: SampleBoxProductItem): any {
        return new Promise((resolve, reject) => {
            this.http
                .post<OperationResponse<SampleBoxProductItem>>(
                    `${environment.appApi.apiBaseUrl}sampleboxproduct`,
                    item
                )
                .subscribe(
                    (res: OperationResponse<SampleBoxProductItem>) => {
                        const responseItem = res.bag;
                        this.onSampleBoxProductItemAdded.next(responseItem);
                        resolve(res);
                    },
                    error => {
                        reject(error);
                    }
                );
        });
    }

    updateSampleBoxItem(item: SampleBoxItem): any {
        return new Promise((resolve, reject) => {
            this.http
                .put<OperationResponse<SampleBoxItem>>(
                    `${environment.appApi.apiBaseUrl}samplebox`,
                    item
                )
                .subscribe(
                    (res: OperationResponse<SampleBoxItem>) => {
                        const responseItem = res.bag;
                        this.onSampleBoxItemUpdated.next(responseItem);
                        resolve(res);
                    },
                    error => {
                        reject(error);
                    }
                );
        });
    }


    updateSampleBoxProductItem(item: SampleBoxProductItem): any {
        return new Promise((resolve, reject) => {
            this.http
                .put<OperationResponse<SampleBoxProductItem>>(
                    `${environment.appApi.apiBaseUrl}sampleboxproduct`,
                    item
                )
                .subscribe(
                    (res: OperationResponse<SampleBoxProductItem>) => {
                        const responseItem = res.bag;
                        this.onSampleBoxProductItemUpdated.next(responseItem);
                        resolve(res);
                    },
                    error => {
                        reject(error);
                    }
                );
        });
    }

    updateSampleBoxProductSubItem(item: SampleBoxProductSubItem): any {
        return new Promise((resolve, reject) => {
            this.http
                .put<OperationResponse<SampleBoxProductSubItem>>(
                    `${environment.appApi.apiBaseUrl}sampleboxproductsubitem`,
                    item
                )
                .subscribe(
                    (res: OperationResponse<SampleBoxProductSubItem>) => {
                        const responseItem = res.bag;
                        this.onSampleBoxProductSubItemUpdated.next(responseItem);
                        resolve(res);
                    },
                    error => {
                        reject(error);
                    }
                );
        });
    }

    toggleSampleBox(sampleBox?: SampleBoxItem): any {
        this.currentSampleBox = sampleBox;
        this.onSampleBoxSelected.next(this.currentSampleBox);
    }

    toggleSampleBoxProduct(sampleBoxProduct?: SampleBoxProductItem): any {
        this.currentSampleBoxProduct = sampleBoxProduct;
        this.onSampleBoxProductSelected.next(this.currentSampleBoxProduct);
    }
}
