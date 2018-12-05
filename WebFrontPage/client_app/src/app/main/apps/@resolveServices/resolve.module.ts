import { NgModule } from "@angular/core";
import { CustomerCoreModule } from "../customers/customer.core.module";
import { ThirdPartyAppTypeResolveService } from "./thirdpartyapptype.resolve.service";
import { ProductColorTypeResolveService } from "./productcolortype.resolve.service";
import { CustomerFreightoutRateTypeResolveService } from "./customerfreightoutratetype.resolve.service";
import { RolePermissionResolveService } from "./rolepermission.resolve.service";
import { UserResolveService } from "./user.resolve.service";

export { ThirdPartyAppTypeResolveService } from "./thirdpartyapptype.resolve.service";
export { ProductColorTypeResolveService } from "./productcolortype.resolve.service";
export { CustomerFreightoutRateTypeResolveService } from "./customerfreightoutratetype.resolve.service";
export { RolePermissionResolveService } from "./rolepermission.resolve.service";
export { UserResolveService } from "./user.resolve.service";


@NgModule({
    imports: [
        CustomerCoreModule
    ],
    exports: [
        CustomerCoreModule
    ],
    providers: [
        ThirdPartyAppTypeResolveService
        , ProductColorTypeResolveService
        , CustomerFreightoutRateTypeResolveService
        , RolePermissionResolveService
        , UserResolveService
    ]
})
export class HiPalanetResolveModule {

}
