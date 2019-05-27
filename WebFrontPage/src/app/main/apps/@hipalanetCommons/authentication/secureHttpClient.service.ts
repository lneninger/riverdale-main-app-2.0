import { Injectable } from '@angular/core';
import {
    HttpClient,
    HttpHandler,
    HttpHeaders,
    HttpParams
} from '@angular/common/http';

import { AuthenticationService } from './authentication.service';
import { LocalStorageService, SessionStorageService } from 'ngx-webstorage';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class SecureHttpClientService {
    get accessToken(): string {
        return this.localStorageService.retrieve(
            AuthenticationService.tokenKey
        );
    }

    constructor(
        private httpClient: HttpClient,
        private localStorageService: LocalStorageService
    ) {}

    addAuthorizationHeader(headers: HttpHeaders): HttpHeaders {
        let internalHeaders = headers || new HttpHeaders();
        if (this.accessToken) {
            internalHeaders = internalHeaders.set(
                'Authorization',
                `Bearer ${this.accessToken}`
            );
        }

        return internalHeaders;
    }

    addPostContentTypeHeaderForApplicationJson(
        headers: HttpHeaders
    ): HttpHeaders {
        return this.addPostContentTypeHeader(headers, 'application/json');
    }

    addPostContentTypeHeader(
        headers: HttpHeaders,
        contentType: string
    ): HttpHeaders {
        let internalHeaders = headers || new HttpHeaders();
        internalHeaders = internalHeaders.set(
            'Content-Type',
            contentType /*'application/x-www-form-urlencoded'*/
        );

        return internalHeaders;
    }

    // addOriginHeader(headers: HttpHeaders) {
    //    let internalHeaders = headers || new HttpHeaders();
    //    console.log(`${window.location.origin}`);
    //    internalHeaders = internalHeaders.set('Access-Control-Allow-Origin', window.location.origin);

    //    return internalHeaders;
    // }

    // addWithCredentialsOption(options: CallOptions) {
    //    options.withCredentials = true;
    // }
    // get(url: string, options?: CallOptions) {
    //    let internalOptions = options || <CallOptions>{};
    //    internalOptions.headers = this.addAuthorizationHeader(internalOptions.headers);
    //    return this.httpClient.get<Object>(url, internalOptions);
    // }

    get<T = Object>(url: string, options?: CallOptions): Observable<T> {
        const internalOptions = options || <CallOptions>{};
        // this.addWithCredentialsOption(internalOptions);
        internalOptions.headers = this.addAuthorizationHeader(
            internalOptions.headers
        );
        // internalOptions.headers = this.addOriginHeader(internalOptions.headers);
        return this.httpClient.get<T>(url, internalOptions);
    }

    post<T = Object>(
        url: string,
        body: any,
        options?: CallOptions
    ): Observable<T> {
        const internalOptions = options || <CallOptions>{};
        // this.addWithCredentialsOption(internalOptions);
        internalOptions.headers = this.addAuthorizationHeader(
            internalOptions.headers
        );
        // internalOptions.headers = this.addOriginHeader(internalOptions.headers);
        // internalOptions.headers = this.addPostContentTypeHeader(internalOptions.headers);
        // debugger;
        return this.httpClient.post<T>(url, body, internalOptions);
    }

    put<T = Object>(
        url: string,
        body: any,
        options?: CallOptions
    ): Observable<T> {
        const internalOptions = options || <CallOptions>{};
        // this.addWithCredentialsOption(internalOptions);
        internalOptions.headers = this.addPostContentTypeHeaderForApplicationJson(
            internalOptions.headers
        );
        internalOptions.headers = this.addAuthorizationHeader(
            internalOptions.headers
        );
        return this.httpClient.put<T>(url, body, internalOptions);
    }

    delete(url: string, options?: CallOptions): Observable<any> {
        const internalOptions = options || <CallOptions>{};
        // internalOptions.headers = this.addOriginHeader(internalOptions.headers);
        internalOptions.headers = this.addAuthorizationHeader(
            internalOptions.headers
        );
        return this.httpClient.delete(url, internalOptions);
    }

    head(url: string, options?: CallOptions): Observable<any> {
        const internalOptions = options || <CallOptions>{};
        // this.addWithCredentialsOption(internalOptions);
        // internalOptions.headers = this.addOriginHeader(internalOptions.headers);
        internalOptions.headers = this.addAuthorizationHeader(
            internalOptions.headers
        );
        return this.httpClient.head(url, internalOptions);
    }

    patch(url: string, body: any, options?: CallOptions): Observable<any> {
        const internalOptions = options || <CallOptions>{};
        // this.addWithCredentialsOption(internalOptions);
        // internalOptions.headers = this.addOriginHeader(internalOptions.headers);
        internalOptions.headers = this.addAuthorizationHeader(
            internalOptions.headers
        );
        return this.httpClient.patch(url, body, internalOptions);
    }
}

export class CallOptions {
    headers?: HttpHeaders /* | {
        [header: string]: string | string[];
    }*/;
    observe?: 'body';
    params?:
        | HttpParams
        | {
              [param: string]: string | string[];
          };
    reportProgress?: boolean;
    responseType: 'json';
    withCredentials?: boolean;
}

export class OperationResponse<T extends Object> {
    bag: T;
}
