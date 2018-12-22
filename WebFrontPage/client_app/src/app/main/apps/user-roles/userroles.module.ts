import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { FuseSharedModule } from '@fuse/shared.module';

import { UserRolesComponent, UserRoleNewDialogComponent } from './userroles.component';
import { UserRoleComponent } from './userrole.component';
import { UserRoleCoreModule, UserRoleService } from './userrole.core.module';

import {
    MatCardModule, MatListModule, MatMenuModule, MatRadioModule, MatSidenavModule, MatToolbarModule,
    MatButtonModule, MatChipsModule, MatExpansionModule, MatFormFieldModule, MatIconModule, MatInputModule, MatPaginatorModule, MatRippleModule, MatSelectModule, MatSnackBarModule,
    MatSortModule,
    MatTableModule, MatTabsModule, MatDialog, MatDialogModule, MatDatepickerModule
} from '@angular/material';
import { PermissionResolveService } from '../@resolveServices/resolve.module';
import { UserResolveService } from '../@resolveServices/resolve.module';
import { RolePermissionCoreModule  } from '../role-permissions/rolepermission.core.module';
import { RoleUserCoreModule  } from '../role-users/roleuser.core.module';
import { UserCoreModule } from '../users/user.core.module';
import { PopupsModule } from '../@hipalanetCommons/popups/popups.module';

const routes: Routes = [
    {
        path: ':id',
        component: UserRoleComponent,
        resolve: {
            data: UserRoleService,
            listPermission: PermissionResolveService,
            listUser: UserResolveService
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
        , RolePermissionCoreModule
        , RoleUserCoreModule
        , UserCoreModule
    ],
    providers: [
        //UserRolesService
        //, UserRoleService
        //, UserRolesListService
    ]
})
export class UserRolesModule {
}
