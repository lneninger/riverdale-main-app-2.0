import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { HttpClient } from "@angular/common/http";
import { environment } from 'environments/environment';
import { SecureHttpClientService, OperationResponse } from "../@hipalanetCommons/authentication/securehttpclient.service";
import { BaseResolveService } from "./_base.resolve.service";



@Injectable()
export class ProductResolveService extends BaseResolveService implements Resolve<any> {
    endpoint = `${this.endpoint}product`;
    constructor(http: SecureHttpClientService) {
        super(http);
    }


}