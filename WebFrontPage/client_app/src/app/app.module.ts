import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule, Routes } from '@angular/router';
import { MatMomentDateModule } from '@angular/material-moment-adapter';
import { MatButtonModule, MatIconModule } from '@angular/material';
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { TranslateModule } from '@ngx-translate/core';
import 'hammerjs';

import { FuseModule } from '@fuse/fuse.module';
import { FuseSharedModule } from '@fuse/shared.module';
import { FuseProgressBarModule, FuseSidebarModule, FuseThemeOptionsModule } from '@fuse/components';

import { fuseConfig } from 'app/fuse-config';

import { FakeDbService } from 'app/fake-db/fake-db.service';
import { AppComponent } from 'app/app.component';
import { AppStoreModule } from 'app/store/store.module';
import { LayoutModule } from 'app/layout/layout.module';

/******************************Custom************************************/
import { environment } from '../environments/environment';
//import { AngularFireModule } from '@angular/fire';
//import { AngularFirestoreModule } from '@angular/fire/firestore';
//import { AngularFireStorageModule } from '@angular/fire/storage';
//import { AngularFireAuthModule } from '@angular/fire/auth';
//import { AngularFireDatabaseModule } from '@angular/fire/database';


/******************************Authentication************************************/
import { AuthenticationCoreModule } from 'app/main/apps/@hipalanetCommons/authentication/authentication.core.module';
import { CustomSignalRModule } from './main/apps/@hipalanetCommons/signalr/signalr.module';
import { SignalRConfiguration } from 'ng2-signalr';
import { HiPalanetResolveModule } from './main/apps/@resolveServices//resolve.module';




const appRoutes: Routes = [
    {
        path        : 'apps',
        loadChildren: './main/apps/apps.module#AppsModule'
    },
    {
        path        : 'pages',
        loadChildren: './main/pages/pages.module#PagesModule'
    },
    {
        path        : 'ui',
        loadChildren: './main/ui/ui.module#UIModule'
    },
    {
        path        : 'documentation',
        loadChildren: './main/documentation/documentation.module#DocumentationModule'
    },
    {
        path        : 'angular-material-elements',
        loadChildren: './main/angular-material-elements/angular-material-elements.module#AngularMaterialElementsModule'
    },
    {
        path      : '**',
        redirectTo: 'apps/dashboards/analytics'
    }
];

@NgModule({
    declarations: [
        AppComponent
    ],
    imports     : [
        BrowserModule
        ,BrowserAnimationsModule
        ,HttpClientModule
        ,RouterModule.forRoot(appRoutes)
       
        ,TranslateModule.forRoot()
        ,InMemoryWebApiModule.forRoot(FakeDbService, {
            delay             : 0,
            passThruUnknownUrl: true
        })
        
        // Material moment date module
        ,MatMomentDateModule
        
        // Material
        ,MatButtonModule
        ,MatIconModule
        
        // Fuse modules
        ,FuseModule.forRoot(fuseConfig)
        ,FuseProgressBarModule
        ,FuseSharedModule
        ,FuseSidebarModule
        ,FuseThemeOptionsModule
        
        // App modules
        ,LayoutModule
        , AppStoreModule

        // Authentication
        , AuthenticationCoreModule
        , HiPalanetResolveModule
        , CustomSignalRModule

    ],
    exports: [
        AuthenticationCoreModule
    ],
    bootstrap   : [
        AppComponent
    ]
})
export class AppModule
{
}
