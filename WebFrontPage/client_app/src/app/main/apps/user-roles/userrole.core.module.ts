import { NgModule } from "@angular/core";
import { UserRoleService } from "./userRole.service";

export { UserRoleService } from "./userRole.service";

@NgModule({
    providers: [
        UserRoleService
    ]
})
export class UserRoleCoreModule {
}

