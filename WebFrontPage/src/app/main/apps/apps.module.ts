import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { FuseSharedModule } from '@fuse/shared.module';
import { CustomSignalRModule } from './@hipalanetCommons/signalr/signalr.module'
//import { AuthenticationCoreModule } from './@hipalanetCommons/authentication/authentication.core.module';
import { HipalanetUtils } from './@hipalanetCommons/ngx-utils/main';
import { environment } from 'environments/environment';
import { EnvironmentData } from './@hipalanetCommons/ngx-utils/_common';

const routes = [
    {
        path        : 'dashboards/analytics',
        loadChildren: './dashboards/analytics/analytics.module#AnalyticsDashboardModule'
    },
    {
        path        : 'dashboards/project',
        loadChildren: './dashboards/project/project.module#ProjectDashboardModule'
    },
    {
        path        : 'mail',
        loadChildren: './mail/mail.module#MailModule'
    },
    {
        path        : 'mail-ngrx',
        loadChildren: './mail-ngrx/mail.module#MailNgrxModule'
    },
    {
        path        : 'chat',
        loadChildren: './chat/chat.module#ChatModule'
    },
    {
        path        : 'calendar',
        loadChildren: './calendar/calendar.module#CalendarModule'
    },
    {
        path        : 'e-commerce',
        loadChildren: './e-commerce/e-commerce.module#EcommerceModule'
    },
    {
        path        : 'academy',
        loadChildren: './academy/academy.module#AcademyModule'
    },
    {
        path        : 'todo',
        loadChildren: './todo/todo.module#TodoModule'
    },
    {
        path        : 'file-manager',
        loadChildren: './file-manager/file-manager.module#FileManagerModule'
    },
    {
        path        : 'contacts',
        loadChildren: './contacts/contacts.module#ContactsModule'
    },
    {
        path        : 'scrumboard',
        loadChildren: './scrumboard/scrumboard.module#ScrumboardModule'
    },
    //{
    //    path: 'notification-groups',
    //    loadChildren: './notification-groups/notificationgroups.module#NotificationGroupsModule'
    //},
    {
        path: 'customers',
        loadChildren: './customers/customers.module#CustomersModule'
    },
    {
        path: 'growers',
        loadChildren: './growers/growers.module#GrowersModule'
    },
    {
        path: 'product-colors',
        loadChildren: './product-color/productcolors.module#ProductColorsModule'
    },
    {
        path: 'users',
        loadChildren: './users/users.module#UsersModule'
    },
    {
        path: 'roles',
        loadChildren: './user-roles/userroles.module#UserRolesModule'
    },
    {
        path: 'products',
        loadChildren: './products/products.module#ProductsModule'
    },
    {
        path: 'productcategories',
        loadChildren: './productcategories/productcategories.module#ProductCategoriesModule'
    },
    {
        path: 'productalias',
        loadChildren: './product-alias/productalias.module#ProductAliasModule'
    },
    {
        path: 'saleopportunities',
        loadChildren: './sale-opportunities/saleopportunities.module#SaleOpportunitiesModule'
    }
    ,
    {
        path: 'funza',
        loadChildren: './funza/funzas.module#FunzasModule'
    }

    
];

@NgModule({
    imports     : [
        RouterModule.forChild(routes)
        , FuseSharedModule
        //, AuthenticationCoreModule
        
        , HipalanetUtils.forRoot({ fileRetrieveUrl: environment.appApi.apiUploadFileUrl })
    ],
    exports: [
        //AuthenticationCoreModule
    ]
})
export class AppsModule
{
}
