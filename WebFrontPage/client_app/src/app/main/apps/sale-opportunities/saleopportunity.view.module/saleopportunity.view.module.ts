import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {
    MatButtonModule, MatCheckboxModule, MatDatepickerModule, MatFormFieldModule, MatIconModule, MatInputModule, MatMenuModule, MatRippleModule, MatSelectModule
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

import { HipalanetUtils } from '../../@hipalanetCommons/ngx-utils/main';
import { SaleOpportunityCoreModule } from '../saleopportunity.core.module';
import { SaleOpportunityViewSettingsComponent } from './saleopportunity.view-settings/saleopportunity.view-settings.component';

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
        , SaleOpportunityViewListItemComponent
        , SaleOpportunityViewListComponent
        , SaleOpportunityViewDetailsComponent
        , SaleOpportunityViewSettingsComponent
    ],
    imports     : [
        RouterModule//.forChild(routes),

        , MatButtonModule
        , MatCheckboxModule
        , MatDatepickerModule
        , MatFormFieldModule
        , MatIconModule
        , MatInputModule
        , MatMenuModule
        , MatRippleModule
        , MatSelectModule
        
        , NgxDnDModule
        
        , FuseSharedModule
        , FuseSidebarModule

        , HipalanetUtils
        , SaleOpportunityCoreModule
    ],
    providers   : [
        SaleOpportunityViewService
    ],
    exports: [
        SaleOpportunityViewComponent
    ]
})
export class SaleOpportunityViewModule
{
}
