import {
    Component,
    OnDestroy,
    OnInit,
    ViewEncapsulation,
    Input
} from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { Subject, Subscription, Observable, of } from 'rxjs';

import { fuseAnimations } from '@fuse/animations';

import { Todo } from '../saleopportunity.view.model';
import { SaleOpportunityViewService } from '../saleopportunity.view.service';
import { takeUntil, switchMap } from 'rxjs/operators';
import {
    SaleOpportunity,
    ProductGrid,
    TargetPriceItem,
    TargetPriceProductItem,
    TargetPriceProductSubItem
} from '../../saleopportunity.model';
import {
    Form,
    FormArray,
    FormBuilder,
    Validators,
    FormGroup
} from '@angular/forms';
import { SaleOpportunityService } from '../../saleopportunity.service';
import {
    ProductColorTypeResolveService,
    EnumItem
} from 'app/main/apps/@resolveServices/resolve.module';

@Component({
    selector: 'saleopportunity-view-list-targetpricesubproducts',
    templateUrl: './saleopportunity.view-list.component.html',
    styleUrls: ['./saleopportunity.view-list.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations
})
export class SaleOpportunityViewListTargetPriceSubProductComponent
    implements OnInit, OnDestroy {
    private _currentEntity: SaleOpportunity;
    frmMain: any;
    get currentEntity(): SaleOpportunity {
        return this._currentEntity;
    }
    @Input('entity')
    set currentEntity(value: SaleOpportunity) {
        this._currentEntity = value;
    }

    _currentTargetPriceProduct: TargetPriceProductItem;
    onTargetPriceProductSelected: Subscription;
    get currentTargetPriceProduct(): TargetPriceProductItem {
        return this._currentTargetPriceProduct;
    }

    get colorType(): Observable<EnumItem<string>> {
        return this.listProductColorType$
            .pipe<EnumItem<string>>(
                switchMap(list =>
                    of(
                        list.find(
                            item =>
                                item.key ===
                                this.currentTargetPriceProduct
                                    .productColorTypeId
                        )
                    )
                )
            );
    }

    get listOfSubItems(): TargetPriceProductSubItem[] {
        return (
            (this._currentTargetPriceProduct &&
                this._currentTargetPriceProduct.relatedProducts) ||
            []
        );
    }

    listProductColorType$: Observable<EnumItem<string>[]>;

    private _formItems: FormArray;
    get formItems(): FormArray {
        return this._formItems;
    }
    @Input('formItems')
    set formItems(value: FormArray) {
        // debugger;
        this._formItems = value;
    }

    todos: Todo[];
    currentTodo: Todo;

    status: StatusType = null;

    // Private
    private _unsubscribeAll: Subject<any>;

    /**
     *
     * @param _activatedRoute Active route
     * @param _location Location service
     * @param saleOpportunityService Sale opportunity service
     */
    constructor(
        private formBuilder: FormBuilder,
        private _activatedRoute: ActivatedRoute,
        private _location: Location,
        private saleOpportunityService: SaleOpportunityService,
        private productColorResolveServiceService: ProductColorTypeResolveService
    ) {
        this.listProductColorType$ = this.productColorResolveServiceService.onList;

        // Set the private defaults
        this._unsubscribeAll = new Subject();

        this.onTargetPriceProductSelected = this.saleOpportunityService.onTargetPriceProductSelected.subscribe(
            targetPriceProduct => {
                this._currentTargetPriceProduct = targetPriceProduct;
                this.frmMain = this.createFormForProduct(
                    this._currentTargetPriceProduct
                );
            }
        );
    }

    createFormForProduct(product: TargetPriceProductItem): FormGroup {
        return this.formBuilder.group({
            id: [product.id, [Validators.required]],
            productName: [product.productName, [Validators.required]],
            productColorTypeId: [
                product.productColorTypeId,
                [Validators.required]
            ]
        });
    }

    updateTargetPriceProduct(): void {
        const item = this.frmMain.value;

        this.saleOpportunityService.updateTargetPriceProductItem(item).then(productItem => {
            this.status = null;
        });
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void {}

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
     * On drop
     *
     * @param ev Event
     */
    onDrop(ev: any): void {}
}

export type StatusType = 'editing';
