import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { environment } from 'environments/environment';
import { SecureHttpClientService, OperationResponse } from "../@hipalanetCommons/authentication/securehttpclient.service";
import { CustomerResolveService } from "./customer.resolve.service";
import { SignalRService } from "../@hipalanetCommons/signalr/signalr.module";
import { ISignalREventArgs } from "../@hipalanetCommons/signalr/signalr.model";
import { Subscription } from "rxjs";
import { ProductResolveService } from "./product.resolve.service";



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


    configureListeners() {
        this.dataChangedSubscription = this.signalrService.onDataChanged.subscribe((eventData: ISignalREventArgs) => {
            switch (eventData.entityName) {
                case 'Customer':
                    //debugger;
                    this.customerResolveService.clearCache();
                    break;
                case 'Product':
                case 'ProductMedia':
                    //debugger;
                    this.productResolveService.clearCache();
                    break;
            }
        })
    }
}