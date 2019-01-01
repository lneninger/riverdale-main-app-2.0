import { NgModule } from "@angular/core";
import { CustomerCoreModule } from "../customers/customer.core.module";
import { CustomerResolveService } from "./customer.resolve.service";
import { ThirdPartyAppTypeResolveService } from "./thirdpartyapptype.resolve.service";
import { ProductColorTypeResolveService } from "./productcolortype.resolve.service";
import { CustomerFreightoutRateTypeResolveService } from "./customerfreightoutratetype.resolve.service";
import { PermissionResolveService } from "./permission.resolve.service";
import { UserResolveService } from "./user.resolve.service";
import { RoleResolveService } from "./role.resolve.service";
import { ProductTypeResolveService } from "./producttype.resolve.service";
import { ProductResolveService } from "./product.resolve.service";
import { ResolveUpdateManagerService } from "./resolve.updatemanager.service";

export * from "./resolve.model";
export { CustomerResolveService } from "./customer.resolve.service";
export { ThirdPartyAppTypeResolveService } from "./thirdpartyapptype.resolve.service";
export { ProductColorTypeResolveService } from "./productcolortype.resolve.service";
export { CustomerFreightoutRateTypeResolveService } from "./customerfreightoutratetype.resolve.service";
export { PermissionResolveService } from "./permission.resolve.service";
export { UserResolveService } from "./user.resolve.service";
export { RoleResolveService } from "./role.resolve.service";
export { ProductTypeResolveService } from "./producttype.resolve.service";
export { ProductResolveService } from "./product.resolve.service";
export { ResolveUpdateManagerService } from "./resolve.updatemanager.service";

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
        , CustomerResolveService
        , CustomerFreightoutRateTypeResolveService
        , PermissionResolveService
        , UserResolveService
        , RoleResolveService
        , ProductTypeResolveService
        , ProductResolveService


        , ResolveUpdateManagerService
    ]
})
export class HiPalanetResolveModule {

}
