import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FuseSidebarModule } from '@fuse/components';

import { FuseSharedModule } from '@fuse/shared.module';
import { FuseDemoModule } from '@fuse/components/demo/demo.module';

import { SettingsComponent } from './settings.component';
import { NotificationGroupSettingsService } from './settings.service';

import {
    MatCardModule, MatDividerModule, MatListModule, MatMenuModule, MatRadioModule, MatSidenavModule, MatToolbarModule,
    MatButtonModule, MatChipsModule, MatExpansionModule, MatFormFieldModule, MatIconModule, MatInputModule, MatPaginatorModule, MatRippleModule, MatSelectModule, MatSnackBarModule,
    MatSortModule,
    MatTableModule, MatTabsModule


} from '@angular/material';

const routes: Routes = [
    {
        path: '**',
        component: SettingsComponent,
        resolve: {
            data: NotificationGroupSettingsService
        }
    }
];

@NgModule({
    declarations: [
        SettingsComponent
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
        , MatListModule
        
        , MatSnackBarModule
        , FuseSharedModule
        , FuseSidebarModule
        , FuseDemoModule
        
    ],
    providers: [
        NotificationGroupSettingsService
    ]
})
export class SettingsModule {
}
