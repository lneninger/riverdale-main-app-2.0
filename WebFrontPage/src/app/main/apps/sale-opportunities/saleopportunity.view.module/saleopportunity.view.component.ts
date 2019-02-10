import { Component, OnDestroy, OnInit, ViewEncapsulation, Input } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, FormArray, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, takeUntil } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseSidebarService } from '@fuse/components/sidebar/sidebar.service';

import { Todo } from './saleopportunity.view.model';
import { SaleOpportunity, ProductGrid, SampleBoxItem, SampleBoxGrid, SampleBoxProductItem } from '../saleopportunity.model';
import { SaleOpportunityViewService } from './saleopportunity.view.service';
import { ISelectedFile } from '../../@hipalanetCommons/fileupload/fileupload.model';
import { SaleOpportunityService } from '../saleopportunity.core.module';
import { CustomValidators } from 'ng4-validators';
import { MatSnackBar } from '@angular/material';

@Component({
    selector: 'saleopportunity-view',
    templateUrl: './saleopportunity.view.component.html',
    styleUrls: ['./saleopportunity.view.component.scss'],
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

    showCustomerSidebar: boolean;
    activeArea: ActiveAreaType;
    activeDetailArea: ActiveDetailAreaType;

    @Input('entity')
    set currentEntity(value: SaleOpportunity) {
        if (this._currentEntity !== value) {
            this._currentEntity = new SaleOpportunity(value);
            this.sampleBoxes = this._currentEntity.sampleBoxes;
            this.frmMain = this.createFormBasicInfo();
        }
        else {
            this.sampleBoxes = null;
        }
    }

    sampleBoxes: SampleBoxGrid[];

    frmMain: FormGroup;
    frmSampleBoxItems: FormArray;
    frmSampleBoxProductItems: FormArray;

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
        private route: ActivatedRoute
        , private _fuseSidebarService: FuseSidebarService
        , private _todoService: SaleOpportunityViewService
        , private _formBuilder: FormBuilder
        , private saleOpportunityService: SaleOpportunityService
        , private _matSnackBar: MatSnackBar
    ) {
        // Set the defaults
        this.searchInput = new FormControl('');

        // Set the private defaults
        this._unsubscribeAll = new Subject();

        this.saleOpportunityService.onSampleBoxItemAdded.subscribe(this.onSampleBoxItemAdded.bind(this));
        this.saleOpportunityService.onSampleBoxItemUpdated.subscribe(this.onSampleBoxItemUpdated.bind(this));
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void {
        // debugger;
        this.currentEntity = this.saleOpportunityService.currentEntity.bag;
        this.frmSampleBoxItems = this._formBuilder.array([]);
        this.currentEntity.sampleBoxes.forEach(item => {
            this.frmSampleBoxItems.push(this.createFormSampleBoxItem(item));
        });

        this._todoService.onSelectedTodosChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(selectedTodos => {

                if (selectedTodos && (this._todoService.todos && this._todoService.todos.length)) {
                    setTimeout(() => {
                        this.hasSelectedTodos = selectedTodos.length > 0;
                        this.isIndeterminate = (selectedTodos.length !== this._todoService.todos.length && selectedTodos.length > 0);
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
                }
                else {
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
            name: [this.currentEntity.name],
        });
    }

    createFormSampleBoxItem(item: SampleBoxItem): FormGroup {
        const result = this._formBuilder.group({
            'id': [item.id, [Validators.required, CustomValidators.number]],
            'order': [item.order, [Validators.required, CustomValidators.number]],
            'parentSampleBoxId': [item.parentSampleBoxId, [CustomValidators.number]],
            'selected': '',
        });

        result.controls['selected'].valueChanges.subscribe(value => {
        });

        return result;
    }

    createFormSampleBoxProductItem(item: SampleBoxProductItem): FormGroup {
        const result = this._formBuilder.group({
            'id': [item.id, [Validators.required, CustomValidators.number]],
            'productId': [item.productId, [Validators.required, CustomValidators.number]],
            'productAmount': [item.productAmount, [Validators.required, CustomValidators.number]],
            'productColorTypeId': item.productColorTypeId,
            'selected': '',
        });

        result.controls['selected'].valueChanges.subscribe(value => {
        });

        return result;
    }

    updateFormSampleBoxItem(formGroup: FormGroup, item: SampleBoxItem): void {
        const value = {
            id: item.id,
            name: item.name,
            parentSampleBoxId: item.parentSampleBoxId,
        };

        formGroup.reset(value);
    }

    updateFormSampleBoxProductItem(formGroup: FormGroup, item: SampleBoxProductItem): void {
        const value = {
            id: item.id,
            sampleBoxId: item.sampleBoxId,
            productId: item.productId,
            productName: item.productName,
            productPictureId: item.productPictureId,
            productTypeId: item.productTypeId,
            productTypevName: item.productTypeName,
            productTypeDescription: item.productTypeDescription,
            productAmount: item.productAmount,
            productColorTypeId: item.productColorTypeId,
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
            this._matSnackBar.open('Sample Box Added', 'OK', {
                verticalPosition: 'top',
                duration: 5000
            });
    }

    onSampleBoxProductItemAdded(item: SampleBoxProductItem): void {
        // debugger;
        this.frmSampleBoxProductItems.push(this.createFormSampleBoxProductItem(item));
        const sampleBox = this.currentEntity.sampleBoxes.find(o => o.id === item.sampleBoxId);
        if (sampleBox !== null)
        {
            sampleBox.relatedProducts.push(item);
        }
            this._matSnackBar.open('Product Add', 'OK', {
                verticalPosition: 'top',
                duration: 5000
            });
    }

    onSampleBoxItemUpdated(item: SampleBoxItem): void {
        // debugger;
        const index = this.currentEntity.sampleBoxes.findIndex(sampleBoxItem => sampleBoxItem.id === item.id);
        if (index >= 0) {
            this.currentEntity.sampleBoxes.splice(index, 1, item);
            this.updateFormSampleBoxItem((<FormGroup>this.frmSampleBoxItems.controls[index]), item);

            this._matSnackBar.open('Product Updated', 'OK', {
                verticalPosition: 'top',
                duration: 5000
            });
        }
    }

    onSampleBoxProductItemUpdated(item: SampleBoxProductItem): void {
        // debugger;
        const sampleBox = this.currentEntity.sampleBoxes.find(relatedPorductItem => relatedPorductItem.id === item.id);
        if (sampleBox !== null)
        {
        const index = sampleBox.relatedProducts.findIndex(productItem => productItem.id === item.id);
        if (index >= 0) {
            sampleBox.relatedProducts.splice(index, 1, item);
            this.updateFormSampleBoxProductItem((<FormGroup>this.frmSampleBoxProductItems.controls[index]), item);

            this._matSnackBar.open('Product Updated', 'OK', {
                verticalPosition: 'top',
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


    addSampleBox(): void{
        const sampleBox = <SampleBoxItem>{};
        this.saleOpportunityService.addSampleBoxItem(sampleBox);
    }

    addBouquet(): void{

    }
}
declare type ActiveAreaType = 'settings' | 'products';
declare type ActiveDetailAreaType = 'ItemDetails' | 'SampleBoxs';
