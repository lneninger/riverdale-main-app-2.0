import { Injectable, EventEmitter } from '@angular/core';
//import { SignalR, ISignalRConnection, BroadcastEventListener } from 'ng2-signalr';
//import { IConnectionOptions } from 'ng2-signalr/src/services/connection/connection.options';

//import { AuthenticationService } from '../authentication/authentication.service';
//import { AuthenticationInfo } from '../authentication/authentication.model';
//import { HubItem, HubConnectionOptions } from './signalr.model';

//import * as signalR from '@aspnet/signalr';
import { BaseSignalRService } from './basesignalr.service';
import { Subject } from 'rxjs';
import { ISignalREventArgs } from './signalr.model';

declare var $: any;

@Injectable()
export class SignalRService extends BaseSignalRService{

    onDataChanged: Subject<ISignalREventArgs> = new Subject<ISignalREventArgs>();
    onActiveUsers: Subject<any> = new Subject<any>();

    constructor() {
        super();
        let promise = this.connect('globalhub');

        promise.then(hubItem => {
            this.addListener('globalhub', 'dataChanged', (data: ISignalREventArgs) => {
                //debugger;
                console.log(`event from Server: `, data);
                this.onDataChanged.next(data);
            });

            this.addListener('globalhub', 'activeUsers', (data: any) => {
                //debugger;
                console.log(`event from Server: `, data);
                this.onActiveUsers.next(data);
            });
        });
        
    }

}

