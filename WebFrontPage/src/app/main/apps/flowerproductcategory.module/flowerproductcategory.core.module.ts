import { NgModule } from "@angular/core";
import { FlowerProductCategoryService } from "./flowerproductcategory.service";

export { FlowerProductCategoryService } from "./flowerproductcategory.service";

@NgModule({
    providers: [
        FlowerProductCategoryService
    ]
})
export class FlowerProductCategoryCoreModule {
}

