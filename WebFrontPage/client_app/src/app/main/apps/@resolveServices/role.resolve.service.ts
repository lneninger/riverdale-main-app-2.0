import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { environment } from 'environments/environment';
import { SecureHttpClientService, OperationResponse } from "../@hipalanetCommons/authentication/securehttpclient.service";
import { BaseResolveService } from "./_base.resolve.service";



@Injectable()
export class RoleResolveService extends BaseResolveService implements Resolve<any> {
    list: any[];
    endpoint = `${this.endpoint}role`;

    constructor(http: SecureHttpClientService) {
        super(http);
    }

}