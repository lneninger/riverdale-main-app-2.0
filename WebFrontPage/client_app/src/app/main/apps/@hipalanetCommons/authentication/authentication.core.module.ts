import { NgModule } from "@angular/core";
import { AuthenticationService } from "./authentication.service";
import { SecureHttpClientService } from "./securehttpclient.service";
import { NgxWebstorageModule } from 'ngx-webstorage';
import { HttpClientModule } from "@angular/common/http";
//import { AuthorizationAccessDirective } from "./authorizationviewaccess.directive";

export { AuthenticationService } from "./authentication.service";
export { SecureHttpClientService, OperationResponse } from "./securehttpclient.service";
export * from "./authentication.model";


@NgModule({
    imports: [
        HttpClientModule
        , NgxWebstorageModule.forRoot()
    ],
    declarations: [
        //AuthorizationAccessDirective
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