import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { PromptPopupData, PromptPopupResult } from "./prompt.popup.model";


@Component({
    selector: 'prompt-popup'
    , templateUrl: './prompt.popup.component.html'
    , styles: [
        './prompt.popup.component.scss'
    ]
})
export class PromptPopupComponent{

    result = new PromptPopupResult('NO');

    constructor(
        public dialogRef: MatDialogRef<PromptPopupComponent>,
        @Inject(MAT_DIALOG_DATA) public data: PromptPopupData) { }

    onNoClick(): void {
        this.dialogRef.close(this.result);
    }

    onYesClick(): void {
        this.result.action = 'YES';
        this.dialogRef.close(this.result);
    }



}