import { Component, HostBinding, Input, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs';
import { Todo } from '../../saleopportunity.view.model';
import { SaleOpportunityViewService } from '../../saleopportunity.view.service';
import { takeUntil } from 'rxjs/operators';
import { TargetPriceProductSubItem } from '../../../saleopportunity.model';
import { FormArray, FormGroup } from '@angular/forms';
import { ProductColorTypeResolveService, ProductResolveService, EnumItem } from '../../../../@resolveServices/resolve.module';
import { SaleOpportunityService } from '../../../saleopportunity.core.module';
import { ProductService } from '../../../../products/product.core.module';

@Component({
    selector: 'saleopportunity-view-list-item',
    templateUrl: './saleopportunity.view-list-item.component.html',
    styleUrls: ['./saleopportunity.view-list-item.component.scss'],
    encapsulation: ViewEncapsulation.None
})
export class SaleOpportunityViewListItemComponent implements OnInit, OnDestroy
{
    tags: any[];
    listProductColorType: EnumItem<string>[];
    listProduct: EnumItem<number>[];

    @Input('entity')
    currentEntity: TargetPriceProductSubItem;

    @Input('formGroup')
    formGroup: FormGroup;

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
        , private serviceProductResolve: ProductResolveService
        , private serviceProduct: ProductService
        , private _activatedRoute: ActivatedRoute
    )
    {

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

        this.listProductColorType = this.serviceProductColorTypeResolve.list;
        this.listProduct =  this.serviceProductResolve.list;

        // Subscribe to update on selected todo change
        this.saleOpportunityService.onTargetPriceProductSelected
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(product => {
                this.selected = false;

                if (product.relatedProducts.length > 0 )
                {
                    for (const basicProduct of product.relatedProducts)
                    {
                        if (basicProduct.id === this.currentEntity.id )
                        {
                            this.selected = true;
                            break;
                        }
                    }
                }
            });
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
        const productItem = this.listProduct.find(item => item.key === this.currentEntity.productId);

        if (productItem) {
            return (<string[]>productItem.extras['allowedColorTypes']).indexOf(productColorTypeId) !== -1;
        }

        return false;
    }

    updateItem(): void {
        const data = <TargetPriceProductSubItem>this.formGroup.value;
        this.saleOpportunityService.updateTargetPriceProductSubItem(data).then(response => {
        }, error => {

        });
    }
}
