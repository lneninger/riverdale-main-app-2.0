import {
    Component,
    OnDestroy,
    OnInit,
    ViewEncapsulation,
    ElementRef,
    ViewChild,
    Input
} from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {
    pipe,
    of,
    fromEvent,
    Subject,
    Subscription,
    Observable,
    merge
} from 'rxjs';
import {
    takeUntil,
    debounceTime,
    distinctUntilChanged,
    filter,
    mergeMap
} from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';

import {
    SaleOpportunity,
    SampleBoxProductItem,
    TargetPriceProductSubItem,
    SaleOpportunityTargetPriceSubProductNewDialogInput
} from '../../../saleopportunity.model';
import { SaleOpportunityViewService } from '../../saleopportunity.view.service';
import {
    EnumItem,
    ProductResolveService
} from '../../../../@resolveServices/resolve.module';
import { SaleOpportunityService } from '../../../saleopportunity.service';
import { CompositionItem } from 'app/main/apps/products/product.model';
import { MatDialog } from '@angular/material';
import { SaleOpportunityTargetPriceSubProductNewDialogComponent } from '../../saleopportunity.view-targetprice/saleopportunities-targetpricesubproductnew.dialog.component';

@Component({
    selector: 'todo-main-sidebar',
    templateUrl: './main-sidebar.component.html',
    styleUrls: ['./main-sidebar.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations
})
export class TodoMainSidebarComponent implements OnInit, OnDestroy {
    private _currentEntity: SaleOpportunity;
    currentTargetPrice: import('d:/Dev/HIPALANET/riverdale-main-app-2.0/WebFrontPage/src/app/main/apps/sale-opportunities/saleopportunity.model').TargetPriceItem;

    get currentEntity(): SaleOpportunity {
        return this._currentEntity;
    }

    @Input('entity')
    set currentEntity(value: SaleOpportunity) {
        this._currentEntity = value;
    }

    @ViewChild('productFilterElement')
    productFilterElement: ElementRef;

    listProduct: Observable<EnumItem<any>[]>;

    folders: any[];
    filters: any[];
    tags: any[];
    accounts: object;
    selectedAccount: string;

    // Private
    private _unsubscribeAll: Subject<any>;

    /**
     * Constructor
     *
     * @param _todoService Todo Service
     * @param _router Router
     */
    constructor(
        private _todoService: SaleOpportunityViewService,
        private _router: Router,
        private route: ActivatedRoute,
        private productResolveService: ProductResolveService,
        private saleOpportunityService: SaleOpportunityService,
        public dialog: MatDialog
    ) {
        //// Set the defaults
        // this.accounts = {
        //    creapond: 'johndoe@creapond.com',
        //    withinpixels: 'johndoe@withinpixels.com'
        // };
        // this.selectedAccount = 'creapond';

        // this.productResolveService.onList.subscribe(() => {
        //     this.filterProducts();
        // });

        this.saleOpportunityService.onTargetPriceSelected.subscribe(
            targetPrice => {
                this.currentTargetPrice = targetPrice;
            }
        );

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
        this._todoService.onFiltersChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(filters => {
                this.filters = filters;
            });

        this._todoService.onTagsChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(tags => {
                this.tags = tags;
            });

        this.activeFilterProducts();
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
    activeTermFilter(): Observable<any> {
        return fromEvent(this.productFilterElement.nativeElement, 'keyup').pipe(
            filter(e => (<any>e).keyCode === 13),
            takeUntil(this._unsubscribeAll),
            debounceTime(150),
            distinctUntilChanged()
        );
    }

    activeFilterProducts(): void {
        const mergeList = [
            this.activeTermFilter(),
            this.productResolveService.onList.asObservable(),
            this.saleOpportunityService.onTargetPriceSelected.asObservable(),
            this.saleOpportunityService.onTargetPriceProductSelected.asObservable()
        ];

        this.listProduct = merge(...mergeList).pipe(
            mergeMap(() => {
                return this.productResolveService.onList.pipe(
                    mergeMap(list => {
                        const result = list.filter(o => {
                            const term = <string>(
                                this.productFilterElement.nativeElement.value
                            );

                            console.log(
                                `Bouquet selected: `,
                                !!this.saleOpportunityService
                                    .currentSampleBoxProduct
                            );
                            console.log(
                                `SampleBox selected: `,
                                !!this.saleOpportunityService.currentSampleBox
                            );
                            return (
                                // Term Filter
                                // o.key !== this.currentEntity.id &&
                                o.value &&
                                (!term ||
                                    o.value
                                        .toLowerCase()
                                        .indexOf(term.toLowerCase()) !== -1) &&
                                (// If TargetPriceProduct selected, Show no compositions
                                (!!this.saleOpportunityService
                                    .currentTargetPriceProduct &&
                                    <string>(
                                        (<unknown>o.extras['productTypeId'])
                                    ) !== 'COMP') ||
                                    // TargetPrice selected. Show compositions
                                    (!this.saleOpportunityService
                                        .currentTargetPriceProduct &&
                                        !!this.saleOpportunityService
                                            .currentTargetPrice &&
                                        <string>(
                                            (<unknown>o.extras['productTypeId'])
                                        ) === 'COMP'))
                            );
                        });

                        return of(result);
                    })
                );
            })
        );
    }

    /**
     * New todo
     */
    newTodo(): void {
        this._router.navigate(['/apps/todo/all']).then(() => {
            setTimeout(() => {
                this._todoService.onNewTodoClicked.next('');
            });
        });
    }

    // selectedToAddItem(enumItem: EnumItem<number>): any {
    //    const item = new CompositionItem(enumItem);
    //    const currentTargetPriceProduct = this.saleOpportunityService.currentTargetPriceProduct;
    //    if (currentTargetPriceProduct !== null) {
    //        item.productId = currentTargetPriceProduct.productId;
    //        this.saleOpportunityService.addTargetPriceProductSubItem(item).then(
    //            response => {
    //                // debugger;
    //            },
    //            error => {}
    //        );
    //    }
    // }

    selectedToAddItem(enumItem: EnumItem<number>): any {
        this.openSubProductDialog(enumItem);
    }

    openSubProductDialog(enumItem: EnumItem<number>): void {
        // debugger;

        const input = <SaleOpportunityTargetPriceSubProductNewDialogInput>{
            productId: this.saleOpportunityService.currentTargetPriceProduct
                .productId,
            subProductId: enumItem.key
        };

        const dialogRef = this.dialog.open(
            SaleOpportunityTargetPriceSubProductNewDialogComponent,
            {
                width: '60%',
                data: input
            }
        );

        dialogRef
            .afterClosed()
            .subscribe(
                (
                    result: SaleOpportunityTargetPriceSubProductNewDialogComponent
                ) => {
                    // debugger;
                    const queryParams = this.route.snapshot.queryParams;
                    const newQueryParams = { ...queryParams };
                    delete newQueryParams['newtargetprice'];
                    this.saleOpportunityService.router.navigate(['.'], {
                        relativeTo: this.route,
                        queryParams: newQueryParams
                    });
                }
            );
    }
}
