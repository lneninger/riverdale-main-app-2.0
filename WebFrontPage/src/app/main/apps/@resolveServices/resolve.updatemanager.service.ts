import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { environment } from 'environments/environment';
import { SecureHttpClientService, OperationResponse } from '../@hipalanetCommons/authentication/securehttpclient.service';
import { CustomerResolveService } from './customer.resolve.service';
import { SignalRService } from '../@hipalanetCommons/signalr/signalr.module';
import { ISignalREventArgs } from '../@hipalanetCommons/signalr/signalr.model';
import { Subscription, pipe, of, merge } from 'rxjs';
import { ProductResolveService } from './product.resolve.service';
import {  mergeMap } from 'rxjs/operators';



@Injectable({ providedIn: 'root' })
export class ResolveUpdateManagerService {
    dataChangedSubscription: Subscription;

    constructor(
        private customerResolveService: CustomerResolveService
        , private productResolveService: ProductResolveService

        , private signalrService: SignalRService
    ) {
        this.configureListeners();
    }


    configureListeners(): void {
        const productEvents = [
            this.signalrService.onProductDataChanged
            , this.signalrService.onProductMediaDataChanged
            , this.signalrService.onProductAllowedColorDataChanged
        ];

        merge(...productEvents)
        .subscribe((eventData: ISignalREventArgs) => {
            this.productResolveService.reloadCache();
        });

        const customerEvents = [
            this.signalrService.onCustomerDataChanged
        ];
        merge(...customerEvents)
        .subscribe((eventData: ISignalREventArgs) => {
            this.customerResolveService.reloadCache();
        });

    }
}
