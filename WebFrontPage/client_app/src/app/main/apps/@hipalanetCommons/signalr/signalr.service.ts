import { Injectable, EventEmitter } from '@angular/core';
import { SignalR, ISignalRConnection, BroadcastEventListener } from 'ng2-signalr';
import { IConnectionOptions } from 'ng2-signalr/src/services/connection/connection.options';

import { AuthenticationService } from '../authentication/authentication.service';
import { AuthenticationInfo } from '../authentication/authentication.model';

declare var $: any;

@Injectable()
export class SignalRService {

    private connection: ISignalRConnection;
    onDataChangedMessage$: BroadcastEventListener<any>;
    private onActiveUsersMessage$: BroadcastEventListener<any>;

    onConnect: EventEmitter<ISignalRConnection>;
    onActiveUsers: EventEmitter<ISignalRConnection>;
    onDataChangedMessage: EventEmitter<ISignalRConnection>;

    constructor(
        public signalR: SignalR
        , private authenticationService: AuthenticationService
    ) {
        this.setAuthentication();

        this.onConnect = new EventEmitter<ISignalRConnection>();
        this.onActiveUsers = new EventEmitter<ISignalRConnection>();

        this.authenticationService.onChangedUserInfo.subscribe((user: AuthenticationInfo) => {
            this.profileChanged(user);
        });

    }

    profileChanged(profile: AuthenticationInfo) {
        //debugger;
        if (profile) {
            if (!this.connection) {
                this.createConnection(profile.accessToken);
            }
        }
    }

    private setAuthentication() {
        // Set auth headers.
        let $ = (<any>window).$;
        $.signalR.ajaxDefaults.headers = {
            'Content-Type': "application/json",
            "Authorization": ''
        };
    }

   
    private createConnection(accessToken) {
        if (!this.connection) {
            
            let options: IConnectionOptions = {
                qs: {'access_token': accessToken}
            };

            this.connection = this.signalR.createConnection(options);
            this.connection.start().then(connection => {
                this.connection = connection;
                this.configureListeners();
                this.onConnect.next(this.connection);
                this.onConnect.next(connection);

            });
        }
    }

    private configureListeners() {
        // active users
        /*
        this.onActiveUsersMessage$ = new BroadcastEventListener<any>('userActiveLocationMessage');
        this.connection.listen(this.onActiveUsersMessage$);
        this.onActiveUsersMessage$.subscribe(activeUsersMessage => {
            this.onActiveUsers.next(activeUsersMessage);
        });
        */

        // global message
        this.onDataChangedMessage$ = new BroadcastEventListener<any>('dataChanged');
        this.connection.listen(this.onDataChangedMessage$);
        this.onDataChangedMessage$.subscribe(messageData => {
            console.log(`SignalR dataChanged`, messageData);
            this.onDataChangedMessage.next(messageData);
        });
    }
}
