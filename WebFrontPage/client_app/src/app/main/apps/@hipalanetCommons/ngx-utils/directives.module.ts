import { Input, Directive, NgModule } from "@angular/core";
import { DefaultImage } from "./imageerrorsource.directive";
import { HeightToElementDirective } from "./heighttoelement.directive";

@NgModule({
    declarations: [DefaultImage, HeightToElementDirective],
    exports: [DefaultImage, HeightToElementDirective],

})
export class DirectivesModule {
}
