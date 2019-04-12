import { NgModule } from "@angular/core";
import { FuseSharedModule } from '@fuse/shared.module';
import { PromptPopupComponent } from "./prompt.popup.component";
import { MatDialogModule, MatButtonModule, MatInputModule } from "@angular/material";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";


export { PromptPopupComponent } from "./prompt.popup.component";
export * from "./prompt.popup.model";

@NgModule({
    imports: [
        FuseSharedModule
        , MatButtonModule
        ,MatDialogModule
        , MatInputModule
        , CommonModule
        , FormsModule
    ]
    , declarations: [
        PromptPopupComponent
    ]
    , providers: []

    , exports: [
        PromptPopupComponent
    ]
    , entryComponents: [
        PromptPopupComponent
    ]
})
export class PromptPopupModule { }