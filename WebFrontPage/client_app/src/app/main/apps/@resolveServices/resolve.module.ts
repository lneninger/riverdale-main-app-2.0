import { NgModule } from "@angular/core";
import { CustomerCoreModule } from "../customers/customer.core.module";
import { ThirdPartyAppTypeResolveService } from "./thirdpartyapptype.resolve.service";
import { ProductColorTypeResolveService } from "./productcolortype.resolve.service";
import { CustomerFreightoutRateTypeResolveService } from "./customerfreightoutratetype.resolve.service";
import { PermissionResolveService } from "./permission.resolve.service";
import { UserResolveService } from "./user.resolve.service";
import { RoleResolveService } from "./role.resolve.service";
import { ProductTypeResolveService } from "./producttype.resolve.service";

export { ThirdPartyAppTypeResolveService } from "./thirdpartyapptype.resolve.service";
export { ProductColorTypeResolveService } from "./productcolortype.resolve.service";
export { CustomerFreightoutRateTypeResolveService } from "./customerfreightoutratetype.resolve.service";
export { PermissionResolveService } from "./permission.resolve.service";
export { UserResolveService } from "./user.resolve.service";
export { RoleResolveService } from "./role.resolve.service";
export { ProductTypeResolveService } from "./producttype.resolve.service";


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
        , PermissionResolveService
        , UserResolveService
        , RoleResolveService
        , ProductTypeResolveService
    ]
})
export class HiPalanetResolveModule {

}
