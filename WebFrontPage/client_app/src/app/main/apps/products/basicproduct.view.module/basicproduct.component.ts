import { Component, OnDestroy, OnInit, ViewEncapsulation, ViewChild, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Location } from '@angular/common';
import { MatSnackBar, MatPaginator, MatSort, MatTable, MatDialog } from '@angular/material';
import { Subject, Observable, of } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import { Product, ProductMediaGrid, IProductMedia } from '../product.model';
import { ProductService } from '../product.service';
import { EnumItem } from '../../@resolveServices/resolve.model';
import { DataSourceAbstract } from '../../@hipalanetCommons/datatable/datasource.abstract.class';
import { DataSource } from '@angular/cdk/table';
import { DeletePopupComponent, DeletePopupData, DeletePopupResult } from '../../@hipalanetCommons/popups/delete/delete.popup.module';
import { FilePopupComponent, FilePopupResult } from '../../@hipalanetCommons/popups/file/file.popup.module';
import { FileUploadService, CustomFileUploader, ISelectedFile } from '../../@hipalanetCommons/fileupload/fileupload.module';
import { ProductMediaService } from '../product.core.module';

@Component({
    selector: 'basic-product',
    templateUrl: './basicproduct.component.html',
    styleUrls: ['./basicproduct.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations
})
export class BasicProductComponent implements OnInit, OnDestroy {
    // Resolve
    listProductFreightoutRateType: EnumItem<string>[];
    listThirdParty: EnumItem<string>[];

    id: string;

    private _currentEntity: Product;

    get currentEntity() {
        return this._currentEntity;
    }

    @Input('entity')
    set currentEntity(value: any) {
        if (value) {
        this._currentEntity = new Product(value);
            //debugger;
            this.medias = (this._currentEntity.medias || []).map(item => new ProductMediaGrid(item));
            this.frmMain = this.createFormBasicInfo();
        }
        else {
            this.medias = null;
        }
    }

    medias: (ProductMediaGrid | ISelectedFile)[];

    pageType: string;
    displayedColumns = ['options', 'thirdPartyAppTypeId', 'thirdPartyProductId'];

    frmMain: FormGroup;


    public customUploader: CustomFileUploader;


    // Private
    private _unsubscribeAll: Subject<any>;

    /**
     * Constructor
     *
     * @param {EcommerceProductService} _ecommerceProductService
     * @param {FormBuilder} _formBuilder
     * @param {Location} _location
     * @param {MatSnackBar} _matSnackBar
     */
    constructor(
        private route: ActivatedRoute
        , private serviceProductMedia: ProductMediaService
        , private service: ProductService
        , private _formBuilder: FormBuilder
        , private _location: Location
        , private _matSnackBar: MatSnackBar
        , private matDialog: MatDialog
        , private fileUploadService: FileUploadService
    ) {
        //debugger;
        this.customUploader = this.fileUploadService.create();

        // Set the default
        this.currentEntity = new Product();


        this.customUploader.onSelectedNew.subscribe(selectedFile => {
            this.medias.push(selectedFile);
        });

        this.customUploader.onCompleteItem.subscribe(fileUploaded => {
            let productMedia = {
                ...<IProductMedia>{
                    productId: this.currentEntity.id,
                }
                , ...fileUploaded
            };

            this.serviceProductMedia.add(productMedia).then(result => {
                //this.medias.push(fileUploaded);
            });

        });

        this.customUploader.onCompleteAll.subscribe(result => {
            this._matSnackBar.open('Product Media saved', 'OK', {
                verticalPosition: 'top',
                duration: 5000
            });

        });

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
        // Resolve
        this.listProductFreightoutRateType = this.route.snapshot.data['listProductFreightoutRateType'];
        this.listThirdParty = this.route.snapshot.data['listThirdParty'];

        // Subscribe to update product on changes
        //this.service.onCurrentEntityChanged
        //    .pipe(takeUntil(this._unsubscribeAll))
        //    .subscribe(dataResponse => {

        //        //debugger;
        //        let currentEntity = dataResponse.bag;
        //        this.id = currentEntity.id;
        //        if (currentEntity) {
        //            this.currentEntity = new Product(currentEntity);
        //            this.medias = (currentEntity.medias || []).map(item => new ProductMediaGrid(item));
        //            this.pageType = 'edit';
        //        }
        //        else {
        //            this.pageType = 'new';
        //            this.currentEntity = new Product();
        //        }

        //        this.frmMain = this.createFormBasicInfo();
        //    });
    }

    /**
     * On destroy
     */
    ngOnDestroy(): void {
        // Unsubscribe from all subscriptions
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * Create product form
     *
     * @returns {FormGroup}
     */
    createFormBasicInfo(): FormGroup {
        //debugger;
        return this._formBuilder.group({
            id: [this.currentEntity.id],
            name: [this.currentEntity.name],
        });
    }

    /**
     * Save product
     */
    save(): void {
        const basicInfoData = this.frmMain.getRawValue();

        Observable.create(observer => {
            if (!this.disableSaveFrmMain()) {
                return of(false);
            }
            else {
                return this.update(basicInfoData);
            }
        })
            .toPromise()
            .then(() => {
                //debugger;
                // Trigger the subscription with new data
                this.service.onCurrentEntityChanged.next(basicInfoData);

                // Show the success message
                this._matSnackBar.open('Product saved', 'OK', {
                    verticalPosition: 'top',
                    duration: 5000
                });
            });
    }

    /**
     * Add product
     */
    update(entity: Product): Observable<Product> {
        return Observable.create(observer => {
            this.service.save(entity)
                .then((result: Product) => {
                    observer.next(result);
                    observer.complete();
                });
        });

    }

    delete() {
        const dialogRef = this.matDialog.open(DeletePopupComponent, {
            width: '250px',
            data: <DeletePopupData>{ elementDescription: this.currentEntity.name }
        });

        dialogRef.afterClosed().subscribe((result: DeletePopupResult) => {
            if (result == 'YES') {
                this.deleteExecution();
            }
        });
    }

    deleteExecution() {
        this.service.delete(this.currentEntity.id)
            .then(() => {

                // Show the success message
                this._matSnackBar.open('Product deleted', 'OK', {
                    verticalPosition: 'top',
                    duration: 2000
                });

                // Change the location with new one
                this._location.go('apps/products');
            });
    }

    openFileDialog() {
        const dialogRef = this.matDialog.open(FilePopupComponent, {
            width: '250px',
            data: <DeletePopupData>{ elementDescription: this.currentEntity.name }
        });

        dialogRef.afterClosed().subscribe((result: FilePopupResult) => {
            if (result == 'YES') {
                this.deleteExecution();
            }
        });
    }

    disableSaveFrmMain() {
        return (this.frmMain.invalid || this.frmMain.pristine);
    }

    disableSave() {
        return this.disableSaveFrmMain();
    }
}

