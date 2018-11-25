import { Component, ElementRef, OnInit, ViewChild, ViewEncapsulation, Inject } from '@angular/core';
import { MatPaginator, MatSort, MatDialogRef, MAT_DIALOG_DATA, MatDialog, MatSnackBar } from '@angular/material';
import { DataSource } from '@angular/cdk/collections';
import { BehaviorSubject, fromEvent, merge, Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, map } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import { takeUntil } from 'rxjs/internal/operators';


/*************************Custom***********************************/
import { AngularFireAuth } from '@angular/fire/auth';
import { AngularFireDatabase } from '@angular/fire/database';
import { DataSourceAbstract } from '../@hipalanetCommons/datatable/datasource.abstract.class';
import { ProductColorGrid, ProductColor } from './productcolor.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'environments/environment';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ProductColorService } from './productcolor.core.module';

@Component({
    selector: 'product-colors',
    templateUrl: './productcolors.component.html',
    styleUrls: ['./productcolors.component.scss'],
    animations: fuseAnimations,
    encapsulation: ViewEncapsulation.None
})
export class ProductColorsComponent implements OnInit {
    dataSource: ProductColorsDataSource | null;
    displayedColumns = ['options', 'id', 'name', 'hex', 'isBasicColor'];

    @ViewChild(MatPaginator)
    paginator: MatPaginator;

    @ViewChild(MatSort)
    sort: MatSort;

    @ViewChild('filter')
    filter: ElementRef;

    // Private
    private _unsubscribeAll: Subject<any>;


    /* ******************************Custom Notification***********************************************/
    customers: any[];

    constructor(
         private service: ProductColorService
        , private database: AngularFireDatabase
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
        this.dataSource = new ProductColorsDataSource(this.service, this.filter/*, this._service*/, this.paginator, this.sort);

    }

    selectedItem: ProductColorGrid;
    selectItem(item: ProductColorGrid) {
        this.selectedItem = item;
    }

    save() {
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

        dialogRef.afterClosed().subscribe(result => {
            console.log('The dialog was closed with', result);
        });
    }

}

export class ProductColorsDataSource extends DataSourceAbstract<ProductColorGrid>
{
    /**
     * Constructor
     *
     * @param {CustomersListService} _service
     * @param {MatPaginator} _matPaginator
     * @param {MatSort} _matSort
     */
    constructor(
        service: ProductColorService
        , filterElement: ElementRef
        , matPaginator: MatPaginator
        , matSort: MatSort
    ) {
        super(service, filterElement, matPaginator, matSort);
    }

    remoteEnpoint: string = `${environment.appApi.apiBaseUrl}productcolortype/pagequery`;

    public getFilter(rawFilterObject: {}): {} {


        let result = {};


        return result;
    }
}




@Component({
    selector: 'productcolornew-dialog',
    templateUrl: 'productcolornew.dialog.component.html',
})
export class ProductColorNewDialogComponent {

    frmMain: FormGroup;
    constructor(
        private service: ProductColorService
        , private matSnackBar: MatSnackBar
        , private frmBuilder: FormBuilder
        , public dialogRef: MatDialogRef<ProductColorNewDialogComponent>
        , @Inject(MAT_DIALOG_DATA) public data: any
    ) {

        this.frmMain = frmBuilder.group({
            'id': ['', [Validators.required]],
            'name': ['', [Validators.required]],
            'hexCode': ['', [Validators.required]],
            'isBasicColor': ['', [Validators.required]],
        });
    }

    save() {
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

    create(): void {
        this.save().then(res => {
            this.dialogRef.close();
        });
    }
    
}