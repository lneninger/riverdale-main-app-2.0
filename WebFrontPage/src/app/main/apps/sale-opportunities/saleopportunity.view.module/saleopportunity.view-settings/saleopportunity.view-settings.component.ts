import { Component, OnDestroy, OnInit, ViewEncapsulation, Input, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { Subject, fromEvent, Observable } from 'rxjs';

import { fuseAnimations } from '@fuse/animations';

import { Todo } from '../saleopportunity.view.model';
import { SaleOpportunityViewService } from '../saleopportunity.view.service';
import { takeUntil, distinctUntilChanged } from 'rxjs/operators';
import { SaleOpportunity, ProductGrid } from '../../saleopportunity.model';
import { FunzaService } from '../../../funza/funza.core.module';
import { EnumItem } from 'app/main/apps/@resolveServices/resolve.model';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { CustomValidators } from 'ng4-validators';

@Component({
    selector: 'saleopportunity-view-settings',
    templateUrl: './saleopportunity.view-settings.component.html',
    styleUrls: ['./saleopportunity.view-settings.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations
})
export class SaleOpportunityViewSettingsComponent implements OnInit, AfterViewInit, OnDestroy {
    private _currentEntity: SaleOpportunity;
    listGrowerType: EnumItem<string>[];
    selectedGrowerType: EnumItem<string>;
    frmMain: FormGroup;

    quotesObservable: Observable<EnumItem<number>>;

    todos: Todo[];
    currentTodo: Todo;

    // Private
    private _unsubscribeAll: Subject<any>;

    @ViewChild('funzaQuote')
    funzaQuoteElement: ElementRef;

    get selectedGrowers(): EnumItem<any>[] {
        if (this.selectedGrowerType != null) {
            return <EnumItem<any>[]>this.selectedGrowerType.extras['growers'];
        }
        else {
            return null;
        }
    }

    get currentEntity(): SaleOpportunity {
        return this._currentEntity;
    }

    @Input('entity')
    set currentEntity(value: SaleOpportunity) {
        this._currentEntity = value;
    }

    createForm(): any {
        this.frmMain = this.formBuilder.group({
            'riverdaleMargin': ['', [CustomValidators.number]],
            'delivered': ['', []],
            'foc': ['', [CustomValidators.number]],
            'growerId': ['', [CustomValidators.number]],
            'funzaQuote': ['', [CustomValidators.number]],
        });
    }




    /**
     * Constructor
     *
     * @param _activatedRoute ActiveRoute
     * @param _todoService Todo Service
     * @param _location Location
     */
    constructor(
        private _activatedRoute: ActivatedRoute,
        private funzaService: FunzaService,
        private _todoService: SaleOpportunityViewService,
        private _location: Location,
        private formBuilder: FormBuilder
    ) {
        this._unsubscribeAll = new Subject();
        // debugger;
        this.listGrowerType = this._activatedRoute.snapshot.data.listGrowerType;
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
        // Subscribe to update todos on changes
        this._todoService.onTodosChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(todos => {
                this.todos = todos;
            });

        // Subscribe to update current todo on changes
        this._todoService.onCurrentTodoChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(currentTodo => {
                if (!currentTodo) {
                    // Set the current todo id to null to deselect the current todo
                    this.currentTodo = null;

                    // Handle the location changes
                    const tagHandle = this._activatedRoute.snapshot.params.tagHandle,
                        filterHandle = this._activatedRoute.snapshot.params.filterHandle;

                    if (tagHandle) {
                        this._location.go('apps/todo/tag/' + tagHandle);
                    }
                    else if (filterHandle) {
                        this._location.go('apps/todo/filter/' + filterHandle);
                    }
                    else {
                        this._location.go('apps/todo/all');
                    }
                }
                else {
                    this.currentTodo = currentTodo;
                }
            });
    }


    ngAfterViewInit(): any {
        fromEvent(this.funzaQuoteElement.nativeElement, 'blur')
            .pipe(
                takeUntil(this._unsubscribeAll)
                , distinctUntilChanged()
            )
            .subscribe(() => {
                // debugger;
                this.quotesObservable = this.funzaService.getQuoteItems(this.funzaQuoteElement.nativeElement.value);
                this.quotesObservable.subscribe();
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
     * Read todo
     *
     * @param todoId Todo Id
     */


    /**
     * On drop
     *
     * @param ev Event
     */
    onDrop(ev): void {

    }
}
