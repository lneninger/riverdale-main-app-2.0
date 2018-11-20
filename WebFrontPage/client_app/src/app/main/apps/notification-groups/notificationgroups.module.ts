import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { FuseSharedModule } from '@fuse/shared.module';
//import { SettingsModule } from './settings/settings.module';

import { NotificationGroupsComponent } from 'app/main/apps/notification-groups/notificationgroups.component';
import { NotificationGroupsService } from 'app/main/apps/notification-groups/notificationgroups.service';
import { NotificationGroupComponent } from 'app/main/apps/notification-groups/notificationgroup.component';
import { NotificationGroupService } from 'app/main/apps/notification-groups/notificationgroup.service';

import {
    MatCardModule, MatListModule, MatMenuModule, MatRadioModule, MatSidenavModule, MatToolbarModule,
    MatButtonModule, MatChipsModule, MatExpansionModule, MatFormFieldModule, MatIconModule, MatInputModule, MatPaginatorModule, MatRippleModule, MatSelectModule, MatSnackBarModule,
    MatSortModule,
    MatTableModule, MatTabsModule
} from '@angular/material';

const routes: Routes = [
    //{
    //    path: 'settings',
    //    loadChildren: 'apps/notification-groups/settings/settings.module#SettingsModule',
    //},
    {
        path: 'settings',
        loadChildren: './settings/settings.module#SettingsModule',
    },
    {
        path: ':id',
        //component: NotificationGroupComponent,
        children: [
            {
            path: '**',
            resolve: {
                data: NotificationGroupService
            }
        }]

    },

{
    path: '**',
        component: NotificationGroupsComponent,
            resolve: {
        data: NotificationGroupsService
    }
}
];

@NgModule({
    declarations: [
        NotificationGroupsComponent,
        NotificationGroupComponent,
    ],
    imports: [
        RouterModule.forChild(routes)

        , MatButtonModule
        , MatCardModule
        , MatFormFieldModule
        , MatIconModule
        , MatInputModule
        , MatMenuModule
        , MatToolbarModule
        , MatRippleModule
        , MatSelectModule
        , MatTableModule
        , MatPaginatorModule
        , MatSortModule
        , MatChipsModule
        , MatTabsModule

        , MatSnackBarModule
        , FuseSharedModule
        //, SettingsModule
    ],
    providers: [
        NotificationGroupsService,
        NotificationGroupService,
    ]
})
export class NotificationGroupsModule {
}
