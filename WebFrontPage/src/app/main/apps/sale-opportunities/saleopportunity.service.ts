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
import { SampleBoxItem, SampleBoxProductItem, SaleOpportunity, TargetPriceItem, TargetPriceProductItem, TargetPriceProductSubItem } from './saleopportunity.model';
import { CompositionItem } from '../products/product.model';
import { OperationResponseValued } from '../@hipalanetCommons/messages/messages.model';

@Injectable()
export class SaleOpportunityService implements Resolve<any>, IPageQueryService {


    routeParams: any;
    currentEntity: SaleOpportunity;
    currentSampleBox: SampleBoxItem;
    currentSampleBoxProduct: SampleBoxProductItem;
    onCurrentEntityChanged: BehaviorSubject<any>;
    currentTargetPrice: TargetPriceItem;
    currentTargetPriceProduct: TargetPriceProductItem;

    onSaleOpportunityUpdated: Subject<SaleOpportunity> = new Subject<SaleOpportunity>();


    onSampleBoxItemAdded: Subject<SampleBoxItem> = new Subject<SampleBoxItem>();
    onSampleBoxProductItemAdded: Subject<SampleBoxProductItem> = new Subject<SampleBoxProductItem>();

    onSampleBoxItemUpdated: Subject<SampleBoxItem> = new Subject<SampleBoxItem>();
    onSampleBoxProductItemUpdated: Subject<SampleBoxProductItem> = new Subject<SampleBoxProductItem>();

    onSampleBoxSelected: BehaviorSubject<SampleBoxItem> = new BehaviorSubject<SampleBoxItem>(null);
    onSampleBoxProductSelected: BehaviorSubject<SampleBoxProductItem> = new BehaviorSubject<SampleBoxProductItem>(null);



    onTargetPriceItemAdded: Subject<TargetPriceItem> = new Subject<TargetPriceItem>();
    onTargetPriceProductItemAdded: Subject<TargetPriceProductItem> = new Subject<TargetPriceProductItem>();
    onTargetPriceProductSubItemAdded: Subject<CompositionItem> = new Subject<CompositionItem>();

    onTargetPriceItemUpdated: Subject<TargetPriceItem> = new Subject<TargetPriceItem>();
    onTargetPriceProductItemUpdated: Subject<TargetPriceProductItem> = new Subject<TargetPriceProductItem>();
    onTargetPriceProductSubItemUpdated: Subject<CompositionItem> = new Subject<CompositionItem>();

    onTargetPriceItemDeleted: Subject<TargetPriceItem> = new Subject<TargetPriceItem>();
    onTargetPriceProductItemDeleted: Subject<TargetPriceProductItem> = new Subject<TargetPriceProductItem>();
    onTargetPriceProductSubItemDeleted: Subject<TargetPriceProductSubItem> = new Subject<TargetPriceProductSubItem>();

    onTargetPriceSelected: BehaviorSubject<TargetPriceItem> = new BehaviorSubject<TargetPriceItem>(null);
    onTargetPriceProductSelected: BehaviorSubject<TargetPriceProductItem> = new BehaviorSubject<TargetPriceProductItem>(null);
    onTargetPriceProductSubItemSelected: BehaviorSubject<TargetPriceProductSubItem> = new BehaviorSubject<TargetPriceProductSubItem>(null);


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
    save(entity: SaleOpportunity): Promise<any> {
        const data = <SaleOpportunity>{ id: entity.id, name: entity.name, customerId: entity.customerId };
        return new Promise((resolve, reject) => {
            this.http
                .put(`${environment.appApi.apiBaseUrl}saleopportunity`, data)
                .subscribe(
                (res: OperationResponseValued<SaleOpportunity>) => {
                    this.onSaleOpportunityUpdated.next(res.bag);
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

    //updateSampleBoxProductSubItem(item: SampleBoxProductSubItem): any {
    //    return new Promise((resolve, reject) => {
    //        this.http
    //            .put<OperationResponse<SampleBoxProductSubItem>>(
    //                `${environment.appApi.apiBaseUrl}sampleboxproductsubitem`,
    //                item
    //            )
    //            .subscribe(
    //                (res: OperationResponse<SampleBoxProductSubItem>) => {
    //                    const responseItem = res.bag;
    //                    this.onSampleBoxProductSubItemUpdated.next(responseItem);
    //                    resolve(res);
    //                },
    //                error => {
    //                    reject(error);
    //                }
    //            );
    //    });
    //}

    toggleSampleBox(sampleBox?: SampleBoxItem): any {
        this.currentSampleBox = sampleBox;
        this.onSampleBoxSelected.next(this.currentSampleBox);
    }

    toggleSampleBoxProduct(sampleBoxProduct?: SampleBoxProductItem): any {
        this.currentSampleBoxProduct = sampleBoxProduct;
        this.onSampleBoxProductSelected.next(this.currentSampleBoxProduct);
    }



    addTargetPriceItem(item: TargetPriceItem): any {
        return new Promise((resolve, reject) => {
            this.http
                .post<OperationResponse<TargetPriceItem>>(
                    `${environment.appApi.apiBaseUrl}saleopportunitytargetprice`,
                    item
                )
                .subscribe(
                    (res: OperationResponse<TargetPriceItem>) => {
                        const responseItem = new TargetPriceItem(res.bag);
                        this.onTargetPriceItemAdded.next(responseItem);
                        resolve(res);
                    },
                    error => {
                        reject(error);
                    }
                );
        });
    }

    addTargetPriceProductItem(item: TargetPriceProductItem): any {
        return new Promise((resolve, reject) => {
            this.http
                .post<OperationResponse<TargetPriceProductItem>>(
                    `${environment.appApi.apiBaseUrl}saleopportunitytargetpriceproduct`,
                    item
                )
                .subscribe(
                    (res: OperationResponse<TargetPriceProductItem>) => {
                        const responseItem = new TargetPriceProductItem(res.bag);
                        this.onTargetPriceProductItemAdded.next(responseItem);
                        resolve(res);
                    },
                    error => {
                        reject(error);
                    }
                );
        });
    }

    updateTargetPriceItem(item: TargetPriceItem): any {
        return new Promise((resolve, reject) => {
            this.http
                .put<OperationResponse<TargetPriceItem>>(
                    `${environment.appApi.apiBaseUrl}saleopportunitytargetprice`,
                    item
                )
                .subscribe(
                    (res: OperationResponse<TargetPriceItem>) => {
                        const responseItem = new TargetPriceItem(res.bag);
                        this.onTargetPriceItemUpdated.next(responseItem);
                        resolve(res);
                    },
                    error => {
                        reject(error);
                    }
                );
        });
    }

    updateTargetPriceProductItem(item: TargetPriceProductItem): any {
        return new Promise((resolve, reject) => {
            this.http
                .put<OperationResponse<TargetPriceProductItem>>(
                    `${environment.appApi.apiBaseUrl}saleopportunityTargetPriceproduct`,
                    item
                )
                .subscribe(
                    (res: OperationResponse<TargetPriceProductItem>) => {
                        const responseItem = new TargetPriceProductItem(res.bag);
                        this.onTargetPriceProductItemUpdated.next(responseItem);
                        resolve(res);
                    },
                    error => {
                        reject(error);
                    }
                );
        });
    }

    deleteTargetPriceProductItem(itemId: number) {
        return new Promise((resolve, reject) => {
            this.http
                .delete(`${environment.appApi.apiBaseUrl}saleopportunityTargetPriceproduct/${itemId}`)
                .subscribe(
                    (res: any) => {
                        resolve(res);
                        const responseItem = res.bag;
                        debugger;
                        this.onTargetPriceProductItemDeleted.next(responseItem);
                    },
                    error => {
                        reject(error);
                    }
                );
        });
    }


    addTargetPriceProductSubItem(item: CompositionItem): any {
        return new Promise((resolve, reject) => {
            this.http
                .post<OperationResponse<CompositionItem>>(
                    `${environment.appApi.apiBaseUrl}productBridge`,
                    item
                )
                .subscribe(
                    (res: OperationResponse<CompositionItem>) => {
                        const responseItem = new CompositionItem(res.bag);
                        this.onTargetPriceProductSubItemAdded.next(responseItem);
                        resolve(res);
                    },
                    error => {
                        reject(error);
                    }
                );
        });
    }

    resetCache() {
        this.currentTargetPrice = null;
        this.currentTargetPriceProduct = null;

        this.onTargetPriceSelected.next(null);
        this.onTargetPriceProductSelected.next(null);
    }

    updateTargetPriceProductSubItem(item: TargetPriceProductSubItem): any {
        return new Promise((resolve, reject) => {
            this.http
                .put<OperationResponse<CompositionItem>>(
                    `${environment.appApi.apiBaseUrl}productBridge`,
                    item
                )
                .subscribe(
                    (res: OperationResponse<CompositionItem>) => {
                        const responseItem = res.bag;
                        this.onTargetPriceProductSubItemUpdated.next(responseItem);
                        resolve(res);
                    },
                    error => {
                        reject(error);
                    }
                );
        });
    }


    toggleTargetPrice(targetPrice?: TargetPriceItem): any {
        this.currentTargetPrice = targetPrice;
        this.onTargetPriceSelected.next(this.currentTargetPrice);
    }

    toggleTargetPriceProduct(targetPriceProduct?: TargetPriceProductItem): any {
        this.currentTargetPriceProduct = targetPriceProduct;
        this.onTargetPriceProductSelected.next(this.currentTargetPriceProduct);
    }
}
