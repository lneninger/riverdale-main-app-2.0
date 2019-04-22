import { Component, HostBinding, Input, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subject, Observable, BehaviorSubject, combineLatest, of } from 'rxjs';
import { Todo } from '../../saleopportunity.view.model';
import { SaleOpportunityViewService } from '../../saleopportunity.view.service';
import { takeUntil, map, switchMap } from 'rxjs/operators';
import { TargetPriceProductSubItem } from '../../../saleopportunity.model';
import { FormArray, FormGroup } from '@angular/forms';
import { ProductColorTypeResolveService, ProductResolveService, EnumItem, ProductCategoryResolveService } from '../../../../@resolveServices/resolve.module';
import { SaleOpportunityService } from '../../../saleopportunity.core.module';
import { ProductService } from '../../../../products/product.core.module';

@Component({
    selector: 'saleopportunity-view-list-item-targetpricesubproduct',
    templateUrl: './saleopportunity.view-list-item.component.html',
    styleUrls: ['./saleopportunity.view-list-item.component.scss'],
    encapsulation: ViewEncapsulation.None
})
export class SaleOpportunityViewListItemTargetPriceSubProductComponent implements OnInit, OnDestroy
{
    tags: any[];
    listProductColorType$: Observable<EnumItem<string>[]>;
    listProductCategory$: Observable<EnumItem<string>[]>;
    listProduct$: Observable<EnumItem<number>[]>;

    private _currentEntity: TargetPriceProductSubItem;
    get currentEntity(): TargetPriceProductSubItem {
        return this._currentEntity;
    }
    @Input('entity')
    set currentEntity(value: TargetPriceProductSubItem) {
        this._currentEntity = value;
        this.relatedProductId$.next(this._currentEntity.relatedProductId);
    }


    @Input('formGroup')
    formGroup: FormGroup;

    relatedProductId$: BehaviorSubject<number> = new BehaviorSubject<number>(null);
    allowedRelatedProductSizes$: Observable<EnumItem<number>[]>;


    @HostBinding('class.selected')
    selected: boolean;

    @HostBinding('class.completed')
    completed: boolean;

    @HostBinding('class.move-disabled')
    moveDisabled: boolean;

    // Private
    private _unsubscribeAll: Subject<any>;

    /**
     * Constructor
     *
     * @param _todoService
     * @param _activatedRoute
     */
    constructor(
        private saleOpportunityService: SaleOpportunityService
        , private serviceProductColorTypeResolve: ProductColorTypeResolveService
        , private serviceProductCategoryResolve: ProductCategoryResolveService
        , private serviceProductResolve: ProductResolveService
        , private serviceProduct: ProductService
        , private _activatedRoute: ActivatedRoute
    )
    {
        this.listProductCategory$ = this.serviceProductCategoryResolve.onList;
        this.listProductColorType$ = this.serviceProductColorTypeResolve.onList;
        this.listProduct$ = this.serviceProductResolve.onList;

        // Disable move if path is not /all
        if ( _activatedRoute.snapshot.url[0].path !== 'all' )
        {
            this.moveDisabled = true;
        }

        // Set the private defaults
        this._unsubscribeAll = new Subject();
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void
    {
        // Set the initial values
        this.currentEntity = new TargetPriceProductSubItem(this.currentEntity);

        const productItem$ = combineLatest([this.relatedProductId$, this.listProduct$])
            .pipe(map(combined => (<EnumItem<number>[]>combined[1]).find(productItem => productItem.key == combined[0])))

        this.allowedRelatedProductSizes$ =
            combineLatest([productItem$, this.listProductCategory$])
            .pipe(map(combined => { return { productItem: (<EnumItem<number>>combined[0]), productCategories: (<EnumItem<number>[]>combined[1]) }; }))
            .pipe(switchMap(source => {
                const targetCategoryId = <number><unknown>source.productItem.extras['productCategoryId'];
                const targetCategory = targetCategoryId && source.productCategories.find(categoryItem => categoryItem.key == targetCategoryId);

                if (targetCategory != null) {
                    return of(<EnumItem<number>[]>targetCategory.extras['sizes']);
                }
                else {
                    return of(<EnumItem<number>[]>[]);
                }
            }))
    }

    /**
     * On destroy
     */
    ngOnDestroy(): void
    {
        // Unsubscribe from all subscriptions
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * On selected change
     */
    onSelectedChange(): void
    {
        console.log(`Selected changed`, this.currentEntity, this.formGroup.value);
    }

    /**
     * Toggle star
     */
    toggleStar(event): void
    {
        event.stopPropagation();
    }

    /**
     * Toggle Important
     */
    toggleImportant(event): void
    {
        event.stopPropagation();
    }

    /**
     * Toggle Completed
     */
    toggleCompleted(event): void
    {
        event.stopPropagation();
    }

    isAllowedColorType(productColorTypeId: string): boolean {
        return true;
        //const productItem = this.listProduct.find(item => item.key === this.currentEntity.productId);

        //if (productItem) {
        //    return (<string[]>productItem.extras['allowedColorTypes']).indexOf(productColorTypeId) !== -1;
        //}

        //return false;
    }

    updateItem(): void {
        //debugger;
        const data = <TargetPriceProductSubItem>this.formGroup.value;
        this.saleOpportunityService.updateTargetPriceProductSubItem(data).then(response => {
            //debugger;
            const updatedItem = new TargetPriceProductSubItem(response);
        }, error => {

        });
    }
}
