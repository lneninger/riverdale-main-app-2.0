import { NgModule } from "@angular/core";
import { ProductService } from "./product.service";

export { ProductService } from "./product.service";

@NgModule({
    providers: [
        ProductService
    ]
})
export class ProductCoreModule {
}

