import { Component, ElementRef, OnInit, ViewChild, ViewEncapsulation, Inject } from '@angular/core';
import { MatPaginator, MatSort, MatDialogRef, MAT_DIALOG_DATA, MatDialog, MatSnackBar } from '@angular/material';
import { DataSource } from '@angular/cdk/collections';
import { BehaviorSubject, fromEvent, merge, Observable, Subject, combineLatest, of } from 'rxjs';
import { debounceTime, distinctUntilChanged, map, switchMap, filter } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import { takeUntil } from 'rxjs/internal/operators';

import { 
    SaleSeasonCategoryTypeResolveService
    , ProductColorTypeResolveService
    , CustomerResolveService, ProductResolveService
    , GrowerTypeResolveService 
    , ProductTypeResolveService
    , EnumItem
    , ProductCategoryResolveService
} from '../@resolveServices/resolve.module';



import { DataSourceAbstract } from '../@hipalanetCommons/datatable/datasource.abstract.class';
import { ProductAliasGrid, ProductAlias, ProductAliasNewDialogResult, ProductAliasNewDialogInput } from './productalias.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'environments/environment';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ProductAliasService } from './productalias.service';
import { OperationResponseValued } from '../@hipalanetCommons/messages/messages.model';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../e-commerce/product/product.model';

@Component({
    selector: 'productalias',
    templateUrl: './productalias.component.html',
    styleUrls: ['./productalias.component.scss'],
    animations: fuseAnimations,
    encapsulation: ViewEncapsulation.None
})
export class ProductAliasComponent implements OnInit {
    dataSource: ProductAliasDataSource | null;
    displayedColumns = ['name', 'product', 'color', 'size', 'createdAt'];

    @ViewChild(MatPaginator)
    paginator: MatPaginator;

    @ViewChild(MatSort)
    sort: MatSort;

    @ViewChild('filter')
    filter: ElementRef;

    // Private
    private _unsubscribeAll: Subject<any>;


    /* ******************************Custom Notification***********************************************/
    productAlias: any[];

    constructor(
        private route: ActivatedRoute
        , private service: ProductAliasService
        , public dialog: MatDialog
    ) {

        // Set the private defaults
        this._unsubscribeAll = new Subject();
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void {
        // debugger;
        this.dataSource = new ProductAliasDataSource(this.service, this.filter/*, this._service*/, this.paginator, this.sort);

        this.initializeQueryListeners();
    }

    initializeQueryListeners(): void {
        this.route.queryParams.subscribe(params => {
            // debugger;
            if (this.route.snapshot.data['action'] === 'new') {
                this.openDialog();
            }
        });
    }

    openDialog(): void {
        const dialogRef = this.dialog.open(ProductAliasNewDialogComponent, {
            width: '60%',
            data: <ProductAliasNewDialogInput>{ listProductType$: this.route.snapshot.data.listProductType }
        });

        dialogRef.afterClosed().subscribe((result: ProductAliasNewDialogResult) => {
            if (result && result.goTo === 'Edit') {
                this.service.router.navigate([`apps/basicproductalias/${result.data.id}`]);
            }
            else {
                this.service.router.navigate([`../`], { relativeTo: this.route });
                this.dataSource.dataChanged.next('');
            }
        });
    }
}

export class ProductAliasDataSource extends DataSourceAbstract<ProductAliasGrid>
{
    /**
     * 
     * @param service ProductAlias service
     * @param filterElement Filter element
     * @param matPaginator Material paginator
     * @param matSort Material sort
     */
    constructor(
        service: ProductAliasService
        , filterElement: ElementRef
        , matPaginator: MatPaginator
        , matSort: MatSort
    ) {
        super(service, filterElement, matPaginator, matSort);
    }

    remoteEnpoint = `${environment.appApi.apiBaseUrl}basicproductalias/pagequery`;

    public getFilter(rawFilterObject: {}): {} {
        const result: {} = {};

        return result;
    }
}

@Component({
    selector: 'productaliasnew-dialog',
    templateUrl: 'productaliasnew.dialog.component.html',
})
export class ProductAliasNewDialogComponent implements OnInit{
    listProductType$ = this.productTypeResolveService.onList;
    listProductCategory$: BehaviorSubject<EnumItem<number>[]>;

    listProductColorType$ = this.productColorTypeResolveService.onList;
    // listProductColorType$ = this.productColorTypeResolveService.onList;
    listProduct$ = this.productResolveService.onList;
    product$ = new BehaviorSubject<Product>(null);
    productItem$: Observable<EnumItem<number>>;
    currentProductCategory$: Observable<EnumItem<number>>;
    allowedProductColors$: Observable<EnumItem<string>[]>;
    allowedRelatedProductSizes$: Observable<EnumItem<number>[]>;
    
    frmMain: FormGroup;
    constructor(
        private service: ProductAliasService
        , private matSnackBar: MatSnackBar
        , private frmBuilder: FormBuilder
        , public dialogRef: MatDialogRef<ProductAliasNewDialogComponent>
        , public productTypeResolveService: ProductTypeResolveService
        , public productCategoryResolveService: ProductCategoryResolveService
        , private productResolveService: ProductResolveService
        , private productColorTypeResolveService: ProductColorTypeResolveService
        , @Inject(MAT_DIALOG_DATA) public data: ProductAliasNewDialogInput
        , private route: ActivatedRoute
    ) {

        this.productTypeResolveService.noDependencyResolve().subscribe();
        this.productCategoryResolveService.noDependencyResolve().subscribe();
        this.productResolveService.noDependencyResolve().subscribe();
        this.productColorTypeResolveService.noDependencyResolve().subscribe();

        this.listProductType$ = this.productTypeResolveService.onList;
        this.listProductCategory$ = this.productCategoryResolveService.onList;
        this.frmMain = frmBuilder.group({
            'name': ['', [Validators.required]],
            'productId': ['', [Validators.required]],
            'colorTypeId': ['', [Validators.required]],
            'productCategorySizeId': ['', [Validators.required]],
        });

    }

    ngOnInit(): void{

        const productIdChanged$ =  this.frmMain.controls['productId'].valueChanges;

         // debugger;
         this.productItem$ = combineLatest([productIdChanged$, this.listProduct$])
         .pipe(filter(combined => combined[0] && combined[1]), map(combined => {
             // debugger;
             return (<EnumItem<number>[]>combined[1]).find(productItem => productItem.key === combined[0]/* combined[0].id*/);
         }));

         this.configureCurrentProductCategory();

         this.filterAllowedProductSizes();

         this.filterAllowedProductColors();
    }

    configureCurrentProductCategory(): void {
        this.currentProductCategory$ =  combineLatest([this.productItem$, this.listProductCategory$])

        .pipe(map(combined => { 
            // debugger;
            return { 
                productItem: (<EnumItem<number>>combined[0]), 
                productCategories: (<EnumItem<number>[]>combined[1]) };
             }))
        .pipe(switchMap(source => {
            const targetCategoryId = <number><unknown>source.productItem.extras['productCategoryId'];
            const targetCategory = targetCategoryId && source.productCategories.find(categoryItem => categoryItem.key === targetCategoryId);
            return of(targetCategory);
        }));
    }
       
    
        filterAllowedProductSizes(): void {
            this.allowedRelatedProductSizes$ = this.currentProductCategory$.pipe(switchMap(targetCategory => {
                if (targetCategory != null) {
                    return of(<EnumItem<number>[]>targetCategory.extras['sizes']);
                }
                else {
                    return of(<EnumItem<number>[]>[]);
                }
            }));
        }
    
        filterAllowedProductColors(): void {
            this.allowedProductColors$ = combineLatest([this.currentProductCategory$, this.listProductColorType$])
            .pipe(map(combined => { 
                // debugger;
                return { 
                    targetCategory: (<EnumItem<number>>combined[0]), 
                    listProductColorType: (<EnumItem<string>[]>combined[1]) };
                 }))
            .pipe(switchMap(source => {
                if (source.targetCategory != null) {
                    const allowedColorIds = (<string[]>source.targetCategory.extras['allowedColorTypes']);
                    return of(<EnumItem<string>[]>source.listProductColorType.filter(colorType => allowedColorIds.findIndex(colorTypeId => colorTypeId === colorType.key) >= 0 ) );
                }
                else {
                    return of(<EnumItem<string>[]>[]);
                }
            }));
        }

    save(): Promise<any> {
        return new Promise((resolve, reject) => {
            this.service.add(this.frmMain.value)
                .then(res => {
                    this.matSnackBar.open('Product Alias created', 'OK', {
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

    createEdit(): void {
        this.save().then((res: OperationResponseValued<ProductAlias>) => {
            // debugger;
            const result = <ProductAliasNewDialogResult>{
                goTo: 'Edit',
                data: res.bag
            };

            this.dialogRef.close(result);
        });
    }
}
