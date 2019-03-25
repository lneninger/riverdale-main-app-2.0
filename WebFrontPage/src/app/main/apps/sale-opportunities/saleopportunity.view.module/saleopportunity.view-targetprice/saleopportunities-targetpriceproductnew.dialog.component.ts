import { Component, ElementRef, OnInit, ViewChild, ViewEncapsulation, Inject } from '@angular/core';
import { MatPaginator, MatSort, MatDialogRef, MAT_DIALOG_DATA, MatDialog, MatSnackBar } from '@angular/material';
import { DataSource } from '@angular/cdk/collections';
import { BehaviorSubject, fromEvent, merge, Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, map } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import { takeUntil } from 'rxjs/internal/operators';


/*************************Custom***********************************/
import { SaleOpportunityGrid, SaleOpportunity, SaleOpportunityNewDialogResult, TargetPriceItem, SaleOpportunityTargetPriceNewDialogOutput, SaleOpportunityTargetPriceNewDialogInput, SaleOpportunityTargetPriceProductNewDialogInput, TargetPriceProductItem } from '../../saleopportunity.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'environments/environment';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { SaleOpportunityService } from '../../saleopportunity.core.module';
import { ProductTypeResolveService, EnumItem } from '../../../@resolveServices/resolve.module';
import { OperationResponseValued } from '../../../@hipalanetCommons/messages/messages.model';
import { ActivatedRoute } from '@angular/router';
import { CustomValidators } from 'ng4-validators';
import { 
    SaleSeasonCategoryTypeResolveService
    , ProductColorTypeResolveService
    , CustomerResolveService, ProductResolveService
    , GrowerTypeResolveService 
} from '../../../@resolveServices/resolve.module';


@Component({
    selector: 'saleopportunitytargetpriceproductnew-dialog',
    templateUrl: 'saleopportunities-targetpriceproductnew.dialog.component.html',
})
export class SaleOpportunityTargetPriceProductNewDialogComponent {
    listSeasonCategoryType$ = this.saleSeasonCategoryTypeResolveService.onList;
    listCustomer = this.customerResolveService.onList;
    selectedSeasonCategory: EnumItem<string>;

    get selectedCategorySeasons(): Object {
        if (this.selectedSeasonCategory != null) {
            return this.selectedSeasonCategory.extras['saleSeasonTypes'];
        }
        else {
            return null;
        }
    }

    frmMain: FormGroup;
    constructor(
        private service: SaleOpportunityService
        , private matSnackBar: MatSnackBar
        , private frmBuilder: FormBuilder
        , public dialogRef: MatDialogRef<SaleOpportunityTargetPriceProductNewDialogComponent>
        , private  saleSeasonCategoryTypeResolveService: SaleSeasonCategoryTypeResolveService
        , private customerResolveService: CustomerResolveService
        , private growerTypeResolveService: GrowerTypeResolveService
        , @Inject(MAT_DIALOG_DATA) public data: SaleOpportunityTargetPriceProductNewDialogInput
        , private route: ActivatedRoute
    ) {
        
        this.frmMain = frmBuilder.group({
            'name': ['', [Validators.required]],
            'saleSeasonTypeId': ['', [Validators.required]],
            // 'customerId': ['', [Validators.required]],
            'targetPrice': ['', CustomValidators.number],
            'alterenativesAmount': ['', CustomValidators.number]
        });
    }

    save(): Promise<{}> {
        return new Promise((resolve, reject) => {
            const value = <TargetPriceProductItem>this.frmMain.value;
            value.targetPriceId = this.data.targetPriceId;
            this.service.addTargetPriceProductItem(value)
                .then(res => {
                    this.matSnackBar.open('Target Price Product created', 'OK', {
                        verticalPosition: 'top',
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

    // createEdit(): void {
    //     this.save().then((res: OperationResponseValued<SaleOpportunity>) => {
    //         const result = <SaleOpportunityNewDialogResult>{
    //             goTo: 'Edit',
    //             data: res.bag
    //         };

    //         this.dialogRef.close(result);
    //     });
    // }
}
