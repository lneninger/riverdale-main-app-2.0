import { NgModule } from "@angular/core";
import { RouterModule, Routes } from '@angular/router';
import { FuseSharedModule } from '@fuse/shared.module';


import { ProductCategoryCoreModule, ProductCategoryService } from "./productcategory.core.module";
import { ProductCategoryComponent } from "./productcategory.component";

import {
    MatCardModule, MatListModule, MatMenuModule, MatRadioModule, MatSidenavModule, MatToolbarModule,
    MatButtonModule, MatChipsModule, MatExpansionModule, MatFormFieldModule, MatIconModule, MatInputModule, MatPaginatorModule, MatRippleModule, MatSelectModule, MatSnackBarModule,
    MatSortModule, MatAutocompleteModule, 
    MatTableModule, MatTabsModule, MatDialog, MatDialogModule, MatDatepickerModule, MatProgressBarModule, MatCheckboxModule
} from '@angular/material';

import { PopupsModule } from '../@hipalanetCommons/popups/popups.module';
import { CustomFileUploadModule } from '../@hipalanetCommons/fileupload/fileupload.module';
import { HipalanetUtils } from '../@hipalanetCommons/ngx-utils/main';
import { ProductCategoriesComponent, ProductCategoryNewDialogComponent } from "./productcategories.component";
import { ProductTypeResolveService, ProductColorTypeResolveService } from "../@resolveServices/resolve.module";
import { ProductCategoryAllowedColorTypeService } from "./productcategoryallowedcolortype.service";


const routes: Routes = [
    {
        path: 'new',
        component: ProductCategoriesComponent,
        data: { action: 'new' },
        resolve: {
            listProductType: ProductTypeResolveService,
        }
    },
    {
        path: ':id',
        component: ProductCategoryComponent,
        resolve: {
            data: ProductCategoryService,
            listProductColorType: ProductColorTypeResolveService,
        }
    },

    {
        path: '**',
        component: ProductCategoriesComponent,
        resolve: {
            // data: ProductsService
        }
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(routes)

        , MatButtonModule
        , MatCheckboxModule
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
        , MatAutocompleteModule
        , FuseSharedModule

        , PopupsModule
        , ProductCategoryCoreModule
        , CustomFileUploadModule
        , HipalanetUtils
    ]
    , declarations: [
        ProductCategoryComponent
        , ProductCategoriesComponent
        , ProductCategoryNewDialogComponent
    ]
    ,providers: [
    ],
    exports: [
        ProductCategoryComponent
        , ProductCategoriesComponent
    ],
    entryComponents: [
        ProductCategoryNewDialogComponent
    ]
})
export class ProductCategoriesModule {
}

