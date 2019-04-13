import { NgModule } from "@angular/core";
import { ProductCategoryService } from "./productcategory.service";

export { ProductCategoryService } from "./productcategory.service";

@NgModule({
    providers: [
        ProductCategoryService
    ]
})
export class ProductCategoryCoreModule {
}

