import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ProductQuoteService } from './productquote.service';


@NgModule({
    imports:[
        HttpClientModule
    ],
    providers: [
        ProductQuoteService
    ]
})
export class ProductQuoteCoreModule{

}
