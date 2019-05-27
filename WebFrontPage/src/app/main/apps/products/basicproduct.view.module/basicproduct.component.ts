import {
    Component,
    OnDestroy,
    OnInit,
    ViewEncapsulation,
    ViewChild,
    Input
} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { Location } from '@angular/common';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import {
    MatSnackBar,
    MatPaginator,
    MatSort,
    MatTable,
    MatDialog,
    MatAutocompleteSelectedEvent,
    MatAutocomplete,
    MatChipInputEvent
} from '@angular/material';
import { Subject, Observable, of, combineLatest } from 'rxjs';
import { takeUntil, startWith, map, filter } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import {
    Product,
    ProductMediaGrid,
    IProductMedia,
    ProductAllowedColorTypeGrid
} from '../product.model';
import { ProductService } from '../product.service';
import { EnumItem } from '../../@resolveServices/resolve.model';
import { DataSourceAbstract } from '../../@hipalanetCommons/datatable/datasource.abstract.class';
import { DataSource } from '@angular/cdk/table';
import {
    DeletePopupComponent,
    DeletePopupData,
    DeletePopupResult
} from '../../@hipalanetCommons/popups/delete/delete.popup.module';
import {
    FilePopupComponent,
    FilePopupResult
} from '../../@hipalanetCommons/popups/file/file.popup.module';
import {
    FileUploadService,
    CustomFileUploader,
    ISelectedFile
} from '../../@hipalanetCommons/fileupload/fileupload.module';
import { ProductMediaService } from '../product.core.module';
import {
    ProductColorTypeResolveService,
    ProductCategoryResolveService
} from '../../@resolveServices/resolve.module';

@Component({
    selector: 'basic-product',
    templateUrl: './basicproduct.component.html',
    styleUrls: ['./basicproduct.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations
})
export class BasicProductComponent implements OnInit, OnDestroy {
    // Resolve
    listProductCategory$: Observable<EnumItem<number>[]>;

    // Settings
    @ViewChild('auto') matAutocomplete: MatAutocomplete;
    productAllowedColorTypeCtrl = new FormControl();
    separatorKeysCodes: number[] = [ENTER, COMMA];
    filteredProductAllowedColorTypes$: Observable<EnumItem<string>[]>;

    id: string;

    private _currentEntity: Product;

    get currentEntity(): Product {
        return this._currentEntity;
    }

    @Input('entity')
    set currentEntity(value: Product) {
        if (value) {
            this._currentEntity = new Product(value);
            // debugger;
            this.medias = (this._currentEntity.medias || []).map(
                item => new ProductMediaGrid(item)
            );
            this.productAllowedColorTypes = (
                this._currentEntity.productAllowedColorTypes || []
            ).map(item => new ProductAllowedColorTypeGrid(item));
            this.frmMain = this.createFormBasicInfo();
        } else {
            this.medias = null;
        }
    }

    medias: (ProductMediaGrid | ISelectedFile)[];
    productAllowedColorTypes: ProductAllowedColorTypeGrid[];

    pageType: string;
    displayedColumns = [
        'options',
        'thirdPartyAppTypeId',
        'thirdPartyProductId'
    ];

    frmMain: FormGroup;

    public customUploader: CustomFileUploader;

    // Private
    private _unsubscribeAll: Subject<any>;

    /**
     *
     * @param route Route
     * @param serviceProductMedia Product media
     * @param serviceProductCategoryResolve Product category resolve
     * @param service Service
     * @param _formBuilder Form builder
     * @param _location Location
     * @param _matSnackBar Snackbar
     * @param matDialog Material dialog
     * @param fileUploadService File upload service
     */
    constructor(
        private route: ActivatedRoute,
        private serviceProductMedia: ProductMediaService,
        // , private serviceProductAllowedColorType: ProductAllowedColorTypeService
        private serviceProductCategoryResolve: ProductCategoryResolveService,
        private service: ProductService,
        private _formBuilder: FormBuilder,
        private _location: Location,
        private _matSnackBar: MatSnackBar,
        private matDialog: MatDialog,
        private fileUploadService: FileUploadService
    ) {
        // Resolve
        // debugger;
        this.serviceProductCategoryResolve.noDependencyResolve().subscribe();

        this.listProductCategory$ = this.serviceProductCategoryResolve.onList;

        // debugger;
        this.customUploader = this.fileUploadService.create();

        // Set the default
        this.currentEntity = new Product();

        this.customUploader.onSelectedNew.subscribe(selectedFile => {
            this.medias.push(selectedFile);
        });

        this.customUploader.onCompleteItem.subscribe(fileUploaded => {
            const productMedia = {
                ...(<IProductMedia>{
                    productId: this.currentEntity.id
                }),
                ...fileUploaded
            };

            this.serviceProductMedia.add(productMedia).then(result => {
                // this.medias.push(fileUploaded);
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
        // this.service.onCurrentEntityChanged
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
        // debugger;
        return this._formBuilder.group({
            id: [this.currentEntity.id],
            name: [this.currentEntity.name],
            productCategoryId: [this.currentEntity.productCategoryId]
        });
    }

    /**
     * Save product
     */
    save(): void {
        const basicInfoData = this.frmMain.getRawValue();

        Observable.create(observer => {
            if (this.disableSaveFrmMain()) {
                observer.next(null);
                observer.complete();
            } else {
                this.service.save(basicInfoData).then(response => {
                    observer.next(response);
                    observer.complete();
                });
            }
        })
            .toPromise()
            .then(response => {
                if (response == null) {
                    return;
                }
                // debugger;
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
            this.service.save(entity).then((result: Product) => {
                observer.next(result);
                observer.complete();
            });
        });
    }

    delete(): void {
        const dialogRef = this.matDialog.open(DeletePopupComponent, {
            width: '250px',
            data: <DeletePopupData>{
                elementDescription: this.currentEntity.name
            }
        });

        dialogRef.afterClosed().subscribe((result: DeletePopupResult) => {
            if (result === 'YES') {
                this.deleteExecution();
            }
        });
    }

    deleteExecution(): void {
        this.service.delete(this.currentEntity.id).then(() => {
            // Show the success message
            this._matSnackBar.open('Product deleted', 'OK', {
                verticalPosition: 'top',
                duration: 2000
            });

            // Change the location with new one
            this._location.go('apps/products');
        });
    }

    openFileDialog(): void {
        const dialogRef = this.matDialog.open(FilePopupComponent, {
            width: '250px',
            data: <DeletePopupData>{
                elementDescription: this.currentEntity.name
            }
        });

        dialogRef.afterClosed().subscribe((result: FilePopupResult) => {
            if (result === 'YES') {
                this.deleteExecution();
            }
        });
    }

    disableSaveFrmMain(): boolean {
        return this.frmMain.invalid || this.frmMain.pristine;
    }

    disableSave(): boolean {
        return this.disableSaveFrmMain();
    }

    async deleteMedia(media: ProductMediaGrid): Promise<any> {
        await this.customUploader.delete(media.id).then(() => {
            debugger;
            const mediaIndex = this.medias.findIndex(
                mediaItem => (<ProductMediaGrid>mediaItem).id === media.id
            );
            this.medias.splice(mediaIndex, 1);
        });
    }
}
