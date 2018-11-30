import { NgModule } from "@angular/core";
import { CustomerFreightoutService } from "./customerfreightout.service";

export { CustomerFreightoutService } from "./customerfreightout.service";
export * from "./customerfreightout.model";

@NgModule({
    providers: [
        CustomerFreightoutService
    ]
})
export class CustomerFreightoutCoreModule {
}

