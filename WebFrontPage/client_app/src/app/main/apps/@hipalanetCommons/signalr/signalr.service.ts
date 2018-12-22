import { Injectable, EventEmitter } from '@angular/core';
import { SignalR, ISignalRConnection, BroadcastEventListener } from 'ng2-signalr';
//import { AuthenticationTrackerService, IUserProfileResponse } from '../../_commons/authentication/authenticationtracker.service';
//import { AuthenticationTrackerService, IUserProfileResponse } from '../../_commons/authentication/authenticationtracker.service';
//import { UserActiveService } from './useractive.service';
import { IConnectionOptions } from 'ng2-signalr/src/services/connection/connection.options';

//import { AngularFireAuth } from '@angular/fire/auth';
import { AuthenticationService } from '../authentication/authentication.service';
import { UserInfo } from 'firebase';
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
        //, private authenticationTrackerService: AuthenticationTrackerService
        , private authenticationService: AuthenticationService
        //, private auth: AngularFireAuth
    ) {
        this.setAuthentication();

        this.onConnect = new EventEmitter<ISignalRConnection>();
        this.onActiveUsers = new EventEmitter<ISignalRConnection>();

        //this.authenticationTrackerService.authEvent.subscribe((profileResponse: IUserProfileResponse) => {
        //    let profile = profileResponse;
        //    this.profileChanged(profile);
        //});

        this.authenticationService.onChangedUserInfo.subscribe((user: AuthenticationInfo) => {
            this.profileChanged(user);
        });

        //this.auth.auth.onAuthStateChanged(user => {
        //    this.profileChanged(user);
        //});

        //this.profileChanged(this.authenticationTrackerService.authData);
    }

    profileChanged(profile: AuthenticationInfo) {
        //debugger;
        if (profile/* && this.authenticationTrackerService.isAuthenticated()*/) {
            this.updateAuthorization(profile.accessToken/*profile.accessToken*/);
            if (!this.connection) {
                this.createConnection(profile.accessToken/*profile.accessToken*/);
            }
        }
    }

    //profileChanged(profile) {
    //    //debugger;
    //    if (profile/* && this.authenticationTrackerService.isAuthenticated()*/) {
    //        this.updateAuthorization(profile.uid/*profile.accessToken*/);
    //        if (!this.connection) {
    //            this.createConnection(profile.uid/*profile.accessToken*/);
    //        }
    //    }
    //}

    private setAuthentication() {
        // Set auth headers.
        let $ = (<any>window).$;
        $.signalR.ajaxDefaults.headers = {
            'Content-Type': "application/json",
            "Authorization": ''
        };
    }

    private updateAuthorization(accessToken) {
        // debugger;
        /*
        $.signalR.ajaxDefaults.headers['Authorization'] = 'Bearer ' + accessToken;
        $.connection.hub.qs = { 'access_token': accessToken };
        */
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
            this.onDataChangedMessage.next(messageData);
        });
    }
}
