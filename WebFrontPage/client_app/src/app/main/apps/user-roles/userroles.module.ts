import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { FuseSharedModule } from '@fuse/shared.module';

import { UserRolesComponent, UserRoleNewDialogComponent } from './userroles.component';
import { UserRoleComponent } from './userRole.component';
import { UserRoleCoreModule, UserRoleService } from './userRole.core.module';

import {
    MatCardModule, MatListModule, MatMenuModule, MatRadioModule, MatSidenavModule, MatToolbarModule,
    MatButtonModule, MatChipsModule, MatExpansionModule, MatFormFieldModule, MatIconModule, MatInputModule, MatPaginatorModule, MatRippleModule, MatSelectModule, MatSnackBarModule,
    MatSortModule,
    MatTableModule, MatTabsModule, MatDialog, MatDialogModule, MatDatepickerModule
} from '@angular/material';
import { ThirdPartyAppTypeResolveService, UserRoleFreightoutRateTypeResolveService } from '../@resolveServices/resolve.module';
import { RolePermissionCoreModule  } from '../userRolethirdpartyappsetting/userRolethirdpartyappsetting.core.module';
import { UserRoleFreightoutCoreModule } from '../userRolefreightout/userRolefreightout.core.module';
import { PopupsModule } from '../@hipalanetCommons/popups/popups.module';

const routes: Routes = [
    {
        path: ':id',
        component: UserRoleComponent,
        resolve: {
            data: UserRoleService,
            listThirdParty: ThirdPartyAppTypeResolveService,
            listUserRoleFreightoutRateType: UserRoleFreightoutRateTypeResolveService
        }
    },

    {
        path: '**',
        component: UserRolesComponent,
        resolve: {
            //data: UserRolesService
        }
    }
];

@NgModule({
    declarations: [
        UserRolesComponent
        , UserRoleComponent
        , UserRoleNewDialogComponent
        
    ],
    entryComponents: [
        UserRoleNewDialogComponent
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
        , MatDialogModule
        , MatSnackBarModule
        , MatDatepickerModule
        , FuseSharedModule

        , PopupsModule
        , UserRoleCoreModule
        , UserRoleThirdPartyAppSettingCoreModule
        , UserRoleFreightoutCoreModule
    ],
    providers: [
        //UserRolesService
        //, UserRoleService
        //, UserRolesListService
    ]
})
export class UserRolesModule {
}
