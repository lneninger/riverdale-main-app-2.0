import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { AuthorizationAccessDirective } from "./authorizationviewaccess.directive";

@NgModule({
    imports: [
        HttpClientModule
        //, AuthenticationCoreModule
    ],
    declarations: [
        AuthorizationAccessDirective
    ],
    providers: [
    ],
    exports: [
        AuthorizationAccessDirective
    ]
})
export class AuthenticationModule {

}