import { NgModule } from "@angular/core";
import { CustomerCoreModule } from "../customers/customer.core.module";
import { ThirdPartyAppTypeResolveService } from "./thirdpartyapptype.resolve.service";

export { ThirdPartyAppTypeResolveService } from "./thirdpartyapptype.resolve.service";


@NgModule({
    imports: [
        CustomerCoreModule
    ],
    exports: [
        CustomerCoreModule
    ],
    providers: [
        ThirdPartyAppTypeResolveService
    ]
})
export class HiPalanetResolveModule {

}
