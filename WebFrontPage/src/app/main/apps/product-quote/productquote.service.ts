import { Injectable } from '@angular/core';
import { SecureHttpClientService } from '../@hipalanetCommons/authentication/securehttpclient.service';
import { environment } from 'environments/environment';
import { ProductQuote, ProductQuoteRequest } from './productquote.models';
import { OperationResponseValued } from '../@hipalanetCommons/messages/messages.model';
import { Observable } from 'rxjs';

@Injectable()
export class ProductQuoteService {
    constructor(public http: SecureHttpClientService) {}

    executeQuote(productId: number): Observable<OperationResponseValued<ProductQuote>> {
        const internalId = productId;
        const data = <ProductQuoteRequest>{
            productId: internalId
        };

        return this.http.post<OperationResponseValued<ProductQuote>>(
            `${environment.appApi.apiBaseUrl}productquote/upsert/${productId}`,
            data
        );
    }
}
