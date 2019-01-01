import { NgModule } from '@angular/core';
import { SignalRModule, SignalR, ISignalRConnection, SignalRConfiguration } from 'ng2-signalr';
import { Router, ActivationEnd } from '@angular/router';
import { SignalRService } from './signalr.service';
import { UserActiveService } from './useractive.service';
import { environment } from 'environments/environment';

export { SignalRService } from './signalr.service';
export { UserActiveService } from './useractive.service';

//export function createConfig(): SignalRConfiguration {

//    const c = new SignalRConfiguration();

//    c.hubName = 'GlobalHub';
//    //c.qs = { user: 'donald' };
//    //c.qs = { 'access_token': o.accessToken };
//    //c.
//    c.url = environment.appApi.apiProjectUrl.endsWith('/') ? environment.appApi.apiProjectUrl.substring(0, environment.appApi.apiProjectUrl.length - 1) : environment.appApi.apiProjectUrl;
//    c.logging = true;
//    //c.withCredentials = true;

//    // >= v5.0.0
//    c.executeEventsInZone = true; // optional, default is true
//    c.executeErrorsInZone = false; // optional, default is false
//    c.executeStatusChangeInZone = true; // optional, default is true
//    return c;
//}

@NgModule({
    imports: [
        //SignalRModule.forRoot(createConfig),
    ],
    providers: [
        SignalRService,
        UserActiveService
    ]
})
export class CustomSignalRModule {

}
