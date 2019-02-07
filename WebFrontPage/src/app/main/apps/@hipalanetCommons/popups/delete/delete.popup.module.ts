import { NgModule } from "@angular/core";
import { DeletePopupComponent } from "./delete.popup.component";
import { MatDialogModule, MatButtonModule } from "@angular/material";


export { DeletePopupComponent } from "./delete.popup.component";
export * from "./delete.popup.model";

@NgModule({
    imports: [
        MatButtonModule
        ,MatDialogModule
    ]
    , declarations: [
        DeletePopupComponent
    ]
    , providers: []

    , exports: [
        DeletePopupComponent
    ]
    , entryComponents: [
        DeletePopupComponent
    ]
})
export class DeletePopupModule { }