import { NgModule } from "@angular/core";
import { DeletePopupModule } from "./delete/delete.popup.module";
import { PromptPopupModule } from "./prompt/prompt.popup.module";
import { FilePopupModule } from "./file/file.popup.module";


@NgModule({
    imports: [
        DeletePopupModule
        , PromptPopupModule
        , FilePopupModule
    ]
    , exports: [
        DeletePopupModule
        , PromptPopupModule
        , FilePopupModule
    ]
})
export class PopupsModule { }