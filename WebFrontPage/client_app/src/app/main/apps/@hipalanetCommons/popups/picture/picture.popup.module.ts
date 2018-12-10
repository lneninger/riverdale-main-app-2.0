import { NgModule } from "@angular/core";
import { PicturePopupComponent } from "./picture.popup.component";
import { MatDialogModule, MatButtonModule } from "@angular/material";


export { PicturePopupComponent } from "./picture.popup.component";
export * from "./picture.popup.model";

@NgModule({
    imports: [
        MatButtonModule
        ,MatDialogModule
    ]
    , declarations: [
        PicturePopupComponent
    ]
    , providers: []

    , exports: [
        PicturePopupComponent
    ]
    , entryComponents: [
        PicturePopupComponent
    ]
})
export class PicturePopupModule { }