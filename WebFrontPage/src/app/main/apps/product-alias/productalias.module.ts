import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { FuseSharedModule } from '@fuse/shared.module';

import { ProductAliasComponent, ProductAliasNewDialogComponent } from './productalias.component';
import { ProductAliasCoreModule, ProductAliasService } from './productalias.core.module';

import {
    MatCardModule, MatListModule, MatMenuModule, MatRadioModule, MatSidenavModule, MatToolbarModule,
    MatButtonModule, MatChipsModule, MatExpansionModule, MatFormFieldModule, MatIconModule, MatInputModule, MatPaginatorModule, MatRippleModule, MatSelectModule, MatSnackBarModule,
    MatSortModule,
    MatTableModule, MatTabsModule, MatDialog, MatDialogModule, MatDatepickerModule, MatProgressBarModule
} from '@angular/material';
import { PopupsModule } from '../@hipalanetCommons/popups/popups.module';
import { CustomFileUploadModule } from '../@hipalanetCommons/fileupload/fileupload.module';
import { HipalanetUtils } from '../@hipalanetCommons/ngx-utils/main';
import { environment } from 'environments/environment';
import { ProductTypeResolveService, ProductColorTypeResolveService, ProductCategoryResolveService } from '../@resolveServices/resolve.module';

const routes: Routes = [
    {
        path: 'new',
        component: ProductAliasComponent,
        data: { action: 'new' },
        resolve: {
            listProductType: ProductTypeResolveService,
            listProductCategory: ProductCategoryResolveService,
        }
    },
    {
        path: ':id',
        component: ProductAliasComponent,
        resolve: {
            data: ProductAliasService,
            listProductColorType: ProductColorTypeResolveService,
        }
    },

    {
        path: '**',
        component: ProductAliasComponent,
        resolve: {
            // data: ProductsService
        }
    }
];

@NgModule({
    declarations: [
        ProductAliasComponent
        , ProductAliasComponent
        , ProductAliasNewDialogComponent
    ],
    entryComponents: [
        ProductAliasNewDialogComponent
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
        , MatProgressBarModule
        , FuseSharedModule

        , PopupsModule
        , ProductAliasCoreModule
        , CustomFileUploadModule
        , HipalanetUtils.forRoot({ fileRetrieveUrl: environment.appApi.apiUploadFileUrl })

    ],
    providers: [
    ]
})
export class ProductAliasModule {
}
