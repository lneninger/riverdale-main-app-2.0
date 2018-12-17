import { NgModule } from "@angular/core";
import { ProductService } from "./product.service";
import { ProductMediaGrid } from "./product.model";
import { ProductMediaService } from "./productmedia.service";

export { ProductService } from "./product.service";
export { ProductMediaService } from "./productmedia.service";
export * from "./product.model";

@NgModule({
    providers: [
        ProductService
        , ProductMediaService
    ]
})
export class ProductCoreModule {
}

