import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {
    MatButtonModule, MatCheckboxModule, MatDatepickerModule, MatFormFieldModule, MatIconModule, MatInputModule, MatMenuModule, MatRippleModule, MatSelectModule, MatDialogModule
} from '@angular/material';
import { NgxDnDModule } from '@swimlane/ngx-dnd';

import { FuseSharedModule } from '@fuse/shared.module';
import { FuseSidebarModule } from '@fuse/components';

import { CompositionViewService } from './composition.view.service';
import { CompositionViewComponent } from './composition.view.component';
import { TodoMainSidebarComponent } from './sidebars/main/main-sidebar.component';
import { CompositionViewListItemComponent } from './composition.view-list/composition.view-list-item/composition.view-list-item.component';
import { CompositionViewListComponent } from './composition.view-list/composition.view-list.component';
import { CompositionViewDetailsComponent } from './composition.view-details/composition.view-details.component';

import { HipalanetUtils } from '../../@hipalanetCommons/ngx-utils/main';
import { ProductCoreModule } from '../product.core.module';
import { CompositionViewBridgeNewDialogComponent } from './composition.view.bridgenew.dialog.component';

const routes: Routes = [
    {
        path     : 'all',
        component: CompositionViewComponent,
        resolve  : {
            todo: CompositionViewService
        }
    },
    {
        path     : 'all/:todoId',
        component: CompositionViewComponent,
        resolve  : {
            todo: CompositionViewService
        }
    },
    {
        path     : 'tag/:tagHandle',
        component: CompositionViewComponent,
        resolve  : {
            todo: CompositionViewService
        }
    },
    {
        path     : 'tag/:tagHandle/:todoId',
        component: CompositionViewComponent,
        resolve  : {
            todo: CompositionViewService
        }
    },
    {
        path     : 'filter/:filterHandle',
        component: CompositionViewComponent,
        resolve  : {
            todo: CompositionViewService
        }
    },
    {
        path     : 'filter/:filterHandle/:todoId',
        component: CompositionViewComponent,
        resolve  : {
            todo: CompositionViewService
        }
    },
    {
        path      : '**',
        redirectTo: 'all'
    }
];

@NgModule({
    declarations: [
        CompositionViewComponent
        , TodoMainSidebarComponent
        , CompositionViewListItemComponent
        , CompositionViewListComponent
        , CompositionViewDetailsComponent
        , CompositionViewBridgeNewDialogComponent
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
        , MatDialogModule
        
        , NgxDnDModule
        
        , FuseSharedModule
        , FuseSidebarModule

        , HipalanetUtils
        , ProductCoreModule
    ],
    providers   : [
        CompositionViewService
    ],
    exports: [
        CompositionViewComponent
    ],
    entryComponents: [
        CompositionViewBridgeNewDialogComponent
    ]
})
export class CompositionViewModule
{
}
