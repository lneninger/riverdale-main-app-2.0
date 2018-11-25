import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { FuseSharedModule } from '@fuse/shared.module';

import { ProductColorsComponent, ProductColorNewDialogComponent } from './productcolors.component';
import { ProductColorCoreModule, ProductColorService } from './productcolor.core.module';

import {
    MatCardModule, MatListModule, MatMenuModule, MatRadioModule, MatSidenavModule, MatToolbarModule,
    MatButtonModule, MatChipsModule, MatExpansionModule, MatFormFieldModule, MatIconModule, MatInputModule, MatPaginatorModule, MatRippleModule, MatSelectModule, MatSnackBarModule,
    MatSortModule,
    MatTableModule, MatTabsModule, MatDialog, MatDialogModule, MatCheckboxModule
} from '@angular/material';

const routes: Routes = [
    

    {
        path: '**',
        component: ProductColorsComponent,
        resolve: {
        }
    }
];

@NgModule({
    declarations: [
        ProductColorsComponent
        //, ProductColorComponent
        , ProductColorNewDialogComponent
        
    ],
    entryComponents: [
        ProductColorNewDialogComponent
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
        , MatCheckboxModule
        , FuseSharedModule

        , ProductColorCoreModule
    ],
    providers: [
    ]
})
export class ProductColorsModule {
}
