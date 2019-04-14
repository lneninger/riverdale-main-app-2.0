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

import { ProductCategory, /*ProductCategorySizeGrid, */ProductCategoryAllowedColorTypeGrid, ProductCategoryAllowedSizeGrid } from './productcategory.model';
import { ProductCategoryService } from './productcategory.service';
import { EnumItem } from '../@resolveServices/resolve.model';
import { DataSourceAbstract } from '../@hipalanetCommons/datatable/datasource.abstract.class';
import { DataSource } from '@angular/cdk/table';
import { DeletePopupComponent, DeletePopupData, DeletePopupResult } from '../@hipalanetCommons/popups/delete/delete.popup.module';
import { FilePopupComponent, FilePopupResult } from '../@hipalanetCommons/popups/file/file.popup.module';
import { FileUploadService, CustomFileUploader, ISelectedFile } from '../@hipalanetCommons/fileupload/fileupload.module';
import { ProductColorTypeResolveService } from '../@resolveServices/resolve.module';
import { ProductCategoryAllowedColorTypeService } from './productcategoryallowedcolortype.service';
import { ProductCategoryAllowedSizeService } from './productcategoryallowedsize.service';

@Component({
    selector: 'flower-product-category',
    templateUrl: './productcategory.component.html',
    styleUrls: ['./productcategory.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations
})
export class ProductCategoryComponent implements OnInit, OnDestroy {
    // Resolve
    listProductColorType$: Observable<EnumItem<string>[]>;

    // Settings
    @ViewChild('auto') matAutocomplete: MatAutocomplete;
    productAllowedColorTypeCtrl = new FormControl();
    allowSizeCtrl = new FormControl();

    separatorKeysCodes: number[] = [ENTER, COMMA];
    filteredProductAllowedColorTypes$: Observable<EnumItem<string>[]>;

    allowedSizes: ProductCategoryAllowedSizeGrid[];
    allowedColors: ProductCategoryAllowedColorTypeGrid[];

    id: string;

    private _currentEntity: ProductCategory;

    get currentEntity(): ProductCategory {
        return this._currentEntity;
    }

    @Input('entity')
    set currentEntity(value: ProductCategory) {
        if (value) {
            this._currentEntity = new ProductCategory(value);
            //debugger;
            this.allowedSizes = (this._currentEntity.allowedSizes || []).map(item => new ProductCategoryAllowedSizeGrid(item));
            this.allowedColors = (this._currentEntity.allowedColors || []).map(item => new ProductCategoryAllowedColorTypeGrid(item));
            this.frmMain = this.createFormBasicInfo();
        }

    }

    productAllowedColorTypes: ProductCategoryAllowedColorTypeGrid[];


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
        , private serviceProductCategoryAllowedColorType: ProductCategoryAllowedColorTypeService
        , private serviceProductCategoryAllowedSize: ProductCategoryAllowedSizeService

        , private serviceProductColorTypeResolve: ProductColorTypeResolveService
        , private service: ProductCategoryService
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
        this.currentEntity = new ProductCategory();

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
        this.service.onCurrentEntityChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(dataResponse => {

                //debugger;
                let currentEntity = dataResponse.bag;
                this.id = currentEntity.id;
                if (currentEntity) {
                    this.currentEntity = new ProductCategory(currentEntity);
                    this.pageType = 'edit';
                }
                else {
                    this.pageType = 'new';
                    this.currentEntity = new ProductCategory();
                }

                this.frmMain = this.createFormBasicInfo();
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
            identifier: [this.currentEntity.identifier],
            name: [this.currentEntity.name],
            //productColorTypeId: [this.currentEntity.productColorTypeId],
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
    update(entity: ProductCategory): Observable<ProductCategory> {
        return Observable.create(observer => {
            this.service.save(entity)
                .then((result: ProductCategory) => {
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
    selectedProductCategoryAllowedColorType(event: MatAutocompleteSelectedEvent): void {
        //debugger;
        const productColortTypeId = event.option.value;
        this.listProductColorType$.pipe(map(list => list.find(item => item.key == <string>event.option.value)))
            .pipe(filter(item => !!item))
            .subscribe(item => {
                this.addProductCategoryAllowedColorType(item);
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
                    this.addProductCategoryAllowedColorType(item);
                });
        }
    }

    removeProductAllowedColorType(item: ProductCategoryAllowedColorTypeGrid): void {
        //debugger;
        const index = this.allowedColors.indexOf(item);
        if (index >= 0) {
            this.serviceProductCategoryAllowedColorType.delete(this.allowedColors[index].id).then(response => {
                //debugger;
                const afterDeleteIndex = this.allowedColors.findIndex(colorItem => colorItem.id == response.bag.id);
                if (afterDeleteIndex != -1) {
                    this.allowedColors.splice(afterDeleteIndex, 1);
                }
            });
        }
    }

    addProductCategoryAllowedColorType(item: EnumItem<string>) {
        let allowedColorType = <ProductCategoryAllowedColorTypeGrid>{ productCategoryId: this.currentEntity.id, productColorTypeId: item.key };
        this.serviceProductCategoryAllowedColorType.add(allowedColorType).then(response => {
            //debugger;
            this.allowedColors.push(response.bag);
            this.productAllowedColorTypeCtrl.setValue(null);

        });
    }



    addTypedSize(event: MatChipInputEvent): void {
        //debugger;
        const value = event.value;
        this.addAllowedSize(value);
    }

    removeAllowedSize(item: ProductCategoryAllowedSizeGrid): void {
        //debugger;
        const index = this.allowedSizes.indexOf(item);
        if (index >= 0) {
            this.serviceProductCategoryAllowedSize.delete(this.allowedSizes[index].id).then(response => {
                debugger;
                const afterDeleteIndex = this.allowedSizes.findIndex(sizeItem => sizeItem.id == response.bag.id);
                if (afterDeleteIndex != -1) {
                    this.allowedSizes.splice(afterDeleteIndex, 1);
                }
            });
        }
    }

    addAllowedSize(size: string) {
        let allowedSize = <ProductCategoryAllowedSizeGrid>{ productCategoryId: this.currentEntity.id, size: size };
        this.serviceProductCategoryAllowedSize.add(allowedSize).then(response => {
            //debugger;
            this.allowedSizes.push(response.bag);
            this.allowSizeCtrl.setValue(null);

        });
    }
}

