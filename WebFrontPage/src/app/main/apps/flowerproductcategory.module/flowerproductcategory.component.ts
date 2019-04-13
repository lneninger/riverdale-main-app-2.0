import { Component, OnDestroy, OnInit, ViewEncapsulation, ViewChild, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { Location } from '@angular/common';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { MatSnackBar, MatPaginator, MatSort, MatTable, MatDialog, MatAutocompleteSelectedEvent, MatAutocomplete, MatChipInputEvent } from '@angular/material';
import { Subject, Observable, of, combineLatest } from 'rxjs';
import { takeUntil, startWith, map, filter } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import { FlowerProductCategory, FlowerProductCategoryGradeGrid } from './flowerproductcategory.model';
import { FlowerProductCategoryService } from './flowerproductcategory.service';
import { EnumItem } from '../@resolveServices/resolve.model';
import { DataSourceAbstract } from '../@hipalanetCommons/datatable/datasource.abstract.class';
import { DataSource } from '@angular/cdk/table';
import { DeletePopupComponent, DeletePopupData, DeletePopupResult } from '../../@hipalanetCommons/popups/delete/delete.popup.module';
import { FilePopupComponent, FilePopupResult } from '../@hipalanetCommons/popups/file/file.popup.module';
import { FileUploadService, CustomFileUploader, ISelectedFile } from '../@hipalanetCommons/fileupload/fileupload.module';

@Component({
    selector: 'flower-product-category',
    templateUrl: './flowerproductcategory.component.html',
    styleUrls: ['./flowerproductcategory.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations
})
export class FlowerProductCategoryComponent implements OnInit, OnDestroy {
    // Resolve
    listProductColorType$: Observable<EnumItem<string>[]>;

    // Settings
    @ViewChild('auto') matAutocomplete: MatAutocomplete;
    productAllowedColorTypeCtrl = new FormControl();
    separatorKeysCodes: number[] = [ENTER, COMMA];
    filteredProductAllowedColorTypes$: Observable<EnumItem<string>[]>;



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
            this.productAllowedColorTypes = (this._currentEntity.grades || []).map(item => new FlowerProductCategroyGradeGrid(item));
            this.frmMain = this.createFormBasicInfo();
        }
        else {
            this.medias = null;
        }
    }

    medias: (ProductMediaGrid | ISelectedFile)[];
    productAllowedColorTypes: ProductAllowedColorTypeGrid[];


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
        , private serviceProductAllowedColorType: ProductAllowedColorTypeService
        , private serviceProductColorTypeResolve: ProductColorTypeResolveService
        , private service: ProductService
        , private _formBuilder: FormBuilder
        , private _location: Location
        , private _matSnackBar: MatSnackBar
        , private matDialog: MatDialog
        , private fileUploadService: FileUploadService
    ) {
        // Settings
        this.filteredProductAllowedColorTypes$ =
            combineLatest([
            this.productAllowedColorTypeCtrl.valueChanges.pipe(startWith(null)),
            this.listProductColorType$
            ], (productId: string | null, listProductColorType: EnumItem<string>[]) => productId != null
                ? listProductColorType.filter(item => item.value.toLowerCase().indexOf(productId) === 0)
                : listProductColorType);

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
        this.listProductColorType$ = this.serviceProductColorTypeResolve.onList;

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
            productColorTypeId: [this.currentEntity.productColorTypeId],
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
            }
            else {
                this.service.save(basicInfoData)
                    .then((response) => {
                        observer.next(response);
                        observer.complete();
                    })
            }
        })
            .toPromise()
            .then((response) => {
                if (response == null) {
                    return;
                }
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


    /**********************************ProductAllowedColorType************************************/
    getProductColorType(productColorTypeId: string) {
        return this.listProductColorType$.pipe(map(list => list.find(item => item.key == productColorTypeId) || {}));
    }

    private _filterProductAllowedColorTypes(value: string): Observable<EnumItem<string>[]> {
        const filterValue = value.toLowerCase();
        return this.listProductColorType$.pipe(map(list => list.filter(item => item.value.toLowerCase().indexOf(filterValue) === 0)));
    }
    selectedProductAllowedColorType(event: MatAutocompleteSelectedEvent): void {
        //debugger;
        const productColortTypeId = event.option.value;
        this.listProductColorType$.pipe(map(list => list.find(item => item.key == <string>event.option.value)))
            .pipe(filter(item => !!item))
            .subscribe(item => {
                this.addProductAllowedColorType(item);
            });
    }
    addTypedColorType(event: MatChipInputEvent): void {
        // Add fruit only when MatAutocomplete is not open
        // To make sure this does not conflict with OptionSelected Event
        if (!this.matAutocomplete.isOpen) {
            const value = event.value;
            const selectedItem = this.listProductColorType$.pipe(map(list => list.find(item => item.key == value)))
                .pipe(filter(item => !!item))
                .subscribe(item => {
                    this.addProductAllowedColorType(item);
                });
        }
    }

    removeProductAllowedColorType(item: ProductAllowedColorTypeGrid): void {
        const index = this.productAllowedColorTypes.indexOf(item);
        if (index >= 0) {
            this.serviceProductAllowedColorType.delete(this.productAllowedColorTypes[index].id).then(response => {
                //debugger;
            });
        }
    }

    addProductAllowedColorType(item: EnumItem<string>) {
        let allowedColorType = <ProductAllowedColorTypeGrid>{ productId: this.currentEntity.id, productColorTypeId: item.key };
        this.serviceProductAllowedColorType.add(allowedColorType).then(response => {
            // debugger;
            this.productAllowedColorTypes.push(response.bag);
            this.productAllowedColorTypeCtrl.setValue(null);

        });
    }
}

