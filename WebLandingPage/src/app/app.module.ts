import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { Http, HttpModule } from '@angular/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from "./shared/shared.module";

import { AngularFireModule } from '@angular/fire';
import { AngularFirestoreModule } from '@angular/fire/firestore';
import { environment } from '../environments/environment';

import { rootRouterConfig } from './app.routes';
import { AppComponent } from './app.component';
import { DemoComponent } from './demo/demo.component';
import { BlogComponent } from './blog/blog.component';
import * as $ from 'jquery';
import { AngularFireDatabaseModule } from '@angular/fire/database';
import { NgxStripeModule } from 'ngx-stripe';

@NgModule({
  declarations: [
    AppComponent,
    DemoComponent,
    BlogComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    BrowserAnimationsModule,
    SharedModule,
    RouterModule.forRoot(rootRouterConfig, { useHash: false, anchorScrolling: 'enabled', scrollPositionRestoration: 'enabled' }),
    AngularFireModule.initializeApp(environment.firebase),
    AngularFirestoreModule,
    AngularFireDatabaseModule,
    NgxStripeModule.forRoot('pk_test_iOFzxDfz6HHS7YLCWKlHrzIK005l1FQE5O'),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
