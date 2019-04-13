import { Component, ElementRef, OnInit, ViewChild, ViewEncapsulation, Inject } from '@angular/core';
import { MatPaginator, MatSort, MatDialogRef, MAT_DIALOG_DATA, MatDialog, MatSnackBar } from '@angular/material';
import { DataSource } from '@angular/cdk/collections';
import { BehaviorSubject, fromEvent, merge, Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, map } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import { takeUntil } from 'rxjs/internal/operators';


/*************************Custom***********************************/
import { DataSourceAbstract } from '../@hipalanetCommons/datatable/datasource.abstract.class';
import { ProductCategory, ProductCategoryGrid, ProductCategoryGrade, ProductCategoryNewDialogResult, ProductCategoryGradeGrid } from './productcategory.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'environments/environment';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ProductCategoryService } from './productcategory.core.module';
import { OperationResponseValued } from '../@hipalanetCommons/messages/messages.model';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'product-categories',
    templateUrl: './productcategories.component.html',
    styleUrls: ['./productcategories.component.scss'],
    animations: fuseAnimations,
    encapsulation: ViewEncapsulation.None
})
export class ProductCategoriesComponent implements OnInit {
    dataSource: ProductCategoriesDataSource | null;
    displayedColumns = ['options', 'id', 'name'];

    @ViewChild(MatPaginator)
    paginator: MatPaginator;

    @ViewChild(MatSort)
    sort: MatSort;

    @ViewChild('filter')
    filter: ElementRef;

    // Private
    private _unsubscribeAll: Subject<any>;

    selectedItem: ProductCategoryGrid;

    /* ******************************Custom Notification***********************************************/
    customers: any[];

    constructor(
        private service: ProductCategoryService
        , private route: ActivatedRoute
        , public dialog: MatDialog
        , private matSnackBar: MatSnackBar
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
        this.dataSource = new ProductCategoriesDataSource(this.service, this.filter/*, this._service*/, this.paginator, this.sort);
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


    selectItem(item: ProductCategoryGrid): void {
        this.selectedItem = item;
    }

    save(): void {
        this.service.save(this.selectedItem).then(res => {
            this.selectedItem = null;
            this.matSnackBar.open('Notification Group added', 'OK', {
                verticalPosition: 'top',
                duration: 2000
            });
        })
        .catch(error => {

        });
    }

    openDialog(): void {
        const dialogRef = this.dialog.open(ProductColorNewDialogComponent, {
            width: '60%',
            data: {/* name: this.name, animal: this.animal */ }
        });

        dialogRef.afterClosed().subscribe((result: ProductCategoryNewDialogResult) => {
            if (result && result.goTo === 'Edit') {
                this.service.router.navigate([`apps/productcategory/${result.data.id}`]);
            }
            else {
                this.service.router.navigate([`../`], { relativeTo: this.route });
                this.dataSource.dataChanged.next('');
            }
        });
    }

}

export class ProductCategoriesDataSource extends DataSourceAbstract<ProductCategoryGrid>
{
    /**
     * Constructor
     *
     * @param _service: Product Color Service
     * @param _matPaginator Grid Paginator
     * @param _matSort Grid Sort provider
     */
    constructor(
        service: ProductCategoryService
        , filterElement: ElementRef
        , matPaginator: MatPaginator
        , matSort: MatSort
    ) {
        super(service, filterElement, matPaginator, matSort);
    }

    remoteEnpoint = `${environment.appApi.apiBaseUrl}productcategory/pagequery`;

    public getFilter(rawFilterObject: {}): {} {
        const result = {};
        return result;
    }
}




@Component({
    selector: 'productcategorynew-dialog',
    templateUrl: 'productcategorynew.dialog.component.html',
})
export class ProductColorNewDialogComponent {

    frmMain: FormGroup;
    constructor(
        private service: ProductCategoryService
        , private matSnackBar: MatSnackBar
        , private frmBuilder: FormBuilder
        , public dialogRef: MatDialogRef<ProductColorNewDialogComponent>
        , @Inject(MAT_DIALOG_DATA) public data: any
    ) {
        debugger;

        this.frmMain = frmBuilder.group({
            'id': ['', [Validators.required]],
            'name': ['', [Validators.required]],
            'hexCode': ['', [Validators.required]],
            'isBasicColor': ['', [Validators.required]],
        });
    }

    save(): Promise<any> {
        return new Promise((resolve, reject) => {
            this.service.add(this.frmMain.value)
                .then(res => {
                    this.matSnackBar.open('Product Color created', 'OK', {
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
        this.save().then((res: OperationResponseValued<ProductCategory>) => {
            // debugger;
            const result = <ProductCategoryNewDialogResult>{
                goTo: 'Edit',
                data: res.bag
            };

            this.dialogRef.close(result);
        });
    }
    
}
