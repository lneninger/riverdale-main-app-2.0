import { Component, ElementRef, OnInit, ViewChild, ViewEncapsulation, Inject } from '@angular/core';
import { MatPaginator, MatSort, MatDialogRef, MAT_DIALOG_DATA, MatDialog, MatSnackBar } from '@angular/material';
import { DataSource } from '@angular/cdk/collections';
import { BehaviorSubject, fromEvent, merge, Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, map } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import { takeUntil } from 'rxjs/internal/operators';


/*************************Custom***********************************/
// import { AngularFireAuth } from '@angular/fire/auth';
// import { AngularFireDatabase } from '@angular/fire/database';
import { DataSourceAbstract } from '../@hipalanetCommons/datatable/datasource.abstract.class';
import { ProductGrid, Product, ProductNewDialogResult, ProductNewDialogInput } from './product.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'environments/environment';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ProductService } from './product.service';
import { ProductTypeResolveService, ProductCategoryResolveService, EnumItem } from '../@resolveServices/resolve.module';
import { OperationResponseValued } from '../@hipalanetCommons/messages/messages.model';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'products',
    templateUrl: './products.component.html',
    styleUrls: ['./products.component.scss'],
    animations: fuseAnimations,
    encapsulation: ViewEncapsulation.None
})
export class ProductsComponent implements OnInit {
    dataSource: ProductsDataSource | null;
    displayedColumns = ['picture', 'name', 'flowerProductCategoryName', 'createdAt'/*, 'options'*/];

    @ViewChild(MatPaginator)
    paginator: MatPaginator;

    @ViewChild(MatSort)
    sort: MatSort;

    @ViewChild('filter')
    filter: ElementRef;

    // Private
    private _unsubscribeAll: Subject<any>;


    /* ******************************Custom Notification***********************************************/
    products: any[];

    constructor(
        private route: ActivatedRoute
        , private service: ProductService
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
        this.dataSource = new ProductsDataSource(this.service, this.filter/*, this._service*/, this.paginator, this.sort);

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
        const dialogRef = this.dialog.open(ProductNewDialogComponent, {
            width: '60%',
            data: <ProductNewDialogInput>{ listProductType$: this.route.snapshot.data.listProductType }
        });

        dialogRef.afterClosed().subscribe((result: ProductNewDialogResult) => {
            if (result && result.goTo === 'Edit') {
                this.service.router.navigate([`apps/products/${result.data.id}`]);
            }
            else {
                this.service.router.navigate([`../`], { relativeTo: this.route });
                this.dataSource.dataChanged.next('');
            }
        });
    }
}

export class ProductsDataSource extends DataSourceAbstract<ProductGrid>
{
    /**
     * 
     * @param service Product service
     * @param filterElement Filter element
     * @param matPaginator Material paginator
     * @param matSort Material sort
     */
    constructor(
        service: ProductService
        , filterElement: ElementRef
        , matPaginator: MatPaginator
        , matSort: MatSort
    ) {
        super(service, filterElement, matPaginator, matSort);
    }

    remoteEnpoint = `${environment.appApi.apiBaseUrl}product/pagequery`;

    public getFilter(rawFilterObject: {}): {} {
        const result: {} = {};

        return result;
    }
}

@Component({
    selector: 'productnew-dialog',
    templateUrl: 'productnew.dialog.component.html',
})
export class ProductNewDialogComponent {
    listProductType$ = this.productTypeResolveService.onList;
    listProductCategory$: BehaviorSubject<EnumItem<number>[]>;
    
    frmMain: FormGroup;
    constructor(
        private service: ProductService
        , private matSnackBar: MatSnackBar
        , private frmBuilder: FormBuilder
        , public dialogRef: MatDialogRef<ProductNewDialogComponent>
        , public productTypeResolveService: ProductTypeResolveService
        , public productCategoryResolveService: ProductCategoryResolveService
        , @Inject(MAT_DIALOG_DATA) public data: ProductNewDialogInput
        , private route: ActivatedRoute
    ) {
        this.listProductType$ = this.productTypeResolveService.onList;
        this.listProductCategory$ = this.productCategoryResolveService.onList;
        this.frmMain = frmBuilder.group({
            'name': ['', [Validators.required]],
            'productTypeId': ['', [Validators.required]],
            'productCategoryId': ['', [Validators.required]],
        });
    }

    save(): Promise<any> {
        return new Promise((resolve, reject) => {
            this.service.add(this.frmMain.value)
                .then(res => {
                    this.matSnackBar.open('Product created', 'OK', {
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
        this.save().then((res: OperationResponseValued<Product>) => {
            // debugger;
            const result = <ProductNewDialogResult>{
                goTo: 'Edit',
                data: res.bag
            };

            this.dialogRef.close(result);
        });
    }
}
