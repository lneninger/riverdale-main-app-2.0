import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { FuseSharedModule } from '@fuse/shared.module';

import {
    SaleOpportunitiesComponent,
    SaleOpportunityNewDialogComponent
} from './saleopportunities.component';
import { SaleOpportunityComponent } from './saleopportunity.component';
import {
    SaleOpportunityCoreModule,
    SaleOpportunityService
} from './saleopportunity.core.module';
import { SaleOpportunityViewModule } from './saleopportunity.view.module/saleopportunity.view.module';

import {
    MatCardModule,
    MatListModule,
    MatMenuModule,
    MatRadioModule,
    MatSidenavModule,
    MatToolbarModule,
    MatButtonModule,
    MatChipsModule,
    MatExpansionModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatPaginatorModule,
    MatRippleModule,
    MatSelectModule,
    MatSnackBarModule,
    MatSortModule,
    MatTableModule,
    MatTabsModule,
    MatDialogModule,
    MatDatepickerModule,
    MatProgressBarModule
} from '@angular/material';
import { PopupsModule } from '../@hipalanetCommons/popups/popups.module';
import { CustomFileUploadModule } from '../@hipalanetCommons/fileupload/fileupload.module';
import { HipalanetUtils } from '../@hipalanetCommons/ngx-utils/main';
import { environment } from 'environments/environment';
import {
    SaleSeasonCategoryTypeResolveService,
    ProductColorTypeResolveService,
    CustomerResolveService,
    ProductResolveService,
    GrowerTypeResolveService,
    ProductCategoryResolveService
} from '../@resolveServices/resolve.module';
import { SaleOpportunityViewComponent } from './saleopportunity.view.module/saleopportunity.view.component';
import { SaleOpportunityTargetPriceProductNewDialogComponent } from './saleopportunity.view.module/saleopportunity.view-targetprice/saleopportunities-targetpriceproductnew.dialog.component';

const routes: Routes = [
    {
        path: 'new',
        component: SaleOpportunitiesComponent,
        data: { action: 'new' },
        resolve: {
            listSeasonCategoryType: SaleSeasonCategoryTypeResolveService,
            listCustomer: CustomerResolveService,
            listGrower: GrowerTypeResolveService
        }
    },
    {
        path: ':id',
        component: SaleOpportunityViewComponent,
        resolve: {
            data: SaleOpportunityService,
            listProduct: ProductResolveService,
            listGrowerType: GrowerTypeResolveService,
            listProductColorType: ProductColorTypeResolveService,
            listProductCategory: ProductCategoryResolveService,
        }
       
    },
    // {
    //     path: ':id/newtargetprice',
    //     component: SaleOpportunityViewComponent,
    //     resolve: {
    //         data: SaleOpportunityService,
    //         listSaleSeasonCategoryType: SaleSeasonCategoryTypeResolveService

    //     }
    // },

    {
        path: '**',
        component: SaleOpportunitiesComponent,
        resolve: {
            // data: ProductsService
        }
    }
];

@NgModule({
    declarations: [
        SaleOpportunitiesComponent,
        SaleOpportunityComponent,
        SaleOpportunityNewDialogComponent,
    ],
    entryComponents: [SaleOpportunityNewDialogComponent],
    imports: [
        RouterModule.forChild(routes),

        MatButtonModule,
        MatCardModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        MatMenuModule,
        MatToolbarModule,
        MatRippleModule,
        MatSelectModule,
        MatTableModule,
        MatPaginatorModule,
        MatSortModule,
        MatChipsModule,
        MatTabsModule,
        MatDialogModule,
        MatSnackBarModule,
        MatDatepickerModule,
        MatProgressBarModule,
        FuseSharedModule,

        PopupsModule,
        SaleOpportunityCoreModule,
        SaleOpportunityViewModule,
        CustomFileUploadModule,
        HipalanetUtils.forRoot({
            fileRetrieveUrl: environment.appApi.apiUploadFileUrl
        })
    ],
    providers: []
})
export class SaleOpportunitiesModule {}
