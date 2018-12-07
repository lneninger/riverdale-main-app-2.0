import { NgModule } from "@angular/core";
import { RoleUserService } from "./roleuser.service";

export { RoleUserService } from "./roleuser.service";

export * from "./roleuser.model";

@NgModule({
    providers: [
        RoleUserService
    ]
})
export class RoleUserCoreModule {
}

