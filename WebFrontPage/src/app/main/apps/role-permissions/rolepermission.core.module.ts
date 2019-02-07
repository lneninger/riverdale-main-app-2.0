import { NgModule } from "@angular/core";
import { RolePermissionService } from "./rolepermission.service";

export { RolePermissionService } from "./rolepermission.service";

export * from "./rolepermission.model";

@NgModule({
    providers: [
        RolePermissionService
    ]
})
export class RolePermissionCoreModule {
}

