import { Injectable, EventEmitter } from '@angular/core';
//import { SignalR, ISignalRConnection, BroadcastEventListener } from 'ng2-signalr';
import { IConnectionOptions } from 'ng2-signalr/src/services/connection/connection.options';

import { AuthenticationService } from '../authentication/authentication.service';
import { AuthenticationInfo } from '../authentication/authentication.model';
import { HubItem, HubConnectionOptions } from './signalr.model';
import { environment } from 'environments/environment';

import * as signalR from '@aspnet/signalr';

declare var $: any;


export class BaseSignalRService {
    private connections: HubItem[] = [];

    connect(hubName: string, url: string = null, options: HubConnectionOptions = null) {
        let connection = new signalR.HubConnectionBuilder()
            .configureLogging(signalR.LogLevel.Trace)
            .withUrl(`${environment.appApi.apiProjectUrl}${hubName}`)
            .build();

        let promise = new Promise<HubItem>((accept, reject) => {
            connection.start()
                .then(() => {
                    let hubItem = new HubItem();
                    hubItem.hubName = hubName;
                    hubItem.rawConnection = connection;
                    this.connections.push(hubItem);
                    accept(hubItem);
                },
                reject);
        });

        return promise;
    }

    addListener(hubName, eventName: string, action: (data: any) => void) {
        let item = this.connections.find(o => o.hubName == hubName);
        if (item !== null)
        {
            item.rawConnection.on(eventName, action);
        }
    }


    

}


//@Injectable()
//export class SignalRService {

//    private connections: ISignalRConnection;
//    onDataChangedMessage$: BroadcastEventListener<any>;
//    private onActiveUsersMessage$: BroadcastEventListener<any>;

//    onConnect: EventEmitter<ISignalRConnection>;
//    onActiveUsers: EventEmitter<ISignalRConnection>;
//    onDataChangedMessage: EventEmitter<ISignalRConnection>;

//    constructor(
//        public signalR: SignalR
//        , private authenticationService: AuthenticationService
//    ) {
//        this.setAuthentication();

//        this.onConnect = new EventEmitter<ISignalRConnection>();
//        this.onActiveUsers = new EventEmitter<ISignalRConnection>();

//        this.authenticationService.onChangedUserInfo.subscribe((user: AuthenticationInfo) => {
//            this.profileChanged(user);
//        });

//    }

//    profileChanged(profile: AuthenticationInfo) {
//        //debugger;
//        if (profile) {
//            if (!this.connection) {
//                this.createConnection(profile.accessToken);
//            }
//        }
//    }

//    private setAuthentication() {
//        // Set auth headers.
//        let $ = (<any>window).$;
//        $.signalR.ajaxDefaults.headers = {
//            'Content-Type': "application/json",
//            "Authorization": ''
//        };
//    }

   
//    private createConnection(accessToken) {
//        if (!this.connection) {
            
//            let options: IConnectionOptions = {
//                //qs: {'access_token': accessToken}
//            };

//            // debugger;
//            let connection = this.signalR.connect(options);
//            //this.connection = this.signalR.createConnection(options);
//            connection.then(connection => {
//                this.connection = connection;
//                this.configureListeners();
//                this.onConnect.next(this.connection);
//                this.onConnect.next(connection);

//            }, error => {
//                debugger;
//                console.log(`SignalR: `, error);
//                });
//        }
//    }

//    private configureListeners() {
//        // active users
//        /*
//        this.onActiveUsersMessage$ = new BroadcastEventListener<any>('userActiveLocationMessage');
//        this.connection.listen(this.onActiveUsersMessage$);
//        this.onActiveUsersMessage$.subscribe(activeUsersMessage => {
//            this.onActiveUsers.next(activeUsersMessage);
//        });
//        */

//        // global message
//        this.onDataChangedMessage$ = new BroadcastEventListener<any>('dataChanged');
//        this.connection.listen(this.onDataChangedMessage$);
//        this.onDataChangedMessage$.subscribe(messageData => {
//            debugger;
//            console.log(`SignalR dataChanged`, messageData);
//            this.onDataChangedMessage.next(messageData);
//        });

//        this.onDataChangedMessage$ = new BroadcastEventListener<any>('DataChanged');
//        this.connection.listen(this.onDataChangedMessage$);
//        this.onDataChangedMessage$.subscribe(messageData => {
//            debugger;
//            console.log(`SignalR dataChanged`, messageData);
//            this.onDataChangedMessage.next(messageData);
//        });
//    }
//}
