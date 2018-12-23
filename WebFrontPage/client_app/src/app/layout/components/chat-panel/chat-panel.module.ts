import { NgModule } from '@angular/core';
import { MatButtonModule, MatFormFieldModule, MatIconModule, MatInputModule, MatRippleModule, MatTabsModule, MatTooltipModule } from '@angular/material';

import { FuseSharedModule } from '@fuse/shared.module';

import { HipalanetUtils } from '../../../main/apps/@hipalanetCommons/ngx-utls/main';

import { ChatPanelComponent } from 'app/layout/components/chat-panel/chat-panel.component';
import { ChatPanelService } from 'app/layout/components/chat-panel/chat-panel.service';

@NgModule({
    declarations: [
        ChatPanelComponent
    ],
    providers   : [
        ChatPanelService
    ],
    imports     : [
        MatButtonModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        MatTabsModule,
        MatTooltipModule,
        MatRippleModule,

        FuseSharedModule,

        HipalanetUtils.forRoot({ fileRetrieveUrl: '' })
    ],
    exports     : [
        ChatPanelComponent
    ]
})
export class ChatPanelModule
{
}
