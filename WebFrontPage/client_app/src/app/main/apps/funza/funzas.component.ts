import { Component, ElementRef, OnInit, ViewChild, ViewEncapsulation, Inject } from '@angular/core';
import { MatPaginator, MatSort, MatDialogRef, MAT_DIALOG_DATA, MatDialog, MatSnackBar } from '@angular/material';
import { DataSource } from '@angular/cdk/collections';
import { BehaviorSubject, fromEvent, merge, Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, map } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseUtils } from '@fuse/utils';

import { takeUntil } from 'rxjs/internal/operators';


/*************************Custom***********************************/
//import { AngularFireAuth } from '@angular/fire/auth';
//import { AngularFireDatabase } from '@angular/fire/database';
import { DataSourceAbstract } from '../@hipalanetCommons/datatable/datasource.abstract.class';
import { FunzaProductGrid, FunzaColorGrid } from './funza.model';
import { environment } from 'environments/environment';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { FunzaService } from './funza.core.module';
import { OperationResponseValued } from '../@hipalanetCommons/messages/messages.model';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'funzas',
    templateUrl: './funzas.component.html',
    styleUrls: ['./funzas.component.scss'],
    animations: fuseAnimations,
    encapsulation: ViewEncapsulation.None
})
export class FunzasComponent implements OnInit {
    dataSource: FunzaProductsDataSource | null;
    displayedColumns = ['name', 'options'];

    activeOption: ActiveOptions = 'products';

    @ViewChild(MatPaginator)
    paginator: MatPaginator;

    @ViewChild(MatSort)
    sort: MatSort;

    @ViewChild('filter')
    filter: ElementRef;

    // Private
    private _unsubscribeAll: Subject<any>;


    /* ******************************Custom Notification***********************************************/
    userRoles: any[];

    constructor(
        private service: FunzaService
        , private route: ActivatedRoute
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
        this.dataSource = new FunzaProductsDataSource(this.service, this.filter/*, this._service*/, this.paginator, this.sort);
    }

    authenticate() {
        this.service.authenticate();
    }
}

export class FunzaProductsDataSource extends DataSourceAbstract<FunzaProductGrid>
{
    /**
     * Constructor
     *
     * @param {UserRolesListService} _service
     * @param {MatPaginator} _matPaginator
     * @param {MatSort} _matSort
     */
    constructor(
        service: FunzaService
        , filterElement: ElementRef
        , matPaginator: MatPaginator
        , matSort: MatSort
    ) {
        super(service, filterElement, matPaginator, matSort);
    }

    remoteEnpoint: string = `${environment.appApi.apiBaseUrl}funzaproduct/pagequery`;

    public getFilter(rawFilterObject: {}): {} {


        let result = {};


        return result;
    }
}

export class FunzaColorsDataSource extends DataSourceAbstract<FunzaColorGrid>
{
    /**
     * Constructor
     *
     * @param {UserRolesListService} _service
     * @param {MatPaginator} _matPaginator
     * @param {MatSort} _matSort
     */
    constructor(
        service: FunzaService
        , filterElement: ElementRef
        , matPaginator: MatPaginator
        , matSort: MatSort
    ) {
        super(service, filterElement, matPaginator, matSort);
    }

    remoteEnpoint: string = `${environment.appApi.apiBaseUrl}funzaproduct/pagequery`;

    public getFilter(rawFilterObject: {}): {} {


        let result = {};


        return result;
    }
}


declare type ActiveOptions = 'products' | 'colors' | 'categories' | 'packings';