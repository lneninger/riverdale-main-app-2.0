import { NgModule } from "@angular/core";
import { FunzaService } from "./funza.service";

export { FunzaService } from "./funza.service";

@NgModule({
    providers: [
        FunzaService
    ]
})
export class FunzaCoreModule {
}

