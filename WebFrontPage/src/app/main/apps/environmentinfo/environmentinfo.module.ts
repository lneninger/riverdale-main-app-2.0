import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import {
    MatCardModule, MatListModule, MatMenuModule, MatRadioModule, MatSidenavModule, MatToolbarModule,
    MatButtonModule, MatChipsModule, MatExpansionModule, MatFormFieldModule, MatIconModule, MatInputModule, MatPaginatorModule, MatRippleModule, MatSelectModule, MatSnackBarModule,
    MatSortModule,
    MatTableModule, MatTabsModule, MatDialog, MatDialogModule, MatDatepickerModule
} from '@angular/material';
import { FuseSharedModule } from '@fuse/shared.module';
import { PopupsModule } from '../@hipalanetCommons/popups/popups.module';

import {
    EnvironmentInfoComponent,
    EnvironmentInfoModalDialogComponent
} from './environmentinfo.component';

@NgModule({
    imports: [
        CommonModule,
        RouterModule,
        MatButtonModule,
        MatCardModule,
        MatListModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        MatMenuModule,
        MatToolbarModule,
        MatRippleModule,
        MatSelectModule,
        MatTableModule,
        MatPaginatorModule,
        MatSortModule,
        MatChipsModule,
        MatTabsModule,
        MatDialogModule,
        MatSnackBarModule,
        MatDatepickerModule,
        FuseSharedModule,

        PopupsModule
    ],
    declarations: [
        EnvironmentInfoComponent,
        EnvironmentInfoModalDialogComponent
    ],
    exports: [EnvironmentInfoComponent],
    entryComponents: [EnvironmentInfoModalDialogComponent]
})
export class EnvironmentInfoModule {}
