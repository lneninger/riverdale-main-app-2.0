import { Injectable } from "@angular/core";
import { HttpClient, HttpHandler, HttpHeaders, HttpParams } from "@angular/common/http";

import { AuthenticationService } from "./authentication.service";
import { LocalStorageService, SessionStorageService } from 'ngx-webstorage';
import { Observable } from "rxjs";


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

    //addPostContentTypeHeader(headers: HttpHeaders) {
    //    let internalHeaders = headers || new HttpHeaders();
    //    internalHeaders = internalHeaders.set('Content-Type', 'application/x-www-form-urlencoded');

    //    return internalHeaders;
    //}

    //addOriginHeader(headers: HttpHeaders) {
    //    let internalHeaders = headers || new HttpHeaders();
    //    console.log(`${window.location.origin}`);
    //    internalHeaders = internalHeaders.set('Access-Control-Allow-Origin', window.location.origin);

    //    return internalHeaders;
    //}

    //addWithCredentialsOption(options: CallOptions) {
    //    options.withCredentials = true;
    //}
    //get(url: string, options?: CallOptions) {
    //    let internalOptions = options || <CallOptions>{};
    //    internalOptions.headers = this.addAuthorizationHeader(internalOptions.headers);
    //    return this.httpClient.get<Object>(url, internalOptions);
    //}

    get<T = Object>(url: string, options?: CallOptions): Observable<T> {
        let internalOptions = options || <CallOptions>{};
        //this.addWithCredentialsOption(internalOptions);
        internalOptions.headers = this.addAuthorizationHeader(internalOptions.headers);
        //internalOptions.headers = this.addOriginHeader(internalOptions.headers);
        return this.httpClient.get<T>(url, internalOptions);
    }

    post<T = Object>(url: string, body: any, options?: CallOptions): Observable<T> {
        let internalOptions = options || <CallOptions>{};
        //this.addWithCredentialsOption(internalOptions);
        internalOptions.headers = this.addAuthorizationHeader(internalOptions.headers);
        //internalOptions.headers = this.addOriginHeader(internalOptions.headers);
        //internalOptions.headers = this.addPostContentTypeHeader(internalOptions.headers);
        //debugger;
        return this.httpClient.post<T>(url, body, internalOptions);
    }

    put<T = Object>(url: string, body: any, options?: CallOptions): Observable<T> {
        let internalOptions = options || <CallOptions>{};
        //this.addWithCredentialsOption(internalOptions);
        //internalOptions.headers = this.addOriginHeader(internalOptions.headers);
        internalOptions.headers = this.addAuthorizationHeader(internalOptions.headers);
        return this.httpClient.put<T>(url, body, internalOptions);
    }

    delete(url: string, options?: CallOptions) {
        let internalOptions = options || <CallOptions>{};
        //internalOptions.headers = this.addOriginHeader(internalOptions.headers);
        internalOptions.headers = this.addAuthorizationHeader(internalOptions.headers);
        return this.httpClient.delete(url, internalOptions);
    }

    head(url: string, options?: CallOptions) {
        let internalOptions = options || <CallOptions>{};
        //this.addWithCredentialsOption(internalOptions);
        //internalOptions.headers = this.addOriginHeader(internalOptions.headers);
        internalOptions.headers = this.addAuthorizationHeader(internalOptions.headers);
        return this.httpClient.head(url, internalOptions);
    }

    patch(url: string, body: any, options?: CallOptions) {
        let internalOptions = options || <CallOptions>{};
        //this.addWithCredentialsOption(internalOptions);
        //internalOptions.headers = this.addOriginHeader(internalOptions.headers);
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