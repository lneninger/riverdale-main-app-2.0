import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { FuseSharedModule } from '@fuse/shared.module';
//import { SettingsModule } from './settings/settings.module';

import { CustomersComponent } from './customers.component';
import { CustomersService } from './customers.service';
import { CustomersListService } from './customers.list.service';
import { CustomerComponent } from './customer.component';
import { CustomerService } from './customer.service';

import {
    MatCardModule, MatListModule, MatMenuModule, MatRadioModule, MatSidenavModule, MatToolbarModule,
    MatButtonModule, MatChipsModule, MatExpansionModule, MatFormFieldModule, MatIconModule, MatInputModule, MatPaginatorModule, MatRippleModule, MatSelectModule, MatSnackBarModule,
    MatSortModule,
    MatTableModule, MatTabsModule
} from '@angular/material';

const routes: Routes = [
    {
        path: ':id',
        component: CustomerComponent,
        resolve: {
            data: CustomerService
        }
    },

    {
        path: '**',
        component: CustomersComponent,
        resolve: {
            data: CustomersService
        }
    }
];

@NgModule({
    declarations: [
        CustomersComponent,
        CustomerComponent,
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

        , MatSnackBarModule
        , FuseSharedModule
    ],
    providers: [
        CustomersService
        , customerService
        , CustomersListService
    ]
})
export class CustomersModule {
}
