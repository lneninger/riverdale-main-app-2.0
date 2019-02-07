import { NgModule } from "@angular/core";
import { UserRoleService } from "./userrole.service";

export { UserRoleService } from "./userrole.service";

@NgModule({
    providers: [
        UserRoleService
    ]
})
export class UserRoleCoreModule {
}

