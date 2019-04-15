import { Component, ElementRef, OnInit, ViewChild, ViewEncapsulation, Inject } from '@angular/core';
import { MatPaginator, MatSort, MatDialogRef, MAT_DIALOG_DATA, MatDialog, MatSnackBar } from '@angular/material';
import { DataSource } from '@angular/cdk/collections';
import { BehaviorSubject, fromEvent, merge, Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, map } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import { takeUntil } from 'rxjs/internal/operators';


/*************************Custom***********************************/
import { SaleOpportunityGrid, SaleOpportunity, SaleOpportunityNewDialogResult, TargetPriceItem, SaleOpportunityTargetPriceNewDialogOutput, SaleOpportunityTargetPriceNewDialogInput, SaleOpportunityTargetPriceProductNewDialogInput, TargetPriceProductItem, SaleOpportunityTargetPriceSubProductNewDialogInput } from '../../saleopportunity.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'environments/environment';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { SaleOpportunityService } from '../../saleopportunity.core.module';
import { ProductTypeResolveService, EnumItem, ProductCategoryResolveService } from '../../../@resolveServices/resolve.module';
import { OperationResponseValued } from '../../../@hipalanetCommons/messages/messages.model';
import { ActivatedRoute } from '@angular/router';
import { CustomValidators } from 'ngx-custom-validators';
import { 
    SaleSeasonCategoryTypeResolveService
    , ProductColorTypeResolveService
    , CustomerResolveService, ProductResolveService
    , GrowerTypeResolveService 
} from '../../../@resolveServices/resolve.module';
import { ProductService, Product } from '../../../products/product.core.module';


@Component({
    selector: 'saleopportunitytargetpricesubproductnew-dialog',
    templateUrl: 'saleopportunities-targetpricesubproductnew.dialog.component.html',
})
export class SaleOpportunityTargetPriceSubProductNewDialogComponent {
    listProductCategory$ = this.productCategoryResolveService.onList;
    listProductColorType$ = this.productColorTypeResolveService.onList;
    listProduct$ = this.productResolveService.onList;
    private product$ = new Subject<Product>();
    
    frmMain: FormGroup;
    constructor(
        private service: SaleOpportunityService
        , private productService: ProductService
        , private matSnackBar: MatSnackBar
        , private frmBuilder: FormBuilder
        , public dialogRef: MatDialogRef<SaleOpportunityTargetPriceSubProductNewDialogComponent>
        , private productResolveService: ProductResolveService
        , private productColorTypeResolveService: ProductColorTypeResolveService
        , private  productCategoryResolveService: ProductCategoryResolveService
        , @Inject(MAT_DIALOG_DATA) public data: SaleOpportunityTargetPriceSubProductNewDialogInput
        , private route: ActivatedRoute
    ) {
        this.productResolveService.noDependencyResolve().subscribe();
        this.productCategoryResolveService.noDependencyResolve().subscribe();
        this.productColorTypeResolveService.noDependencyResolve().subscribe();



        this.productService.getById(data.subProductId)
            .subscribe(response => {
                const product = response.bag;
                debugger;
                this.frmMain = frmBuilder.group({
                    'productId': [this.data.productId, [Validators.required]],
                    'subProductId': [product.id, [Validators.required]],
                    'colorTypeId': ['', [Validators.required]],
                    'amount': [1, [Validators.required, CustomValidators.number]],
                    'size': ['', [Validators.required, CustomValidators.number]],
                });

                this.product$.next(product);
            });

        
    }

    save(): Promise<{}> {
        return new Promise((resolve, reject) => {
            const value = this.frmMain.value;
            this.service.addTargetPriceProductItem(value)
                .then(res => {
                    this.matSnackBar.open('Item add to compoisiton', 'OK', {
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

    add(): void {
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
