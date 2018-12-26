import { Component, OnDestroy, OnInit, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Location } from '@angular/common';
import { MatSnackBar, MatPaginator, MatSort, MatTable, MatDialog } from '@angular/material';
import { Subject, Observable, of } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import { Product, ProductMediaGrid, IProductMedia } from './product.model';
import { ProductService } from './product.service';
import { EnumItem } from '../@resolveServices/resolve.model';
import { DataSourceAbstract } from '../@hipalanetCommons/datatable/datasource.abstract.class';
import { DataSource } from '@angular/cdk/table';
import { DeletePopupComponent, DeletePopupData, DeletePopupResult } from '../@hipalanetCommons/popups/delete/delete.popup.module';
import { FilePopupComponent, FilePopupResult } from '../@hipalanetCommons/popups/file/file.popup.module';
import { FileUploadService, CustomFileUploader, ISelectedFile } from '../@hipalanetCommons/fileupload/fileupload.module';
import { ProductMediaService } from './product.core.module';

@Component({
    selector: 'product',
    templateUrl: './product.component.html',
    styleUrls: ['./product.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations
})
export class ProductComponent implements OnInit, OnDestroy {
    // Resolve
    id: string;
    currentEntity: Product;
    medias: (ProductMediaGrid | ISelectedFile)[];

    pageType: string;

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

        // Subscribe to update product on changes
        this.service.onCurrentEntityChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(dataResponse => {

                //debugger;
                let currentEntity = dataResponse.bag;
                this.id = currentEntity.id;
                if (currentEntity) {
                    this.currentEntity = new Product(currentEntity);
                }
            });
    }

    /**
     * On destroy
     */
    ngOnDestroy(): void {
        // Unsubscribe from all subscriptions
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }

    isBasicProduct(entity) {
        return entity && ['FLW', 'HARD'].indexOf(entity.productTypeId) != -1;
    }

    isCompositionProduct(entity) {
        return entity && ['COMP'].indexOf(entity.productTypeId) != -1;
    }

}

