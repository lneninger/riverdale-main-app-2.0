import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { DeletePopupData } from "./delete.popup.model";


@Component({
    selector: 'delete-popup'
    , templateUrl: './delete.popup.component.html'
    , styles: [
        './delete.popup.component.scss'
    ]
})
export class DeletePopupComponent{

    constructor(
        public dialogRef: MatDialogRef<DeletePopupComponent>,
        @Inject(MAT_DIALOG_DATA) public data: DeletePopupData) { }

    onNoClick(): void {
        this.dialogRef.close();
    }



}