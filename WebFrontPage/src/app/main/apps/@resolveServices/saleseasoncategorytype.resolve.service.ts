import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { environment } from 'environments/environment';
import { SecureHttpClientService, OperationResponse } from "../@hipalanetCommons/authentication/securehttpclient.service";
import { BaseResolveService } from "./_base.resolve.service";



@Injectable({
    providedIn: 'root'
})
export class SaleSeasonCategoryTypeResolveService extends BaseResolveService implements Resolve<any> {
    endpoint = `${this.endpoint}seasonCategoryWithSeasons`;

    constructor(http: SecureHttpClientService) {
        super(http);
    }

}