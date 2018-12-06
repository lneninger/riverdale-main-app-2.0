import { NgModule } from "@angular/core";
import { AuthenticationService } from "./authentication.service";
import { SecureHttpClientService } from "./securehttpclient.service";
import { NgxWebstorageModule } from 'ngx-webstorage';

export { AuthenticationService } from "./authentication.service";
export { SecureHttpClientService } from "./securehttpclient.service";
export * from "./authentication.model";


@NgModule({
    imports: [
        NgxWebstorageModule.forRoot()
    ],
    providers: [
        AuthenticationService,
        SecureHttpClientService
    ]
})
export class AuthenticationCoreModule {

}