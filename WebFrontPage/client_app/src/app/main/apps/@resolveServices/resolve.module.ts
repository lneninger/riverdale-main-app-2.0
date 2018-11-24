import { NgModule } from "@angular/core";
import { CustomerCoreModule } from "../customers/customer.core.module";



@NgModule({
    imports: [
        CustomerCoreModule
    ],
    exports: [
        CustomerCoreModule
    ]
})
export class ResolveModule {

}
