import { NgModule } from "@angular/core";
import { CustomerService } from "./customer.service";

export { CustomerService } from "./customer.service";

@NgModule({
    providers: [
        CustomerService
    ]
})
export class CustomerCoreModule {
}

