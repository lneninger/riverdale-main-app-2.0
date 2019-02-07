import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { FilePopupData } from "./file.popup.model";


@Component({
    selector: 'file-popup'
    , templateUrl: './file.popup.component.html'
    , styles: [
        './file.popup.component.scss'
    ]
})
export class FilePopupComponent{

    constructor(
        public dialogRef: MatDialogRef<FilePopupComponent>,
        @Inject(MAT_DIALOG_DATA) public data: FilePopupData) { }

    onNoClick(): void {
        this.dialogRef.close();
    }



}