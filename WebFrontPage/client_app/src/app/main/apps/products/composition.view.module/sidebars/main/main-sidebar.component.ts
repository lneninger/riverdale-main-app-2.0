import { Component, OnDestroy, OnInit, ViewEncapsulation, ElementRef, ViewChild, Input } from '@angular/core';
import { Router } from '@angular/router';
import { pipe, of, fromEvent, Subject } from "rxjs";
import { takeUntil, debounceTime, distinctUntilChanged, filter } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';

import { Product } from '../../../product.model';
import { CompositionViewService } from '../../composition.view.service';
import { EnumItem, ProductResolveService } from '../../../../@resolveServices/resolve.module';

@Component({
    selector     : 'todo-main-sidebar',
    templateUrl  : './main-sidebar.component.html',
    styleUrls    : ['./main-sidebar.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations   : fuseAnimations
})
export class TodoMainSidebarComponent implements OnInit, OnDestroy
{
    private _currentEntity: Product;

    get currentEntity() {
        return this._currentEntity;
    }

    @Input('entity')
    set currentEntity(value: Product) {
        this._currentEntity = value;
    }

    @ViewChild('productFilterElement')
    productFilterElement: ElementRef;

    listProduct: EnumItem<number>[];

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
        private _todoService: CompositionViewService
        , private _router: Router
        , private productResolveService: ProductResolveService
    )
    {
        // Set the defaults
        this.accounts = {
            'creapond'    : 'johndoe@creapond.com',
            'withinpixels': 'johndoe@withinpixels.com'
        };
        this.selectedAccount = 'creapond';

        this.productResolveService.noDependencyResolve()
            .then(originalList => {
                this.filterProducts(null);
            });

        

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
        fromEvent(this.productFilterElement.nativeElement, 'keyup')
            .pipe(
                filter(e => { return (<any>e).keyCode == 13 }),
                takeUntil(this._unsubscribeAll),
                debounceTime(150),
                distinctUntilChanged()
            )
            .subscribe(() => {
                debugger;
                let term = <string>this.productFilterElement.nativeElement.value;
                this.filterProducts(term);
            });

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
    ngOnDestroy(): void
    {
        // Unsubscribe from all subscriptions
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    filterProducts(term: string) {
        this.listProduct = (<EnumItem<number>[]>this.productResolveService.list).filter(o =>
            o.key != this.currentEntity.id
            && o.value && (!term || o.value.toLowerCase().indexOf(term.toLowerCase()) != -1)
        );//.splice(0, 3);
    }

    /**
     * New todo
     */
    newTodo(): void
    {
        this._router.navigate(['/apps/todo/all']).then(() => {
            setTimeout(() => {
                this._todoService.onNewTodoClicked.next('');
            });
        });
    }
}
