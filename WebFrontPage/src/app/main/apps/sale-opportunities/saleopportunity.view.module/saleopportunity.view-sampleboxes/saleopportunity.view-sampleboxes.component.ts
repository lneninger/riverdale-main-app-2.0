import { Component, OnDestroy, OnInit, ViewChild, ViewEncapsulation, Input, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, takeUntil } from 'rxjs/operators';

import { FuseUtils } from '@fuse/utils';
import { fuseAnimations } from '@fuse/animations';

import { Todo } from '../saleopportunity.view.model';
import { SaleOpportunityViewService } from '../saleopportunity.view.service';
import { SaleOpportunity, SampleBoxItem, SampleBoxItemNewDialogResult } from '../../saleopportunity.model';
import { SaleOpportunityService } from '../../saleopportunity.service';
import { MAT_DIALOG_DATA, MatSnackBar, MatDialogRef } from '@angular/material';
import { OperationResponseValued } from 'app/main/apps/@hipalanetCommons/messages/messages.model';


@Component({
    selector: 'saleopportunity-view-sampleboxes',
    templateUrl: './saleopportunity.view-sampleboxes.component.html',
    styleUrls: ['./saleopportunity.view-sampleboxes.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations   : fuseAnimations
})
export class SaleOpportunityViewSampleBoxesComponent implements OnInit, OnDestroy
{
    todo: Todo;
    tags: any[];
    formType: string;
    todoForm: FormGroup;

    @ViewChild('titleInput')
    titleInputField;

    @Input('entity')
    currentEntity: SaleOpportunity;

    // Private
    private _unsubscribeAll: Subject<any>;

    /**
     * Constructor
     *
     * @param _todoService Todo Service
     * @param _formBuilder Form Builder
     */
    constructor(
        private saleOpportunityService: SaleOpportunityService,
        private _formBuilder: FormBuilder
    )
    {
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


    toggleSampleBox(sampleBox: SampleBoxItem): void{
        this.saleOpportunityService.toggleSampleBox(sampleBox);

    }
}




