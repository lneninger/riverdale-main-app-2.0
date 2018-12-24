import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { FuseSharedModule } from '@fuse/shared.module';

import { ProductsComponent, ProductNewDialogComponent } from './products.component';
import { ProductComponent } from './product.component';
import { ProductCoreModule, ProductService } from './product.core.module';

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
import { ProductTypeResolveService } from '../@resolveServices/resolve.module';

const routes: Routes = [
    {
        path: 'new',
        component: ProductsComponent,
        data: { action: 'new' },
        resolve: {
            listProductType: ProductTypeResolveService,
        }
    },
    {
        path: ':id',
        component: ProductComponent,
        resolve: {
            data: ProductService,
        }
    },

    {
        path: '**',
        component: ProductsComponent,
        resolve: {
            //data: ProductsService
        }
    }
];

@NgModule({
    declarations: [
        ProductsComponent
        , ProductComponent
        , ProductNewDialogComponent
    ],
    entryComponents: [
        ProductNewDialogComponent
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
        , ProductCoreModule
        , CustomFileUploadModule
        , HipalanetUtils.forRoot({ fileRetrieveUrl: environment.appApi.apiUploadFileUrl })

    ],
    providers: [
    ]
})
export class ProductsModule {
}
