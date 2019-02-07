import { NgModule } from "@angular/core";
import { UserService } from "./user.service";

export { UserService } from "./user.service";
export * from "./user.model";

@NgModule({
    providers: [
        UserService
    ]
})
export class UserCoreModule {
}

