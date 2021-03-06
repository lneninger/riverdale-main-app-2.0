import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { FuseSharedModule } from '@fuse/shared.module';

import { CustomersComponent, CustomerNewDialogComponent } from './customers.component';
import { CustomerComponent } from './customer.component';
import { CustomerCoreModule, CustomerService } from './customer.core.module';

import {
    MatCardModule, MatListModule, MatMenuModule, MatRadioModule, MatSidenavModule, MatToolbarModule,
    MatButtonModule, MatChipsModule, MatExpansionModule, MatFormFieldModule, MatIconModule, MatInputModule, MatPaginatorModule, MatRippleModule, MatSelectModule, MatSnackBarModule,
    MatSortModule,
    MatTableModule, MatTabsModule, MatDialog, MatDialogModule, MatDatepickerModule
} from '@angular/material';
import { ThirdPartyAppTypeResolveService, CustomerFreightoutRateTypeResolveService } from '../@resolveServices/resolve.module';
import { CustomerThirdPartyAppSettingCoreModule } from '../customerthirdpartyappsetting/customerthirdpartyappsetting.core.module';
import { CustomerFreightoutCoreModule } from '../customerfreightout/customerfreightout.core.module';
import { PopupsModule } from '../@hipalanetCommons/popups/popups.module';

const routes: Routes = [
    {
        path: 'new',
        component: CustomersComponent,
        data: { action: 'new' },
        resolve: {
        }
    },
    {
        path: ':id',
        component: CustomerComponent,
        resolve: {
            data: CustomerService,
            listThirdParty: ThirdPartyAppTypeResolveService,
            listCustomerFreightoutRateType: CustomerFreightoutRateTypeResolveService
        }
    },

    {
        path: '**',
        component: CustomersComponent,
        resolve: {
            //data: CustomersService
        }
    }
];

@NgModule({
    declarations: [
        CustomersComponent
        , CustomerComponent
        , CustomerNewDialogComponent

    ],
    entryComponents: [
        CustomerNewDialogComponent
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
        , CustomerCoreModule
        , CustomerThirdPartyAppSettingCoreModule
        , CustomerFreightoutCoreModule
    ],
    providers: [
        //CustomersService
        //, CustomerService
        //, CustomersListService
    ]
})
export class CustomersModule {
}
