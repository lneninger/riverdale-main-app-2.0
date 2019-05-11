import { Component, HostBinding, Input, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subject, Observable } from 'rxjs';
import { Todo } from '../../saleopportunity.view.model';
import { SaleOpportunityViewService } from '../../saleopportunity.view.service';
import { takeUntil } from 'rxjs/operators';
import { TargetPriceProductSubItem, TargetPriceProductItem, SaleOpportunity } from '../../../saleopportunity.model';
import { FormArray, FormGroup } from '@angular/forms';
import { ProductColorTypeResolveService, ProductResolveService, EnumItem } from '../../../../@resolveServices/resolve.module';
import { SaleOpportunityService } from '../../../saleopportunity.core.module';
import { ProductService } from '../../../../products/product.core.module';
import {
    DeletePopupComponent,
    DeletePopupData,
    DeletePopupResult
} from '../../../../@hipalanetCommons/popups/delete/delete.popup.module';
import { MatDialog, MatSnackBar } from '@angular/material';



@Component({
    selector: 'saleopportunity-view-list-item-targetpriceproduct',
    templateUrl: './saleopportunity.view-list-item.component.html',
    styleUrls: ['./saleopportunity.view-list-item.component.scss'],
    encapsulation: ViewEncapsulation.None
})
export class SaleOpportunityViewListItemTargetPriceProductComponent implements OnInit, OnDestroy
{
    tags: any[];
    listProductColorType$: Observable<EnumItem<string>[]>;
    listProduct$: Observable<EnumItem<number>[]>;

    currentOpportunity: SaleOpportunity;

    @Input('entity')
    currentEntity: TargetPriceProductItem;

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
     * 
     * @param saleOpportunityService Sale opportunity service
     * @param serviceProductColorTypeResolve Product color type resolve service
     * @param serviceProductResolve Product resolve service
     * @param serviceProduct Product service
     * @param _activatedRoute Active route
     * @param matDialog Mat dialog service
     * @param _matSnackBar snackbar service
     */
    constructor(
        private saleOpportunityService: SaleOpportunityService
        , private serviceProductColorTypeResolve: ProductColorTypeResolveService
        , private serviceProductResolve: ProductResolveService
        , private serviceProduct: ProductService
        , private _activatedRoute: ActivatedRoute
        , private matDialog: MatDialog
        , private _matSnackBar: MatSnackBar
    )
    {
        this.listProductColorType$ = this.serviceProductColorTypeResolve.onList;
        this.listProduct$ = this.serviceProductResolve.onList;

        // Disable move if path is not /all
        if ( _activatedRoute.snapshot.url[0].path !== 'all' )
        {
            this.moveDisabled = true;
        }

        this.saleOpportunityService.onCurrentEntityChanged.subscribe(currentOpportunity => this.currentOpportunity = currentOpportunity);

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

    selectTargetPriceProduct($event: Event): void {
        // debugger;
        this.saleOpportunityService.toggleTargetPriceProduct(this.currentEntity);
    }


    deleteTargetPriceProduct($event: Event): void {
        const dialogRef = this.matDialog.open(DeletePopupComponent, {
            width: '250px',
            data: <DeletePopupData>{ elementDescription: this.currentEntity.productName }
        });

        dialogRef.afterClosed().subscribe((result: DeletePopupResult) => {
            if (result === 'YES') {
                this.deleteTargetPriceProductExecution();
            }
        });
    }

    deleteTargetPriceProductExecution(): void {
        this.saleOpportunityService.deleteTargetPriceProductItem(this.currentEntity.id)
            .then(() => {

                //// Show the success message
                // this._matSnackBar.open('target price\'s product deleted', 'OK', {
                //    verticalPosition: 'top',
                //    duration: 2000
                // });
            });
    }

    isAllowedColorType(productColorTypeId: string): boolean {
        return true;
        // const productItem = this.listProduct.find(item => item.key === this.currentEntity.productId);

        // if (productItem) {
        //    return (<string[]>productItem.extras['allowedColorTypes']).indexOf(productColorTypeId) !== -1;
        // }

        // return false;
    }

    updateItem(): void {
        const data = <TargetPriceProductItem>this.formGroup.value;
        this.saleOpportunityService.updateTargetPriceProductItem(data).then(response => {
        }, error => {

        });
    }
}
