import { Injectable } from "@angular/core";
import { HttpClient, HttpHandler, HttpHeaders, HttpParams } from "@angular/common/http";

import { AuthenticationService } from "./authentication.service";
import { LocalStorageService, SessionStorageService } from 'ngx-webstorage';


@Injectable({
    providedIn: 'root'
})
export class SecureHttpClientService {

    get accessToken() {
        return this.localStorageService.retrieve(AuthenticationService.tokenKey);
    }

    constructor(
        private httpClient: HttpClient
        , private localStorageService: LocalStorageService
    ) {
    }

    addAuthorizationHeader(headers: HttpHeaders) {
        let internalHeaders = headers || new HttpHeaders();
        if (this.accessToken) {
            internalHeaders = internalHeaders.set('Authorization', `Bearer ${this.accessToken}`);
        }

        return internalHeaders;
    }

    //get(url: string, options?: CallOptions) {
    //    let internalOptions = options || <CallOptions>{};
    //    internalOptions.headers = this.addAuthorizationHeader(internalOptions.headers);
    //    return this.httpClient.get<Object>(url, internalOptions);
    //}

    get<T = Object>(url: string, options?: CallOptions) {
        let internalOptions = options || <CallOptions>{};
        internalOptions.headers = this.addAuthorizationHeader(internalOptions.headers);
        return this.httpClient.get<T>(url, internalOptions);
    }

    post<T = Object>(url: string, body: any, options?: CallOptions) {
        let internalOptions = options || <CallOptions>{};
        internalOptions.headers = this.addAuthorizationHeader(internalOptions.headers);
        return this.httpClient.post<T>(url, body, internalOptions);
    }

    put(url: string, body: any, options?: CallOptions) {
        let internalOptions = options || <CallOptions>{};
        internalOptions.headers = this.addAuthorizationHeader(internalOptions.headers);
        return this.httpClient.put(url, body, internalOptions);
    }

    delete(url: string, options?: CallOptions) {
        let internalOptions = options || <CallOptions>{};
        internalOptions.headers = this.addAuthorizationHeader(internalOptions.headers);
        return this.httpClient.delete(url, internalOptions);
    }

    head(url: string, options?: CallOptions) {
        let internalOptions = options || <CallOptions>{};
        internalOptions.headers = this.addAuthorizationHeader(internalOptions.headers);
        return this.httpClient.head(url, internalOptions);
    }

    patch(url: string, body: any, options?: CallOptions) {
        let internalOptions = options || <CallOptions>{};
        internalOptions.headers = this.addAuthorizationHeader(internalOptions.headers);
        return this.httpClient.patch(url, body, internalOptions);
    }

}


export class CallOptions {
    headers?: HttpHeaders/* | {
        [header: string]: string | string[];
    }*/;
    observe?: 'body';
    params?: HttpParams | {
        [param: string]: string | string[];
    };
    reportProgress?: boolean;
    responseType: 'json';
    withCredentials?: boolean;
}


export class OperationResponse<T extends Object> {
    bag: T

}