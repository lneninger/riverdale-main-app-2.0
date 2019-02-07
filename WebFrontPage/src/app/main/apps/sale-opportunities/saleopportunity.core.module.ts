import { NgModule } from "@angular/core";
import { SaleOpportunityService } from "./saleopportunity.service";
import { SaleOpportunityGrid } from "./saleopportunity.model";
//import { ProductMediaService } from "./productmedia.service";

export { SaleOpportunityService } from "./saleopportunity.service";
export * from "./saleopportunity.model";

@NgModule({
    providers: [
        SaleOpportunityService
        //, ProductMediaService
    ]
})
export class SaleOpportunityCoreModule {
}

