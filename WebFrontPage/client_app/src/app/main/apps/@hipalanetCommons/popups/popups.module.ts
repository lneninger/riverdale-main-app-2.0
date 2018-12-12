import { NgModule } from "@angular/core";
import { DeletePopupModule } from "./delete/delete.popup.module";
import { FilePopupModule } from "./file/file.popup.module";


@NgModule({
    imports: [
        DeletePopupModule
        , FilePopupModule
    ]
    , exports: [
        DeletePopupModule
        , FilePopupModule
    ]
})
export class PopupsModule { }