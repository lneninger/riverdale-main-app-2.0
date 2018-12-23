import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { FuseSharedModule } from '@fuse/shared.module';

import { usersComponent, UserNewDialogComponent } from './users.component';
import { userComponent } from './user.component';
import { UserCoreModule, UserService } from './user.core.module';

import {
    MatCardModule, MatListModule, MatMenuModule, MatRadioModule, MatSidenavModule, MatToolbarModule,
    MatButtonModule, MatChipsModule, MatExpansionModule, MatFormFieldModule, MatIconModule, MatInputModule, MatPaginatorModule, MatRippleModule, MatSelectModule, MatSnackBarModule,
    MatSortModule,
    MatTableModule, MatTabsModule, MatDialog, MatDialogModule, MatDatepickerModule
} from '@angular/material';
import { PopupsModule } from '../@hipalanetCommons/popups/popups.module';
import { RoleUserService } from '../role-users/roleuser.service';
import { RoleUserCoreModule } from '../role-users/roleuser.core.module';
import { RoleResolveService } from '../@resolveServices/resolve.module';

const routes: Routes = [
    {
        path: ':id',
        component: userComponent,
        resolve: {
            data: UserService,
            listRole: RoleResolveService,
        }
    },

    {
        path: '**',
        component: usersComponent,
        resolve: {
            //data: usersService
        }
    }
];

@NgModule({
    declarations: [
        usersComponent
        , userComponent
        , UserNewDialogComponent
        
    ],
    entryComponents: [
        UserNewDialogComponent
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
        , UserCoreModule
        , RoleUserCoreModule
    ],
    providers: [
        //usersService
        //, userservice
        //, usersListService
    ]
})
export class UsersModule {
}
