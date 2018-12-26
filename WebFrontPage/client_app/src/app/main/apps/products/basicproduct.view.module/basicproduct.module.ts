import { NgModule } from "@angular/core";
import { RouterModule, Routes } from '@angular/router';
import { FuseSharedModule } from '@fuse/shared.module';


import { ProductCoreModule } from "../product.core.module";
import { BasicProductComponent } from "./basicproduct.component";

import {
    MatCardModule, MatListModule, MatMenuModule, MatRadioModule, MatSidenavModule, MatToolbarModule,
    MatButtonModule, MatChipsModule, MatExpansionModule, MatFormFieldModule, MatIconModule, MatInputModule, MatPaginatorModule, MatRippleModule, MatSelectModule, MatSnackBarModule,
    MatSortModule,
    MatTableModule, MatTabsModule, MatDialog, MatDialogModule, MatDatepickerModule, MatProgressBarModule
} from '@angular/material';

import { PopupsModule } from '../../@hipalanetCommons/popups/popups.module';
import { CustomFileUploadModule } from '../../@hipalanetCommons/fileupload/fileupload.module';
import { HipalanetUtils } from '../../@hipalanetCommons/ngx-utils/main';


@NgModule({
    imports: [
        RouterModule

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
        , MatProgressBarModule
        , FuseSharedModule

        , PopupsModule
        , ProductCoreModule
        , CustomFileUploadModule
        , HipalanetUtils
    ]
    , declarations: [
        BasicProductComponent
    ]
    ,providers: [
    ],
    exports: [
        BasicProductComponent
    ]
})
export class BasicProductModule {
}

