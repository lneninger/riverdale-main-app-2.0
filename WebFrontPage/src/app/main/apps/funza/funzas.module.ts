import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { FuseSharedModule } from '@fuse/shared.module';

import { FunzasComponent } from './funzas.component';
import { FunzaCoreModule, FunzaService } from './funza.core.module';

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
        path: '**',
        component: FunzasComponent,
        resolve: {
            //data: UserRolesService
        }
    }
];

@NgModule({
    declarations: [
        FunzasComponent
    ],
    entryComponents: [
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
        , FunzaCoreModule
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
export class FunzasModule {
}
