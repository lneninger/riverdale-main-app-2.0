import { NgModule } from "@angular/core";
import { ProductCategoryService } from "./productcategory.service";
import { ProductCategoryAllowedColorTypeService } from "./productcategoryallowedcolortype.service";
import { ProductCategoryAllowedSizeService } from "./productcategoryallowedsize.service";

export { ProductCategoryService } from "./productcategory.service";
export { ProductCategoryAllowedColorTypeService } from "./productcategoryallowedcolortype.service";
export { ProductCategoryAllowedSizeService } from "./productcategoryallowedsize.service";

@NgModule({
    providers: [
        ProductCategoryService
        , ProductCategoryAllowedColorTypeService
        , ProductCategoryAllowedSizeService
    ]
})
export class ProductCategoryCoreModule {
}

