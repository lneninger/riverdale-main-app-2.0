import {
    Component,
    OnDestroy,
    OnInit,
    ViewEncapsulation,
    ElementRef,
    ViewChild,
    Input
} from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { pipe, of, fromEvent, Subject, Observable, combineLatest } from "rxjs";
import {
    takeUntil,
    debounceTime,
    distinctUntilChanged,
    filter,
    mergeMap,
    map,
    startWith

} from "rxjs/operators";

import { fuseAnimations } from "@fuse/animations";

import { Product, CompositionItem, CompositionItemNewDialogResult, CompositionItemNewDialogInput } from "../../../product.model";
import { CompositionViewService } from "../../composition.view.service";
import {
    EnumItem,
    ProductResolveService
} from "../../../../@resolveServices/resolve.module";
import { ProductService } from "../../../product.service";
import { CompositionViewBridgeNewDialogComponent } from "../../composition.view.bridgenew.dialog.component";
import { MatDialog } from "@angular/material";

@Component({
    selector: "todo-main-sidebar",
    templateUrl: "./main-sidebar.component.html",
    styleUrls: ["./main-sidebar.component.scss"],
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations
})
export class TodoMainSidebarComponent implements OnInit, OnDestroy {
    private _currentEntity: Product;
    productListAsync: any;

    get currentEntity() {
        return this._currentEntity;
    }

    @Input("entity")
    set currentEntity(value: Product) {
        this._currentEntity = value;
    }

    @ViewChild("productFilterElement")
    productFilterElement: ElementRef;

    listProduct: Observable<EnumItem<number>[]>;

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
     * @param {TodoService} _todoService
     * @param {Router} _router
     */
    constructor(
        private _todoService: CompositionViewService,
        private _router: Router,
        private productResolveService: ProductResolveService,
        private service: ProductService,
        private matDialog: MatDialog,
        private route: ActivatedRoute
    ) {
        // Set the defaults
        this.accounts = {
            creapond: "johndoe@creapond.com",
            withinpixels: "johndoe@withinpixels.com"
        };
        this.selectedAccount = "creapond";

        this.productListAsync = this.productResolveService.onList.pipe(
            takeUntil(this._unsubscribeAll)
        );

        this.productResolveService.noDependencyResolve().subscribe();

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

        this.initProductFilteredObservable();



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
    initProductFilteredObservable() {
        const filterTyping$ = fromEvent(this.productFilterElement.nativeElement, "keyup")
            .pipe(
                startWith({ keyCode: 13 }),

                filter(e => {
                    return (<any>e).keyCode == 13;
                })
            );

        this.listProduct = combineLatest(
            filterTyping$
            , this.productResolveService.onList
        )
            .pipe(
                takeUntil(this._unsubscribeAll),
                debounceTime(150),
                distinctUntilChanged()
            )
            .pipe(map(res => { return { term: <string>this.productFilterElement.nativeElement.value, listProduct: res[1] }; }))
            .pipe(mergeMap((filterValues) => {
                return this.filterProducts(filterValues.term, filterValues.listProduct);
            }));
    }


    filterProducts(term: string, list: EnumItem<number>[]): Observable<EnumItem<any>[]> {
        const termFilter = list.filter(
            o =>
                o.key !== this.currentEntity.id &&
                o.value &&
                (!term ||
                    o.value.toLowerCase().indexOf(term.toLowerCase()) !== -1)
        );

        return of(termFilter);
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

    openDialog(enumItem: CompositionItem): void {
        const dialogRef = this.matDialog.open(CompositionViewBridgeNewDialogComponent, {
            width: '60%',
            data: <CompositionItemNewDialogInput>{
                listProductType: this.route.snapshot.data.listProductType,
                productRef: enumItem
            }
        });

        dialogRef.afterClosed().subscribe((result: CompositionItemNewDialogResult) => {
            //if (result && result.result === 'Edit') {
            //    this.service.router.navigate([`apps/products/${result.data.id}`]);
            //}
            //else {
            //    this.service.router.navigate([`../`], { relativeTo: this.route });
            //    this.dataSource.dataChanged.next('');
            //}
        });
    }

    selectedToAddItem(enumItem: EnumItem<number>) {
        const item = new CompositionItem(enumItem);
        item.productId = this.currentEntity.id;

        this.openDialog(item);

        //this.service
        //    .addCompositionItem(item)
        //    .then(response => { }, error => { });
    }
}
