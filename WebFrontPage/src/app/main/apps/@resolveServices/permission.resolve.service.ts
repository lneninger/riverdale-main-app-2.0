import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { HttpClient } from "@angular/common/http";
import { environment } from 'environments/environment';
import { SecureHttpClientService } from "../@hipalanetCommons/authentication/securehttpclient.service";
import { BaseResolveService } from "./_base.resolve.service";



@Injectable({
    providedIn: 'root'
})
export class PermissionResolveService extends BaseResolveService implements Resolve<any> {
    endpoint = `${this.endpoint}permission`;

    constructor(http: SecureHttpClientService) {
        super(http);
    }


}