import { Component, ElementRef, OnInit, ViewChild, ViewEncapsulation, Inject } from '@angular/core';
import { MatPaginator, MatSort, MatDialogRef, MAT_DIALOG_DATA, MatDialog, MatSnackBar } from '@angular/material';
import { DataSource } from '@angular/cdk/collections';
import { BehaviorSubject, fromEvent, merge, Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, map } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import { takeUntil } from 'rxjs/internal/operators';


/*************************Custom***********************************/
import { DataSourceAbstract } from '../@hipalanetCommons/datatable/datasource.abstract.class';
import { SaleOpportunityGrid, SaleOpportunity, SaleOpportunityNewDialogResult } from './saleopportunity.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'environments/environment';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { SaleOpportunityService } from './saleopportunity.core.module';
import { ProductTypeResolveService, EnumItem } from '../@resolveServices/resolve.module';
import { OperationResponseValued } from '../@hipalanetCommons/messages/messages.model';
import { ActivatedRoute } from '@angular/router';
import { CustomValidators } from 'ng4-validators';

@Component({
    selector: 'sale-opportunities',
    templateUrl: './saleopportunities.component.html',
    styleUrls: ['./saleopportunities.component.scss'],
    animations: fuseAnimations,
    encapsulation: ViewEncapsulation.None
})
export class SaleOpportunitiesComponent implements OnInit {
    dataSource: SaleOpportunitiesDataSource | null;
    displayedColumns = ['name', 'customerName', 'saleSeasonTypeName', 'targetPrice', 'createdAt', 'options'];

    @ViewChild(MatPaginator)
    paginator: MatPaginator;

    @ViewChild(MatSort)
    sort: MatSort;

    @ViewChild('filter')
    filter: ElementRef;

    // Private
    private _unsubscribeAll: Subject<any>;


    /* ******************************Custom Notification***********************************************/
    products: any[];

    constructor(
        private route: ActivatedRoute
        , private service: SaleOpportunityService
        , public dialog: MatDialog
    ) {

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
        // debugger;
        this.dataSource = new SaleOpportunitiesDataSource(this.service, this.filter/*, this._service*/, this.paginator, this.sort);

        this.initializeQueryListeners();
    }

    initializeQueryListeners(): void {
        this.route.queryParams.subscribe(params => {
            if (this.route.snapshot.data['action'] === 'new') {
                this.openDialog();
            }
        });
    }

    openDialog(): void {
        const dialogRef = this.dialog.open(SaleOpportunityNewDialogComponent, {
            width: '60%',
            data: { listSeasonCategoryType: this.route.snapshot.data.listSeasonCategoryType, listCustomer: this.route.snapshot.data.listCustomer }
        });

        dialogRef.afterClosed().subscribe((result: SaleOpportunityNewDialogResult) => {
            if (result && result.goTo === 'Edit') {
                this.service.router.navigate([`apps/saleopportunities/${result.data.id}`]);
            }
            else {
                this.service.router.navigate([`../`], { relativeTo: this.route });
                this.dataSource.dataChanged.next('');
            }
        });
    }
}

export class SaleOpportunitiesDataSource extends DataSourceAbstract<SaleOpportunityGrid>
{
    /**
     * Constructor
     *
     * @param _service Service
     * @param _matPaginator Paginator
     * @param _matSort Sort
     */
    constructor(
        service: SaleOpportunityService
        , filterElement: ElementRef
        , matPaginator: MatPaginator
        , matSort: MatSort
    ) {
        super(service, filterElement, matPaginator, matSort);
    }

    remoteEnpoint = `${environment.appApi.apiBaseUrl}saleopportunity/pagequery`;

    public getFilter(rawFilterObject: {}): {} {


        const result = {};


        return result;
    }


}



@Component({
    selector: 'saleopportunitynew-dialog',
    templateUrl: 'saleopportunitynew.dialog.component.html',
})
export class SaleOpportunityNewDialogComponent {
    listSeasonCategoryType: EnumItem<string>[];
    listCustomer: EnumItem<number>[];
    selectedSeasonCategory: EnumItem<string>;

    get selectedCategorySeasons(): Object {
        if (this.selectedSeasonCategory != null) {
            return this.selectedSeasonCategory.extras['saleSeasonTypes'];
        }
        else {
            return null;
        }
    }

    frmMain: FormGroup;
    constructor(
        private service: SaleOpportunityService
        , private matSnackBar: MatSnackBar
        , private frmBuilder: FormBuilder
        , public dialogRef: MatDialogRef<SaleOpportunityNewDialogComponent>
        , @Inject(MAT_DIALOG_DATA) public data: any
        , private route: ActivatedRoute
    ) {
        this.listSeasonCategoryType = this.data.listSeasonCategoryType;
        this.listCustomer = this.data.listCustomer;
        this.frmMain = frmBuilder.group({
            'name': ['', [Validators.required]],
            'saleSeasonTypeId': ['', [Validators.required]],
            'customerId': ['', [Validators.required]],
            'targetPrice': ['', CustomValidators.number]
        });
    }

    save(): Promise<{}> {
        return new Promise((resolve, reject) => {
            this.service.add(this.frmMain.value)
                .then(res => {
                    this.matSnackBar.open('Product created', 'OK', {
                        verticalPosition: 'top',
                        duration: 2000
                    });

                    resolve(res);
                })
                .catch(error => reject(error));
        });
    }

    cancel(): void {
        this.dialogRef.close();
    }

    create(): void {
        this.save().then(res => {
            this.dialogRef.close();
        });
    }

    createEdit(): void {
        this.save().then((res: OperationResponseValued<SaleOpportunity>) => {
            const result = <SaleOpportunityNewDialogResult>{
                goTo: 'Edit',
                data: res.bag
            };

            this.dialogRef.close(result);
        });
    }
}
