import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog, MatSnackBar } from '@angular/material';



/*************************Custom***********************************/
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { SaleOpportunityService, SampleBoxItemNewDialogInput, SampleBoxItem, SampleBoxItemNewDialogOutput } from '../../saleopportunity.core.module';
import { EnumItem } from '../../../@resolveServices/resolve.module';
import { OperationResponseValued } from '../../../@hipalanetCommons/messages/messages.model';
import { 
    ProductColorTypeResolveService
} from '../../../@resolveServices/resolve.module';
import { Observable } from 'rxjs';


@Component({
    selector: "sampleboxproductnew-dialog",
    templateUrl: "./saleopportuny.view-sampleboxnew.dialog.component.html"
})
export class SampleBoxProductNewDialogComponent {
    frmMain: FormGroup;
    listColorType: Observable<EnumItem<any>[]>;
    constructor(
        private saleOpportunityService: SaleOpportunityService,
        productColorTypeResolveService: ProductColorTypeResolveService,
        private matSnackBar: MatSnackBar,
        frmBuilder: FormBuilder,
        public dialogRef: MatDialogRef<SampleBoxProductNewDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: SampleBoxItemNewDialogInput
    ) {
        this.listColorType = productColorTypeResolveService.onList.asObservable();

        this.frmMain = frmBuilder.group({
            name: ["", [Validators.required]],
            colorTypeId: ["", [Validators.required]]
        });
    }

    save(): Promise<any> {
        return new Promise((resolve, reject) => {
            const data = this.frmMain.value;
            data.sampleBoxId = this.data.sampleBoxId;
            this.saleOpportunityService
                .addSampleBoxProductItem(data)
                .then(res => {
                    this.matSnackBar.open("Sample Box Product", "OK", {
                        verticalPosition: "top",
                        duration: 2000
                    });

                    resolve(res);
                })
                .catch(error => reject(error));
        });
    }

    cancel(): void {
        this.dialogRef.close();
    }

    create(): void {
        this.save().then(res => {
            this.dialogRef.close();
        });
    }

    createEdit(): void {
        this.save().then((res: OperationResponseValued<SampleBoxItem>) => {
            // debugger;
            const result = <SampleBoxItemNewDialogOutput>{
                goTo: "Edit",
                data: res.bag
            };

            this.dialogRef.close(result);
        });
    }
}
