import { NgModule } from "@angular/core";
import { AuthenticationService } from "./authentication.service";
import { SecureHttpClientService } from "./securehttpclient.service";
import { NgxWebstorageModule } from 'ngx-webstorage';
import { HttpClientModule } from "@angular/common/http";

export { AuthenticationService } from "./authentication.service";
export { SecureHttpClientService, OperationResponse } from "./securehttpclient.service";
export * from "./authentication.model";


@NgModule({
    imports: [
        HttpClientModule
        , NgxWebstorageModule.forRoot()
    ],
    providers: [
        AuthenticationService,
        SecureHttpClientService
    ],
    exports: [
    ]
})
export class AuthenticationCoreModule {

}