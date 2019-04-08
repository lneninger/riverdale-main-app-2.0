import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {
    MatButtonModule
    , MatCheckboxModule
    , MatTooltipModule
    , MatDatepickerModule
    , MatFormFieldModule
    , MatDialogModule
    , MatIconModule
    , MatInputModule
    , MatMenuModule
    , MatRippleModule
    , MatSelectModule
    , MatSnackBarModule
    , MatCardModule
    , MatListModule
} from '@angular/material';
import { NgxDnDModule } from '@swimlane/ngx-dnd';

import { FuseSharedModule } from '@fuse/shared.module';
import { FuseSidebarModule } from '@fuse/components';

import { SaleOpportunityViewService } from './saleopportunity.view.service';
import { SaleOpportunityViewComponent } from './saleopportunity.view.component';
import { TodoMainSidebarComponent } from './sidebars/main/main-sidebar.component';
import { SaleOpportunityViewListItemComponent } from './saleopportunity.view-list/saleopportunity.view-list-item/saleopportunity.view-list-item.component';
import { SaleOpportunityViewListComponent } from './saleopportunity.view-list/saleopportunity.view-list.component';
import { SaleOpportunityViewDetailsComponent } from './saleopportunity.view-details/saleopportunity.view-details.component';
import { SaleOpportunityViewSampleBoxesComponent } from './saleopportunity.view-sampleboxes/saleopportunity.view-sampleboxes.component';
import {SaleOpportunityTargetPriceNewDialogComponent} from './saleopportunity.view-targetprice/saleopportunities-targetpricenew.dialog.component';
import { SaleOpportunityViewTargetPricesComponent } from './saleopportunity.view-targetprice/saleopportunity.view-targetprices.component';

import { HipalanetUtils } from '../../@hipalanetCommons/ngx-utils/main';
import { SaleOpportunityCoreModule } from '../saleopportunity.core.module';
import { FunzaCoreModule } from '../../funza/funza.core.module';

import { SaleOpportunityViewSettingsComponent } from './saleopportunity.view-settings/saleopportunity.view-settings.component';
import { FormsModule } from '@angular/forms';
import { CustomerSidebarComponent } from './sidebars/customer/customer-sidebar.component';
import { SampleBoxProductNewDialogComponent } from './saleopportunity.view-sampleboxes/saleopportuny.view-sampleboxnew.dialog.component';
import { SaleOpportunityTargetPriceProductNewDialogComponent } from './saleopportunity.view-targetprice/saleopportunities-targetpriceproductnew.dialog.component';
import { ProductCoreModule } from '../../products/product.core.module';
import { SaleOpportunityViewListTargetPriceProductComponent } from './saleopportunity.view-list-targetpriceproducts/saleopportunity.view-list.component';
import { SaleOpportunityViewListItemTargetPriceProductComponent } from './saleopportunity.view-list-targetpriceproducts/saleopportunity.view-list-item/saleopportunity.view-list-item.component';
import { SaleOpportunityTargetPriceSubProductNewDialogComponent } from './saleopportunity.view-targetprice/saleopportunities-targetpricesubproductnew.dialog.component';
import { SaleOpportunityViewListTargetPriceSubProductComponent } from './saleopportunity.view-list-targetpricesubproducts/saleopportunity.view-list.component';
import { SaleOpportunityViewListItemTargetPriceSubProductComponent } from './saleopportunity.view-list-targetpricesubproducts/saleopportunity.view-list-item/saleopportunity.view-list-item.component';

const routes: Routes = [
    {
        path     : 'all',
        component: SaleOpportunityViewComponent,
        resolve  : {
            todo: SaleOpportunityViewService
        }
    },
    {
        path     : 'all/:todoId',
        component: SaleOpportunityViewComponent,
        resolve  : {
            todo: SaleOpportunityViewService
        }
    },
    {
        path     : 'tag/:tagHandle',
        component: SaleOpportunityViewComponent,
        resolve  : {
            todo: SaleOpportunityViewService
        }
    },
    {
        path     : 'tag/:tagHandle/:todoId',
        component: SaleOpportunityViewComponent,
        resolve  : {
            todo: SaleOpportunityViewService
        }
    },
    {
        path     : 'filter/:filterHandle',
        component: SaleOpportunityViewComponent,
        resolve  : {
            todo: SaleOpportunityViewService
        }
    },
    {
        path     : 'filter/:filterHandle/:todoId',
        component: SaleOpportunityViewComponent,
        resolve  : {
            todo: SaleOpportunityViewService
        }
    },
    {
        path      : '**',
        redirectTo: 'all'
    }
];

@NgModule({
    declarations: [
        SaleOpportunityViewComponent
        , TodoMainSidebarComponent
        , CustomerSidebarComponent
        , SaleOpportunityViewListItemComponent
        , SaleOpportunityViewListComponent
        , SaleOpportunityViewListItemTargetPriceProductComponent
        , SaleOpportunityViewListTargetPriceProductComponent
        , SaleOpportunityViewDetailsComponent
        , SaleOpportunityViewSampleBoxesComponent
        , SaleOpportunityViewSettingsComponent
        , SampleBoxProductNewDialogComponent
        , SaleOpportunityTargetPriceNewDialogComponent
        , SaleOpportunityViewTargetPricesComponent
        , SaleOpportunityTargetPriceProductNewDialogComponent

        , SaleOpportunityViewListTargetPriceSubProductComponent
        , SaleOpportunityViewListItemTargetPriceSubProductComponent
        , SaleOpportunityTargetPriceSubProductNewDialogComponent
        
    ],
    imports     : [
        RouterModule// .forChild(routes),
        , FormsModule
        , MatButtonModule
        , MatListModule
        , MatCheckboxModule
        , MatDatepickerModule
        , MatFormFieldModule
        , MatIconModule
        , MatInputModule
        , MatMenuModule
        , MatRippleModule
        , MatSelectModule
        , MatSnackBarModule
        , MatTooltipModule
        , MatDialogModule
        , MatCardModule

        , NgxDnDModule
        
        , FuseSharedModule
        , FuseSidebarModule

        , HipalanetUtils
        , SaleOpportunityCoreModule
        , FunzaCoreModule
        , ProductCoreModule
    ],
    providers   : [
        SaleOpportunityViewService
    ],
    exports: [
        SaleOpportunityViewComponent
        , SaleOpportunityTargetPriceNewDialogComponent
        , SaleOpportunityTargetPriceProductNewDialogComponent
        , SaleOpportunityTargetPriceSubProductNewDialogComponent
    ],
    entryComponents: [
        SampleBoxProductNewDialogComponent
        , SaleOpportunityTargetPriceNewDialogComponent
        , SaleOpportunityTargetPriceProductNewDialogComponent
    ]
})
export class SaleOpportunityViewModule
{
}
