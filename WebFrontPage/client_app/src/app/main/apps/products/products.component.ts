import { Component, ElementRef, OnInit, ViewChild, ViewEncapsulation, Inject } from '@angular/core';
import { MatPaginator, MatSort, MatDialogRef, MAT_DIALOG_DATA, MatDialog, MatSnackBar } from '@angular/material';
import { DataSource } from '@angular/cdk/collections';
import { BehaviorSubject, fromEvent, merge, Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, map } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import { takeUntil } from 'rxjs/internal/operators';


/*************************Custom***********************************/
//import { AngularFireAuth } from '@angular/fire/auth';
//import { AngularFireDatabase } from '@angular/fire/database';
import { DataSourceAbstract } from '../@hipalanetCommons/datatable/datasource.abstract.class';
import { ProductGrid, Product } from './product.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'environments/environment';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ProductService } from './product.service';

@Component({
    selector: 'products',
    templateUrl: './products.component.html',
    styleUrls: ['./products.component.scss'],
    animations: fuseAnimations,
    encapsulation: ViewEncapsulation.None
})
export class ProductsComponent implements OnInit {
    dataSource: ProductsDataSource | null;
    displayedColumns = ['name', 'createdAt', 'options'];

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
        private service: ProductService
        //, private database: AngularFireDatabase
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

    }

    openDialog(): void {
        const dialogRef = this.dialog.open(ProductNewDialogComponent, {
            width: '60%',
            data: {/* name: this.name, animal: this.animal */ }
        });

        dialogRef.afterClosed().subscribe(result => {
            console.log('The dialog was closed with', result);
            this.dataSource.dataChanged.next('');
        });
    }
}

export class ProductsDataSource extends DataSourceAbstract<ProductGrid>
{
    /**
     * Constructor
     *
     * @param {ProductsListService} _service
     * @param {MatPaginator} _matPaginator
     * @param {MatSort} _matSort
     */
    constructor(
        service: ProductService
        , filterElement: ElementRef
        , matPaginator: MatPaginator
        , matSort: MatSort
    ) {
        super(service, filterElement, matPaginator, matSort);
    }

    remoteEnpoint: string = `${environment.appApi.apiBaseUrl}product/pagequery`;

    public getFilter(rawFilterObject: {}): {} {


        let result = {};


        return result;
    }


}



@Component({
    selector: 'productnew-dialog',
    templateUrl: 'productnew.dialog.component.html',
})
export class ProductNewDialogComponent {

    frmMain: FormGroup;
    constructor(
        private service: ProductService
        , private matSnackBar: MatSnackBar
        , private frmBuilder: FormBuilder
        , public dialogRef: MatDialogRef<ProductNewDialogComponent>
        , @Inject(MAT_DIALOG_DATA) public data: any
    ) {

        this.frmMain = frmBuilder.group({
            'name': ['', [Validators.required]]
        });
    }

    save() {
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
        this.save().then((res: Product) => {
            this.service.router.navigate([`apps/products/${res.id}`]);
            this.dialogRef.close();
        });
    }
}
