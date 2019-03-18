import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { HttpClient } from "@angular/common/http";
import { environment } from 'environments/environment';
import { SecureHttpClientService, OperationResponse } from "../@hipalanetCommons/authentication/securehttpclient.service";
import { BaseResolveService } from "./_base.resolve.service";



@Injectable({
providedIn: 'root'
})
export class EnvironmentResolveService extends BaseResolveService implements Resolve<any> {
    
    endpoint = `${environment.appApi.apiBaseUrl}environment`;

    constructor(http: SecureHttpClientService) {
        super(http);
    }


}