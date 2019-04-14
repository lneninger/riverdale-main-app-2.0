import { NgModule } from "@angular/core";
import { ProductCategoryService } from "./productcategory.service";
import { ProductCategoryAllowedColorTypeService } from "./productcategoryallowedcolortype.service";

export { ProductCategoryService } from "./productcategory.service";

@NgModule({
    providers: [
        ProductCategoryService
        , ProductCategoryAllowedColorTypeService
    ]
})
export class ProductCategoryCoreModule {
}

