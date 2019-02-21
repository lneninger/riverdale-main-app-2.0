import {
    Component,
    OnDestroy,
    OnInit,
    ViewEncapsulation,
    ViewChild
} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Location } from '@angular/common';
import {
    MatSnackBar,
    MatPaginator,
    MatSort,
    MatTable,
    MatDialog
} from '@angular/material';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import {
    Product,
    ProductMediaGrid,
    IProductMedia,
    ProductAllowedColorTypeGrid
} from './product.model';
import { ProductService } from './product.service';
import { EnumItem } from '../@resolveServices/resolve.model';
import { DataSourceAbstract } from '../@hipalanetCommons/datatable/datasource.abstract.class';
import { DataSource } from '@angular/cdk/table';
import {
    DeletePopupComponent,
    DeletePopupData,
    DeletePopupResult
} from '../@hipalanetCommons/popups/delete/delete.popup.module';
import {
    FilePopupComponent,
    FilePopupResult
} from '../@hipalanetCommons/popups/file/file.popup.module';
import {
    FileUploadService,
    CustomFileUploader,
    ISelectedFile
} from '../@hipalanetCommons/fileupload/fileupload.module';
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
    currentEntity: any;

    pageType: string;

    public customUploader: CustomFileUploader;

    // Private
    private _unsubscribeAll: Subject<any>;

    /**
     * 
     * @param route Active Route Service
     * @param serviceProductMedia Product Media Service
     * @param service Product service
     * @param _formBuilder Form Builder ReactiveForm
     * @param _location Location
     * @param _matSnackBar SnackBar service
     * @param matDialog MatDialog Service
     * @param fileUploadService FileUpload service
     */
    constructor(
        private route: ActivatedRoute,
        private serviceProductMedia: ProductMediaService,
        private service: ProductService,
        private _formBuilder: FormBuilder,
        private _location: Location,
        private _matSnackBar: MatSnackBar,
        private matDialog: MatDialog,
        private fileUploadService: FileUploadService
    ) {
        // debugger;
        this.customUploader = this.fileUploadService.create();

        // Set the default
        this.currentEntity = new Product();

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
                // debugger;
                const currentEntity = dataResponse.bag;
                this.id = currentEntity.id;
                if (currentEntity) {
                    this.currentEntity = currentEntity;
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

    isBasicProduct(entity): boolean {
        return entity && ['FLW', 'HARD'].indexOf(entity.productTypeId) !== -1;
    }

    isCompositionProduct(entity): boolean {
        return entity && ['COMP'].indexOf(entity.productTypeId) !== -1;
    }
}
