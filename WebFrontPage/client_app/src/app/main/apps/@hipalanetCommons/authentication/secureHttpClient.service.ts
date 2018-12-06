import { Injectable } from "@angular/core";
import { HttpClient, HttpHandler, HttpHeaders, HttpParams } from "@angular/common/http";

import { AuthenticationService } from "./authentication.service";


@Injectable()
export class SecureHttpClientService  {
        constructor(private httpClient: HttpClient, public service: AuthenticationService) {
    }

    addAuthorizationHeader(headers: HttpHeaders) {
        let internalHeaders = headers || new HttpHeaders();
        if (this.service.userData && this.service.userData.accessToken) {
            headers.set('Authorization', `Bearer ${this.service.userData.accessToken}`);
        }

        return internalHeaders;
    }

    get(url: string, options: CallOptions) {
        let internalOptions = options || <CallOptions>{};
        internalOptions.headers = this.addAuthorizationHeader(options.headers);
        return this.httpClient.get(url, options);
    }

    post(url: string, body: any, options: CallOptions) {
        let internalOptions = options || <CallOptions>{};
        internalOptions.headers = this.addAuthorizationHeader(options.headers);
        return this.httpClient.post(url, body, options);
    }

    put(url: string, body: any, options: CallOptions) {
        let internalOptions = options || <CallOptions>{};
        internalOptions.headers = this.addAuthorizationHeader(options.headers);
        return this.httpClient.put(url, body, options);
    }

    delete(url: string, options: CallOptions) {
        let internalOptions = options || <CallOptions>{};
        internalOptions.headers = this.addAuthorizationHeader(options.headers);
        return this.httpClient.delete(url, options);
    }

    head(url: string, options: CallOptions) {
        let internalOptions = options || <CallOptions>{};
        internalOptions.headers = this.addAuthorizationHeader(options.headers);
        return this.httpClient.head(url, options);
    }

    patch(url: string, body: any, options: CallOptions) {
        let internalOptions = options || <CallOptions>{};
        internalOptions.headers = this.addAuthorizationHeader(options.headers);
        return this.httpClient.patch(url, body, options);
    }

}


export class CallOptions {
    headers ?: HttpHeaders/* | {
        [header: string]: string | string[];
    }*/;
    observe ?: 'body';
    params ?: HttpParams | {
        [param: string]: string | string[];
    };
    reportProgress ?: boolean;
    responseType: 'arraybuffer';
    withCredentials ?: boolean;
}