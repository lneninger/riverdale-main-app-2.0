import { NgModule } from '@angular/core';
import { SignalRModule, SignalR, ISignalRConnection } from 'ng2-signalr';
import { Router, ActivationEnd } from '@angular/router';
import { SignalRService } from './signalr.service';
import { UserActiveService } from './useractive.service';

export { SignalRService } from './signalr.service';
export { UserActiveService } from './useractive.service';


@NgModule({
    imports: [
        SignalRModule
    ],
    providers: [
        SignalRService,
        UserActiveService
    ]
})
export class CustomSignalRModule {

}
