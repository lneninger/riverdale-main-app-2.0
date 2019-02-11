import {
    Component,
    OnDestroy,
    OnInit,
    ViewEncapsulation,
    ElementRef,
    ViewChild,
    Input
} from '@angular/core';
import { Router } from '@angular/router';
import { pipe, of, fromEvent, Subject } from 'rxjs';
import {
    takeUntil,
    debounceTime,
    distinctUntilChanged,
    filter
} from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';

import {
    SaleOpportunity
    , SampleBoxItem
    , SampleBoxProductItem
} from '../../../saleopportunity.model';
import { SaleOpportunityViewService } from '../../saleopportunity.view.service';
import {
    EnumItem,
    ProductResolveService
} from '../../../../@resolveServices/resolve.module';
import { SaleOpportunityService } from '../../../saleopportunity.service';
import { Customer } from 'app/main/apps/customers/customer.model';
import { CustomerService } from 'app/main/apps/customers/customer.core.module';

@Component({
    selector: 'customer-sidebar',
    templateUrl: './customer-sidebar.component.html',
    styleUrls: ['./customer-sidebar.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations
})
export class CustomerSidebarComponent implements OnInit, OnDestroy {
    private _currentEntity: SaleOpportunity;
    public customer: Customer;

    private _currentDataArea: CurrentDataAreaType = 'ALL';
    get showCustomerInfo(): boolean {
        return (
            (<CurrentDataAreaType[]>['ALL', 'INFO']).indexOf(
                this._currentDataArea
            ) !== -1
        );
    }

    get showCustomerSettings(): boolean {
        return (
            (<CurrentDataAreaType[]>['ALL', 'SETTINGS']).indexOf(
                this._currentDataArea
            ) !== -1
        );
    }

    get currentEntity(): SaleOpportunity {
        return this._currentEntity;
    }

    @Input('entity')
    set currentEntity(value: SaleOpportunity) {
        this._currentEntity = value;
        if (this._currentEntity && this._currentEntity.customerId) {
            this.getCustomer(this._currentEntity.customerId);
        }
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
     *
     * @param _todoService Sale opportunity Service. Not used
     * @param _router  Router provider
     * @param productResolveService  product Resolve Service
     */
    constructor(
        private _todoService: SaleOpportunityViewService,
        private _router: Router,
        private customerService: CustomerService
    ) {
        // Set the defaults
        this.accounts = {
            creapond: 'johndoe@creapond.com',
            withinpixels: 'johndoe@withinpixels.com'
        };
        this.selectedAccount = 'creapond';


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
     * New todo
     */
    newTodo(): void {
        this._router.navigate(['/apps/todo/all']).then(() => {
            setTimeout(() => {
                this._todoService.onNewTodoClicked.next('');
            });
        });
    }

    getCustomer(id: number): void {
        this.customerService.getCustomer(id).then(data => {
            this.customer = data.bag;
        });
    }
}

export declare type CurrentDataAreaType = 'ALL' | 'INFO' | 'SETTINGS';
