import {
    Component,
    OnDestroy,
    OnInit,
    ViewEncapsulation,
    ElementRef,
    ViewChild,
    Input
} from "@angular/core";
import { Router } from "@angular/router";
import {
    pipe,
    of,
    fromEvent,
    Subject,
    Subscription,
    Observable,
    merge
} from "rxjs";
import {
    takeUntil,
    debounceTime,
    distinctUntilChanged,
    filter,
    mergeMap
} from "rxjs/operators";

import { fuseAnimations } from "@fuse/animations";

import {
    SaleOpportunity,
    SampleBoxProductItem
} from "../../../saleopportunity.model";
import { SaleOpportunityViewService } from "../../saleopportunity.view.service";
import {
    EnumItem,
    ProductResolveService
} from "../../../../@resolveServices/resolve.module";
import { SaleOpportunityService } from "../../../saleopportunity.service";

@Component({
    selector: "todo-main-sidebar",
    templateUrl: "./main-sidebar.component.html",
    styleUrls: ["./main-sidebar.component.scss"],
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations
})
export class TodoMainSidebarComponent implements OnInit, OnDestroy {
    private _currentEntity: SaleOpportunity;

    get currentEntity(): SaleOpportunity {
        return this._currentEntity;
    }

    @Input("entity")
    set currentEntity(value: SaleOpportunity) {
        this._currentEntity = value;
    }

    @ViewChild("productFilterElement")
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
        private productResolveService: ProductResolveService,
        private saleOpportunityService: SaleOpportunityService
    ) {
        // Set the defaults
        this.accounts = {
            creapond: "johndoe@creapond.com",
            withinpixels: "johndoe@withinpixels.com"
        };
        this.selectedAccount = "creapond";

        // this.productResolveService.onList.subscribe(() => {
        //     this.filterProducts();
        // });

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
            this.saleOpportunityService.onSampleBoxSelected.asObservable(),
            this.saleOpportunityService.onSampleBoxProductSelected.asObservable(),
        ];

        this.listProduct = merge(...mergeList).pipe(
            mergeMap(() => {
                return this.productResolveService.onList.pipe(
                    mergeMap(list => {
                        const result = list.filter(o => {
                            const term = <string>(
                                this.productFilterElement.nativeElement.value
                            );

                            console.log(`Bouquet selected: `, !!this.saleOpportunityService.currentSampleBoxProduct);
                            console.log(`SampleBox selected: `, !!this.saleOpportunityService.currentSampleBox);
                            return (
                                // Term Filter
                                o.key !== this.currentEntity.id &&
                                o.value &&
                                (!term ||
                                    o.value
                                        .toLowerCase()
                                        .indexOf(term.toLowerCase()) !== -1)
                            ) && (
                                (
                                // Current BoxProduct selection. Show no compositions 
                                !!this.saleOpportunityService.currentSampleBoxProduct
                                && (<string><unknown>o.extras['productTypeId']) !== 'COMP'
                                )
                                ||
                                (
                                   // Current Box selection. Show compositions 
                                    !this.saleOpportunityService.currentSampleBoxProduct
                                    && !!this.saleOpportunityService.currentSampleBox
                                    && (<string><unknown>o.extras['productTypeId']) === 'COMP'
                                )
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
        this._router.navigate(["/apps/todo/all"]).then(() => {
            setTimeout(() => {
                this._todoService.onNewTodoClicked.next("");
            });
        });
    }

    selectedToAddItem(enumItem: EnumItem<number>): any {
        const item = new SampleBoxProductItem(enumItem);
        const sampleBoxItem = this.saleOpportunityService.currentSampleBox;
        if (sampleBoxItem !== null) {
            item.sampleBoxId = sampleBoxItem.id;
            this.saleOpportunityService.addSampleBoxProductItem(item).then(
                response => {
                    // debugger;
                },
                error => {}
            );
        }
    }
}
