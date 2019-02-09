import { NgModule } from '@angular/core';
import { CustomerThirdPartyAppSettingService } from './customerthirdpartyappsetting.service';

export { CustomerThirdPartyAppSettingService } from './customerthirdpartyappsetting.service';

@NgModule({
    providers: [
        CustomerThirdPartyAppSettingService
    ]
})
export class CustomerThirdPartyAppSettingCoreModule {
}

