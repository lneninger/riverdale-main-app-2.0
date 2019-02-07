import { NgModule } from "@angular/core";
import { CustomerFreightoutService } from "./customerfreightout.service";
import { AuthenticationCoreModule } from "../@hipalanetCommons/authentication/authentication.core.module";

export { CustomerFreightoutService } from "./customerfreightout.service";
export * from "./customerfreightout.model";

@NgModule({
    imports: [
        AuthenticationCoreModule
    ],
    providers: [
        CustomerFreightoutService
    ]
})
export class CustomerFreightoutCoreModule {
}

