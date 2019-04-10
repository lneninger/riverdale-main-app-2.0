import { Component, ElementRef, OnInit, ViewChild, ViewEncapsulation, Inject } from '@angular/core';
import { MatPaginator, MatSort, MatDialogRef, MAT_DIALOG_DATA, MatDialog, MatSnackBar } from '@angular/material';
import { DataSource } from '@angular/cdk/collections';
import { BehaviorSubject, fromEvent, merge, Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, map } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import { takeUntil } from 'rxjs/internal/operators';


/*************************Custom***********************************/
import { HttpClient } from '@angular/common/http';
import { environment } from 'environments/environment';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ProductTypeResolveService, EnumItem } from '../../@resolveServices/resolve.module';
import { OperationResponseValued } from '../../@hipalanetCommons/messages/messages.model';
import { ActivatedRoute } from '@angular/router';
import { CustomValidators } from 'ngx-custom-validators';
import { 
    SaleSeasonCategoryTypeResolveService
    , ProductColorTypeResolveService
    , CustomerResolveService, ProductResolveService
    , GrowerTypeResolveService 
} from '../../@resolveServices/resolve.module';
import { ProductService, CompositionItem } from '../product.core.module';
import { CompositionItemNewDialogInput } from '../product.model';


@Component({
    //selector: 'saleopportunitytargetpricenew-dialog',
    templateUrl: './composition.view.bridgenew.dialog.component.html',
})
export class CompositionViewBridgeNewDialogComponent {
    listProduct$ = this.productResolveService.onList;
    listProductColorType$ = this.productColorTypeResolveService.onList;
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
        private service: ProductService
        , private matSnackBar: MatSnackBar
        , private frmBuilder: FormBuilder
        , public dialogRef: MatDialogRef<CompositionViewBridgeNewDialogComponent>
        , private productResolveService: ProductResolveService
        , private productColorTypeResolveService: ProductColorTypeResolveService
        , @Inject(MAT_DIALOG_DATA) public data: CompositionItemNewDialogInput
        , private route: ActivatedRoute
    ) {

        this.productResolveService.noDependencyResolve().subscribe();
        this.productColorTypeResolveService.noDependencyResolve().subscribe();

        
        this.frmMain = frmBuilder.group({
            'productId': [this.data.productRef.relatedProductId, [Validators.required]],
            'stems': [1, [Validators.required]],
            'productColorTypeId': ['', [Validators.required]],
            'productGradeId': ['', [Validators.required]]
        });
    }

    save(): Promise<{}> {
        return new Promise((resolve, reject) => {
            const value = <CompositionItem>this.frmMain.value;
            value.productId = this.data.productRef.productId;
            this.service.addCompositionItem(value)
                .then(res => {
                    this.matSnackBar.open('Product sub item created', 'OK', {
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
