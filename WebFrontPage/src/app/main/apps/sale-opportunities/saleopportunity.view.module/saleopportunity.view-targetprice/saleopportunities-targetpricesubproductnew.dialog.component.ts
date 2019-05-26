import { Component, ElementRef, OnInit, ViewChild, ViewEncapsulation, Inject } from '@angular/core';
import { MatPaginator, MatSort, MatDialogRef, MAT_DIALOG_DATA, MatDialog, MatSnackBar } from '@angular/material';
import { DataSource } from '@angular/cdk/collections';
import { BehaviorSubject, fromEvent, merge, Observable, Subject, combineLatest, of } from 'rxjs';
import { debounceTime, distinctUntilChanged, map, switchMap } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import { takeUntil } from 'rxjs/internal/operators';


/*************************Custom***********************************/
import { SaleOpportunityGrid, SaleOpportunity
    , SaleOpportunityNewDialogResult
    , TargetPriceItem
    , SaleOpportunityTargetPriceNewDialogOutput
    , SaleOpportunityTargetPriceNewDialogInput
    , SaleOpportunityTargetPriceProductNewDialogInput
    , TargetPriceProductItem
    , SaleOpportunityTargetPriceSubProductNewDialogInput
 } from '../../saleopportunity.model';

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
import { ProductService, Product, CompositionItem } from '../../../products/product.core.module';


@Component({
    selector: 'saleopportunitytargetpricesubproductnew-dialog',
    templateUrl: 'saleopportunities-targetpricesubproductnew.dialog.component.html',
    styleUrls: ['./saleopportunities-targetpricesubproductnew.dialog.component.scss'],
})
export class SaleOpportunityTargetPriceSubProductNewDialogComponent implements OnInit {
    listProductCategory$ = this.productCategoryResolveService.onList;
    listProductColorType$ = this.productColorTypeResolveService.onList;
    //listProductColorType$ = this.productColorTypeResolveService.onList;
    listProduct$ = this.productResolveService.onList;
    product$ = new BehaviorSubject<Product>(null);

    relatedProductId$: BehaviorSubject<number> = new BehaviorSubject<number>(null);
    allowedRelatedProductSizes$: Observable<EnumItem<number>[]>;

    
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
                'productId': [this.data.productId, []],
                'subProductId': [product.id, [Validators.required]],
                'colorTypeId': ['', [Validators.required]],
                'relatedProductSizeId': ['', [Validators.required]],
                'amount': [1, [Validators.required, CustomValidators.number]],
            });

            this.product$.next(product);
        });
    }

    ngOnInit(): void{
        debugger;
        const productItem$ = combineLatest([this.product$, this.listProduct$])
            .pipe(map(combined => {
                debugger;
                return (<EnumItem<number>[]>combined[1]).find(productItem => productItem.key === combined[0].id);
            }));


        this.allowedRelatedProductSizes$ =
        combineLatest([productItem$, this.listProductCategory$])
        .pipe(map(combined => { 
            debugger;
            return { 
                productItem: (<EnumItem<number>>combined[0]), 
                productCategories: (<EnumItem<number>[]>combined[1]) };
             }))
        .pipe(switchMap(source => {
            debugger;
            const targetCategoryId = <number><unknown>source.productItem.extras['productCategoryId'];
            const targetCategory = targetCategoryId && source.productCategories.find(categoryItem => categoryItem.key === targetCategoryId);

            if (targetCategory != null) {
                return of(<EnumItem<number>[]>targetCategory.extras['sizes']);
            }
            else {
                return of(<EnumItem<number>[]>[]);
            }
        }));

    }

    save(): Promise<{}> {
        return new Promise((resolve, reject) => {
            const original = this.frmMain.value;
            const value = new CompositionItem(original);
            // debugger;
            value.productId = original.productId;
            value.relatedProductId = original.subProductId;
            value.colorTypeId = original.colorTypeId;
            value.stems = original.amount;


            this.service.addTargetPriceProductSubItem(value)
                .then(res => {
                    this.matSnackBar.open('Item add to composition', 'OK', {
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
