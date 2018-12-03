import { NgModule } from "@angular/core";
import { UserService } from "./user.service";

export { UserService } from "./user.service";

@NgModule({
    providers: [
        UserService
    ]
})
export class UserCoreModule {
}

