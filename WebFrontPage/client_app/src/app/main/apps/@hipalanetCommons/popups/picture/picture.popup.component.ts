import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { PicturePopupData } from "./picture.popup.model";


@Component({
    selector: 'picture-popup'
    , templateUrl: './picture.popup.component.html'
    , styles: [
        './picture.popup.component.scss'
    ]
})
export class PicturePopupComponent{

    constructor(
        public dialogRef: MatDialogRef<PicturePopupComponent>,
        @Inject(MAT_DIALOG_DATA) public data: PicturePopupData) { }

    onNoClick(): void {
        this.dialogRef.close();
    }



}