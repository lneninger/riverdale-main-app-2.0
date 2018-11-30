import { NgModule } from "@angular/core";
import { DeletePopupModule } from "./delete/delete.popup.module";


@NgModule({
    imports: [
        DeletePopupModule
    ]
    , exports: [
        DeletePopupModule
    ]
})
export class PopupsModule { }