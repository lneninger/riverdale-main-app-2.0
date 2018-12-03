import { NgModule } from "@angular/core";
import { AuthenticationService } from "./authentication.service";
import { NgxWebstorageModule } from 'ngx-webstorage';

export { AuthenticationService } from "./authentication.service";
export * from "./authentication.model";


@NgModule({
    imports: [
        NgxWebstorageModule.forRoot()
    ],
    providers: [
        AuthenticationService
    ]
})
export class AuthenticationCoreModule {

}