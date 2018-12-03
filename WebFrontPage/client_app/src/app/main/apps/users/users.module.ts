import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { FuseSharedModule } from '@fuse/shared.module';

import { usersComponent, userNewDialogComponent } from './users.component';
import { userComponent } from './user.component';
import { UserCoreModule, UserService } from './user.core.module';

import {
    MatCardModule, MatListModule, MatMenuModule, MatRadioModule, MatSidenavModule, MatToolbarModule,
    MatButtonModule, MatChipsModule, MatExpansionModule, MatFormFieldModule, MatIconModule, MatInputModule, MatPaginatorModule, MatRippleModule, MatSelectModule, MatSnackBarModule,
    MatSortModule,
    MatTableModule, MatTabsModule, MatDialog, MatDialogModule, MatDatepickerModule
} from '@angular/material';
import { PopupsModule } from '../@hipalanetCommons/popups/popups.module';

const routes: Routes = [
    {
        path: ':id',
        component: userComponent,
        resolve: {
            data: UserService,
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
        , userNewDialogComponent
        
    ],
    entryComponents: [
        userNewDialogComponent
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
    ],
    providers: [
        //usersService
        //, userservice
        //, usersListService
    ]
})
export class UsersModule {
}
