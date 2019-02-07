import { NgModule } from "@angular/core";
import { FilePopupComponent } from "./file.popup.component";
import { MatDialogModule, MatButtonModule } from "@angular/material";


export { FilePopupComponent } from "./file.popup.component";
export * from "./file.popup.model";

@NgModule({
    imports: [
        MatButtonModule
        ,MatDialogModule
    ]
    , declarations: [
        FilePopupComponent
    ]
    , providers: []

    , exports: [
        FilePopupComponent
    ]
    , entryComponents: [
        FilePopupComponent
    ]
})
export class FilePopupModule { }