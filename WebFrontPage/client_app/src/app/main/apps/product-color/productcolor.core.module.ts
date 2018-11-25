import { NgModule } from "@angular/core";
import { ProductColorService } from "./productcolor.service";

export { ProductColorService } from "./productcolor.service";

@NgModule({
    providers: [
        ProductColorService
    ]
})
export class ProductColorCoreModule {
}

