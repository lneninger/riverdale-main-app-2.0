import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from "@angular/router";
import { NgxPageScrollModule } from 'ngx-page-scroll';

import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';

// Services
import { WINDOW_PROVIDERS } from "./services/windows.service";
import { LandingFixService } from '../shared/services/landing-fix.service';
import { LogoDirective } from './logo-directive/logo-directive.component';
import { FirebaseService } from './services/firebase.service';

@NgModule({
  exports: [
    CommonModule,
    HeaderComponent,
    FooterComponent,
    LogoDirective
  ],
  imports: [
    CommonModule,
    RouterModule,
    NgxPageScrollModule

  ],
  declarations: [
    HeaderComponent,
    FooterComponent,
    LogoDirective

  ],
  providers: [
    WINDOW_PROVIDERS,
    LandingFixService,
    FirebaseService
  ]
})
export class SharedModule { }
