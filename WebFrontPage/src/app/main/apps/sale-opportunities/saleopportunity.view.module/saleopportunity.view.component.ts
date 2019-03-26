import {
    Component,
    OnDestroy,
    OnInit,
    ViewEncapsulation,
    Input,
    Inject
} from "@angular/core";
import {
    FormControl,
    FormGroup,
    FormBuilder,
    FormArray,
    Validators
} from "@angular/forms";
import { ActivatedRoute } from "@angular/router";
import { Subject, Subscription, Observable, of } from "rxjs";
import {
    debounceTime,
    distinctUntilChanged,
    takeUntil,
    mergeMap
} from "rxjs/operators";

import { fuseAnimations } from "@fuse/animations";
import { FuseSidebarService } from "@fuse/components/sidebar/sidebar.service";

import { Todo } from "./saleopportunity.view.model";
import {
    SaleOpportunity,
    ProductGrid,
    SampleBoxItem,
    SampleBoxGrid,
    SampleBoxProductItem,
    SampleBoxItemNewDialogOutput,
    SampleBoxItemNewDialogInput,
    SaleOpportunityTargetPriceNewDialogInput,
    SaleOpportunityTargetPriceNewDialogOutput,

    TargetPriceProductItem,
    TargetPriceItem,
    SaleOpportunityTargetPriceProductNewDialogInput
} from "../saleopportunity.model";
import { SaleOpportunityViewService } from "./saleopportunity.view.service";
import { ISelectedFile } from "../../@hipalanetCommons/fileupload/fileupload.model";
import { SaleOpportunityService } from "../saleopportunity.core.module";
import { CustomValidators } from "ng4-validators";
import {
    MatSnackBar,
    MatDialogRef,
    MAT_DIALOG_DATA,
    MatDialog
} from "@angular/material";
import { OperationResponseValued } from "../../@hipalanetCommons/messages/messages.model";
import {
    ProductColorTypeResolveService,
    EnumItem,
    SaleSeasonCategoryTypeResolveService
} from "../../@resolveServices/resolve.module";
import { SaleOpportunityTargetPriceNewDialogComponent } from "./saleopportunity.view-targetprice/saleopportunities-targetpricenew.dialog.component";
import { SampleBoxProductNewDialogComponent } from "./saleopportunity.view-sampleboxes/saleopportuny.view-sampleboxnew.dialog.component";
import { SaleOpportunityTargetPriceProductNewDialogComponent } from "./saleopportunity.view-targetprice/saleopportunities-targetpriceproductnew.dialog.component";

@Component({
    selector: "saleopportunity-view",
    templateUrl: "./saleopportunity.view.component.html",
    styleUrls: ["./saleopportunity.view.component.scss"],
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations
})
export class SaleOpportunityViewComponent implements OnInit, OnDestroy {
    private _currentEntity: SaleOpportunity;

    get currentEntity(): SaleOpportunity {
        return this._currentEntity;
    }

    get showProductsSidebar(): boolean {
        return this.currentEntity && !this.showCustomerSidebar;
    }

    _currentSampleBox: SampleBoxItem;
    onSampleBoxSelected: Subscription;
    get currentSampleBox(): SampleBoxItem {
        return this._currentSampleBox;
    }
    set currentSampleBox(value: SampleBoxItem) {
        this.saleOpportunityService.toggleSampleBox(value);
    }

    _currentSampleBoxProduct: SampleBoxProductItem;
    onSampleBoxProductSelected: Subscription;
    get currentSampleBoxProduct(): SampleBoxProductItem {
        return this._currentSampleBoxProduct;
    }
    set currentSampleBoxProduct(value: SampleBoxProductItem) {
        this.saleOpportunityService.toggleSampleBoxProduct(value);
    }

    _currentTargetPrice: TargetPriceItem;
    onTargetPriceSelected: Subscription;
    get currentTargetPrice(): TargetPriceItem {
        return this._currentTargetPrice;
    }
    set currentTargetPrice(value: TargetPriceItem) {
        this.saleOpportunityService.toggleTargetPrice(value);
    }

    _currentTargetPriceProduct: TargetPriceProductItem;
    onTargetPriceProductSelected: Subscription;
    get currentTargetPriceProduct(): TargetPriceProductItem {
        return this._currentTargetPriceProduct;
    }
    set currentTargetPriceProduct(value: TargetPriceProductItem) {
        this.saleOpportunityService.toggleTargetPriceProduct(value);
    }

    showCustomerSidebar: boolean;
    activeArea: ActiveAreaType;
    activeDetailArea: ActiveDetailAreaType;

    @Input("entity")
    set currentEntity(value: SaleOpportunity) {
        if (this._currentEntity !== value) {
            this._currentEntity = new SaleOpportunity(value);
            this.sampleBoxes = this._currentEntity.sampleBoxes;
            this.frmMain = this.createFormBasicInfo();
        } else {
            this.sampleBoxes = null;
        }
    }

    sampleBoxes: SampleBoxGrid[];

    frmMain: FormGroup;
    frmSampleBoxItems: FormArray;
    frmSampleBoxProductItems: FormArray;

    frmTargetPriceItems: FormArray;
    frmTargetPriceProductItems: FormArray;

    hasSelectedTodos: boolean;
    isIndeterminate: boolean;
    filters: any[];
    tags: any[];
    searchInput: FormControl;
    currentTodo: Todo;

    // Private
    private _unsubscribeAll: Subject<any>;

    /**
     *
     * @param route Current route service
     * @param _fuseSidebarService  sidebar component
     * @param _todoService Todo Service
     * @param _formBuilder FormBuilder Provider
     * @param saleOpportunityService  Sale Opportunity Service
     * @param _matSnackBar Snackbar
     */
    constructor(
        private route: ActivatedRoute,
        private _fuseSidebarService: FuseSidebarService,
        private _todoService: SaleOpportunityViewService,
        private _formBuilder: FormBuilder,
        private saleOpportunityService: SaleOpportunityService,
        public dialog: MatDialog,
        private matSnackBar: MatSnackBar,
        private saleSeasonTypeResolveService: SaleSeasonCategoryTypeResolveService
    ) {
        // Set the defaults
        this.searchInput = new FormControl("");

        // Set the private defaults
        this._unsubscribeAll = new Subject();

        this.saleOpportunityService.onSampleBoxItemAdded.subscribe(
            this.onSampleBoxItemAdded.bind(this)
        );
        this.saleOpportunityService.onSampleBoxItemUpdated.subscribe(
            this.onSampleBoxItemUpdated.bind(this)
        );
        this.saleOpportunityService.onTargetPriceItemAdded.subscribe(
            this.onTargetPriceItemAdded.bind(this)
        );
        this.saleOpportunityService.onTargetPriceItemUpdated.subscribe(
            this.onTargetPriceItemUpdated.bind(this)
        );

        this.saleOpportunityService.onTargetPriceProductItemAdded.subscribe(
            this.onTargetPriceProductItemAdded.bind(this)
        );
        this.saleOpportunityService.onTargetPriceProductItemUpdated.subscribe(
            this.onTargetPriceProductItemUpdated.bind(this)
        );

        this.onSampleBoxSelected = this.saleOpportunityService.onSampleBoxSelected.subscribe(
            sampleBox => {
                debugger;
                this._currentSampleBox = sampleBox;
            }
        );

        this.onSampleBoxProductSelected = this.saleOpportunityService.onSampleBoxProductSelected.subscribe(
            sampleBoxProduct => {
                this._currentSampleBoxProduct = sampleBoxProduct;
            }
        );


        this.onTargetPriceSelected = this.saleOpportunityService.onTargetPriceSelected.subscribe(
            targetPrice => {
                debugger;
                this._currentTargetPrice = targetPrice;
            }
        );

        this.onTargetPriceProductSelected = this.saleOpportunityService.onTargetPriceProductSelected.subscribe(
            targetPriceProduct => {
                debugger;
                this._currentTargetPriceProduct = targetPriceProduct;
            }
        );
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void {
        // debugger;
        this.currentEntity = this.saleOpportunityService.currentEntity;
        this.activeRouteListeners();
        this.frmSampleBoxItems = this._formBuilder.array([]);
        this.currentEntity.sampleBoxes.forEach(item => {
            this.frmSampleBoxItems.push(this.createFormSampleBoxItem(item));
        });

        this.frmTargetPriceItems = this._formBuilder.array([]);
        this.currentEntity.targetPrices.forEach(item => {
            this.frmTargetPriceItems.push(this.createFormTargetPriceItem(item));
        });

        this._todoService.onSelectedTodosChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(selectedTodos => {
                if (
                    selectedTodos &&
                    (this._todoService.todos && this._todoService.todos.length)
                ) {
                    setTimeout(() => {
                        this.hasSelectedTodos = selectedTodos.length > 0;
                        this.isIndeterminate =
                            selectedTodos.length !==
                            this._todoService.todos.length &&
                            selectedTodos.length > 0;
                    }, 0);
                }
            });

        this._todoService.onFiltersChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(folders => {
                this.filters = this._todoService.filters;
            });

        this._todoService.onTagsChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(tags => {
                this.tags = this._todoService.tags;
            });

        this.searchInput.valueChanges
            .pipe(
                takeUntil(this._unsubscribeAll),
                debounceTime(300),
                distinctUntilChanged()
            )
            .subscribe(searchText => {
                this._todoService.onSearchTextChanged.next(searchText);
            });

        this._todoService.onCurrentTodoChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(([currentTodo, formType]) => {
                if (!currentTodo) {
                    this.currentTodo = null;
                } else {
                    this.currentTodo = currentTodo;
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

    activeRouteListeners(): void {
        this.route.queryParams.subscribe(params => {
            // debugger;
            if (params.newbouquet) {
                debugger;
                this.openTargetPriceProductDialog(params.newbouquet);
            } else if (params.newtargetprice) {
                debugger;
                this.saleSeasonTypeResolveService.noDependencyResolve(false).subscribe();
                this.openTargetPriceDialog();
            }
        });
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------
    /**
     * Create product form
     *
     * @returns Basic Info
     */
    createFormBasicInfo(): FormGroup {
        // debugger;
        return this._formBuilder.group({
            id: [this.currentEntity.id],
            name: [this.currentEntity.name]
        });
    }

    createFormSampleBoxItem(item: SampleBoxItem): FormGroup {
        const result = this._formBuilder.group({
            id: [item.id, [Validators.required, CustomValidators.number]],
            order: [item.order, [Validators.required, CustomValidators.number]],
            parentSampleBoxId: [
                item.parentSampleBoxId,
                [CustomValidators.number]
            ],
            selected: "selected"
        });

        result.controls["selected"].valueChanges.subscribe(value => { });

        return result;
    }



    createFormSampleBoxProductItem(item: SampleBoxProductItem): FormGroup {
        const result = this._formBuilder.group({
            id: [item.id, [Validators.required, CustomValidators.number]],
            name: [item.productName, [Validators.required]],
            selected: ""
        });

        result.controls["selected"].valueChanges.subscribe(value => { });

        return result;
    }

    createFormTargetPriceItem(item: TargetPriceItem): FormGroup {
        const result = this._formBuilder.group({
            id: [item.id, [Validators.required, CustomValidators.number]],
            name: [item.name, [Validators.required, Validators.maxLength(6)]],
            alternativesAmount: [item.alternativesAmount, [Validators.required, CustomValidators.number]],
            saleSeasonTypeId: [item.saleSeasonTypeId, [Validators.required, CustomValidators.number]],
            selected: "selected"
        });

        result.controls["selected"].valueChanges.subscribe(value => { });

        return result;
    }

    createFormTargetPriceProductItem(item: TargetPriceProductItem): FormGroup {
        const result = this._formBuilder.group({
            id: [item.id, [Validators.required, CustomValidators.number]],
            name: [item.productName, [Validators.required]],
            selected: ""
        });

        result.controls["selected"].valueChanges.subscribe(value => { });

        return result;
    }

    updateFormSampleBoxItem(formGroup: FormGroup, item: SampleBoxItem): void {
        const value = {
            id: item.id,
            name: item.name,
            parentSampleBoxId: item.parentSampleBoxId
        };

        formGroup.reset(value);
    }

    updateFormSampleBoxProductItem(
        formGroup: FormGroup,
        item: SampleBoxProductItem
    ): void {
        const value = {
            id: item.id,
            productColorTypeId: item.productColorTypeId,
            productId: item.productId,
            productName: item.productName,
            productPictureId: item.productPictureId,
            productTypeId: item.productTypeId,
            productTypevName: item.productTypeName,
            productTypeDescription: item.productTypeDescription
        };

        formGroup.reset(value);
    }


    updateFormTargetPriceItem(formGroup: FormGroup, item: TargetPriceItem): void {
        const value = {
            id: item.id,
            name: item.name,
            alternativesAmount: item.alternativesAmount,
            seasonName: item.seasonName,
            targetPrice: item.targetPrice,
        };

        formGroup.reset(value);
    }

    updateFormTargetPriceProductItem(
        formGroup: FormGroup,
        item: TargetPriceProductItem
    ): void {
        const value = {
            id: item.id,
            productColorTypeId: item.productColorTypeId,
            productId: item.productId,
            productName: item.productName,
            productPictureId: item.productPictureId,
            productTypeId: item.productTypeId,
            productTypevName: item.productTypeName,
            productTypeDescription: item.productTypeDescription
        };

        formGroup.reset(value);
    }

    /**
     * Deselect current todo
     */
    deselectCurrentTodo(): void {
        this._todoService.onCurrentTodoChanged.next([null, null]);
    }

    /**
     * Toggle select all
     */
    toggleSelectAll(): void {
        this._todoService.toggleSelectAll();
    }

    /**
     * Select todos
     *
     * @param filterParameter Filter Parameter
     * @param filterValue Filter Value
     */
    selectTodos(filterParameter?, filterValue?): void {
        this._todoService.selectTodos(filterParameter, filterValue);
    }

    /**
     * Deselect todos
     */
    deselectTodos(): void {
        this._todoService.deselectTodos();
    }

    /**
     * Toggle tag on selected todos
     *
     * @param tagId Tag Id
     */
    toggleTagOnSelectedTodos(tagId): void {
        this._todoService.toggleTagOnSelectedTodos(tagId);
    }

    /**
     * Toggle the sidebar
     *
     * @param name Toggle Sidebar
     */
    toggleSidebar(name): void {
        this._fuseSidebarService.getSidebar(name).toggleOpen();
    }

    onSampleBoxItemAdded(item: SampleBoxItem): void {
        // debugger;
        this.frmSampleBoxItems.push(this.createFormSampleBoxItem(item));
        this.currentEntity.sampleBoxes.push(item);
        this.matSnackBar.open("Sample Box Added", "OK", {
            verticalPosition: "top",
            duration: 5000
        });
    }

    onSampleBoxProductItemAdded(item: SampleBoxProductItem): void {
        // debugger;
        this.frmSampleBoxProductItems.push(
            this.createFormSampleBoxProductItem(item)
        );
        const sampleBox = this.currentEntity.sampleBoxes.find(
            o => o.id === item.sampleBoxId
        );
        if (sampleBox !== null) {
            sampleBox.sampleBoxProducts.push(item);
        }
        this.matSnackBar.open("Product Add", "OK", {
            verticalPosition: "top",
            duration: 5000
        });
    }

    onSampleBoxItemUpdated(item: SampleBoxItem): void {
        // debugger;
        const index = this.currentEntity.sampleBoxes.findIndex(
            sampleBoxItem => sampleBoxItem.id === item.id
        );
        if (index >= 0) {
            this.currentEntity.sampleBoxes.splice(index, 1, item);
            this.updateFormSampleBoxItem(
                <FormGroup>this.frmSampleBoxItems.controls[index],
                item
            );

            this.matSnackBar.open("Product Updated", "OK", {
                verticalPosition: "top",
                duration: 5000
            });
        }
    }

    onSampleBoxProductItemUpdated(item: SampleBoxProductItem): void {
        // debugger;
        const sampleBox = this.currentEntity.sampleBoxes.find(
            relatedPorductItem => relatedPorductItem.id === item.id
        );
        if (sampleBox !== null) {
            const index = sampleBox.sampleBoxProducts.findIndex(
                productItem => productItem.id === item.id
            );
            if (index >= 0) {
                sampleBox.sampleBoxProducts.splice(index, 1, item);
                this.updateFormSampleBoxProductItem(
                    <FormGroup>this.frmSampleBoxProductItems.controls[index],
                    item
                );

                this.matSnackBar.open("Product Updated", "OK", {
                    verticalPosition: "top",
                    duration: 5000
                });
            }
        }
    }

    onTargetPriceItemAdded(item: TargetPriceItem): void {
        debugger;
        this.frmTargetPriceItems.push(this.createFormTargetPriceItem(item));
        this.currentEntity.targetPrices.push(item);
        this.matSnackBar.open("Target Price Added", "OK", {
            verticalPosition: "top",
            duration: 5000
        });
    }

    onTargetPriceItemUpdated(item: TargetPriceItem): void {
        // debugger;
        const index = this.currentEntity.targetPrices.findIndex(
            targetPriceItem => targetPriceItem.id === item.id
        );
        if (index >= 0) {
            this.currentEntity.targetPrices.splice(index, 1, item);
            this.updateFormTargetPriceItem(
                <FormGroup>this.frmTargetPriceItems.controls[index],
                item
            );

            this.matSnackBar.open("Product Updated", "OK", {
                verticalPosition: "top",
                duration: 5000
            });
        }
    }

    onTargetPriceProductItemAdded(item: TargetPriceProductItem): void {

        this.currentTargetPrice.saleOpportunityTargetPriceProducts.push(item);
        this.frmTargetPriceProductItems.push(this.createFormTargetPriceProductItem(item));

        this.matSnackBar.open("Target Price Product added", "OK", {
            verticalPosition: "top",
            duration: 5000
        });
    }
    onTargetPriceProductItemUpdated(item: TargetPriceProductItem): void {
        // debugger;
        const targetPrice = this.currentEntity.targetPrices.find(
            relatedPorductItem => relatedPorductItem.id === item.id
        );
        if (targetPrice !== null) {
            const index = targetPrice.saleOpportunityTargetPriceProducts.findIndex(
                productItem => productItem.id === item.id
            );
            if (index >= 0) {
                targetPrice.saleOpportunityTargetPriceProducts.splice(index, 1, item);
                this.updateFormTargetPriceProductItem(
                    <FormGroup>this.frmTargetPriceProductItems.controls[index],
                    item
                );

                this.matSnackBar.open("Target Price Updated", "OK", {
                    verticalPosition: "top",
                    duration: 5000
                });
            }
        }
    }


    setActiveArea(area: ActiveAreaType): void {
        this.activeArea = area;
    }

    setActiveDetailArea(area: ActiveDetailAreaType): void {
        this.activeDetailArea = area;
    }

    addSampleBox(): void {
        // debugger;
        const sampleBox = <SampleBoxItem>{};
        sampleBox.saleOpportunityId = this.currentEntity.id;
        this.saleOpportunityService.addSampleBoxItem(sampleBox);
    }

    addBouquet(): void {
        // debugger;
        // const sampleBoxProduct = <SampleBoxProductItem>{};
        // sampleBoxProduct.sampleBoxId = this.currentSampleBox.id;
        // this.saleOpportunityService.addSampleBoxProductItem(sampleBoxProduct);
    }



    openSampleBoxProductDialog(): void {
        const dialogRef = this.dialog.open(SampleBoxProductNewDialogComponent, {
            width: "60%",
            data: <SampleBoxItemNewDialogInput>{
                sampleBoxId: this.currentSampleBox.id
                /* name: this.name, animal: this.animal */
            }
        });

        dialogRef
            .afterClosed()
            .subscribe((result: SampleBoxItemNewDialogOutput) => {
                if (result && result.goTo === "Edit") {
                    this.saleOpportunityService.router.navigate([
                        `apps/productcolors/${result.data.id}`
                    ]);
                } else {
                    this.saleOpportunityService.router.navigate([`../`], {
                        relativeTo: this.route
                    });
                    // this.dataSource.dataChanged.next('');
                }
            });
    }

    openTargetPriceDialog(): void {
        // debugger;
        const dialogRef = this.dialog.open(
            SaleOpportunityTargetPriceNewDialogComponent,
            {
                width: "60%",
                data: <SaleOpportunityTargetPriceNewDialogInput>{
                    saleOpportunityId: this.currentEntity.id
                    /* name: this.name, animal: this.animal */
                }
            }
        );

        dialogRef
            .afterClosed()
            .subscribe((result: SaleOpportunityTargetPriceNewDialogOutput) => {
                debugger;
                const queryParams = this.route.snapshot.queryParams;
                const newQueryParams = { ...queryParams }
                delete newQueryParams['newtargetprice'];
                this.saleOpportunityService.router.navigate(['.'], {
                    relativeTo: this.route,
                    queryParams: newQueryParams
                });

            });
    }


    openTargetPriceProductDialog(productId?: number): void {
        const dialogRef = this.dialog.open(SaleOpportunityTargetPriceProductNewDialogComponent, {
            width: "60%",
            data: <SaleOpportunityTargetPriceProductNewDialogInput>{
                targetPriceId: this.currentTargetPrice.id,
                productId: productId
                /* name: this.name, animal: this.animal */
            }
        });

        dialogRef
            .afterClosed()
            .subscribe((result: SampleBoxItemNewDialogOutput) => {
                const queryParams = this.route.snapshot.queryParams;
                const newQueryParams = { ...queryParams }
                delete newQueryParams['newbouquet'];
                this.saleOpportunityService.router.navigate(['.'], {
                    relativeTo: this.route,
                    queryParams: newQueryParams
                });
            });
    }
}

declare type ActiveAreaType = "settings" | "products";
declare type ActiveDetailAreaType = "ItemDetails" | "SampleBoxes" | "TargetPrices";
