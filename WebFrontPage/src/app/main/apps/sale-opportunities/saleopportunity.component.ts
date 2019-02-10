import { Component, OnDestroy, OnInit, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Location } from '@angular/common';
import { MatSnackBar, MatPaginator, MatSort, MatTable, MatDialog } from '@angular/material';
import { Subject, Observable, of } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import { SaleOpportunity, ProductGrid } from './saleopportunity.model';
import { EnumItem } from '../@resolveServices/resolve.model';
import { DataSourceAbstract } from '../@hipalanetCommons/datatable/datasource.abstract.class';
import { DataSource } from '@angular/cdk/table';
import { DeletePopupComponent, DeletePopupData, DeletePopupResult } from '../@hipalanetCommons/popups/delete/delete.popup.module';
import { FilePopupComponent, FilePopupResult } from '../@hipalanetCommons/popups/file/file.popup.module';
import { FileUploadService, CustomFileUploader, ISelectedFile } from '../@hipalanetCommons/fileupload/fileupload.module';
import { SaleOpportunityService } from './saleopportunity.core.module';

@Component({
    selector: 'sale-opportunity',
    templateUrl: './saleopportunity.component.html',
    styleUrls: ['./saleopportunity.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations
})
export class SaleOpportunityComponent implements OnInit, OnDestroy {
    // Resolve
    id: string;
    currentEntity: any;
    medias: (ProductGrid | ISelectedFile)[];


    pageType: string;

    frmMain: FormGroup;


    public customUploader: CustomFileUploader;


    // Private
    private _unsubscribeAll: Subject<any>;

    /**
     * Constructor
     *
     * @param _ecommerceProductService
     * @param _formBuilder
     * @param _location
     * @param _matSnackBar
     */
    constructor(
        private route: ActivatedRoute
        //, private serviceProductMedia: ProductService
        , private service: SaleOpportunityService
        , private _formBuilder: FormBuilder
        , private _location: Location
        , private _matSnackBar: MatSnackBar
        , private matDialog: MatDialog
        , private fileUploadService: FileUploadService
    ) {

        // Set the default
        this.currentEntity = new SaleOpportunity();

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

    isOpportunityProduct(entity): boolean {
        return entity && ['COMP'].indexOf(entity.productTypeId) !== -1;
    }

}

