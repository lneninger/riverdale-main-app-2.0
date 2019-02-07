import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { FuseSharedModule } from '@fuse/shared.module';

import { GrowersComponent, GrowerNewDialogComponent } from './growers.component';
import { GrowerComponent } from './grower.component';
import { GrowerCoreModule, GrowerService } from './grower.core.module';

import {
    MatCardModule, MatListModule, MatMenuModule, MatRadioModule, MatSidenavModule, MatToolbarModule,
    MatButtonModule, MatChipsModule, MatExpansionModule, MatFormFieldModule, MatIconModule, MatInputModule, MatPaginatorModule, MatRippleModule, MatSelectModule, MatSnackBarModule,
    MatSortModule,
    MatTableModule, MatTabsModule, MatDialog, MatDialogModule, MatDatepickerModule
} from '@angular/material';
import { GrowerTypeResolveService } from '../@resolveServices/resolve.module';
import { PopupsModule } from '../@hipalanetCommons/popups/popups.module';

const routes: Routes = [
    {
        path: 'new',
        component: GrowersComponent,
        data: { action: 'new' },
        resolve: {
        }
    },
    {
        path: ':id',
        component: GrowerComponent,
        resolve: {
            data: GrowerService,
            listGrowerType: GrowerTypeResolveService
        }
    },

    {
        path: '**',
        component: GrowersComponent,
        resolve: {
            //data: GrowersService
        }
    }
];

@NgModule({
    declarations: [
        GrowersComponent
        , GrowerComponent
        , GrowerNewDialogComponent

    ],
    entryComponents: [
        GrowerNewDialogComponent
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
        , GrowerCoreModule
    ],
    providers: [
        //GrowersService
        //, GrowerService
        //, GrowersListService
    ]
})
export class GrowersModule {
}
