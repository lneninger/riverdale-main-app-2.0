import { Injectable } from '@angular/core';
import { Router, ActivationEnd, ChildActivationEnd, NavigationEnd } from '@angular/router';
//import { SecuredClientHttp } from '../authentication/securedclienthttp.service';
import { SecuredClientHttp, AuthenticationTrackerService } from '../authentication/authentication.core.module';
import { Constants } from '../../shared/smartadmin.config';
import { SignalRService } from './signalr.service';
import { Subscription } from 'rxjs';


@Injectable()
export class UserActiveService {
    
    interval: any;
    _appActive: number = 0;
    routes: { url: string, date: Date }[] = [];
    onActiveUsers: Subscription;
    activeUsers: any[];

    constructor(
        private http: SecuredClientHttp
        , private router: Router
        , private signalRService: SignalRService
        , private authenticationTrackerService: AuthenticationTrackerService
    ) {
        this.setInterval();

        this.router.events.subscribe(event => {
            //debugger;
            if (event instanceof NavigationEnd) {
                //debugger;
                let path = window.location.href.replace(window.location.origin, '');
                this.appActiveSignal(path);
            }
        });

        this.onActiveUsers = this.signalRService.onActiveUsers.subscribe(activeUsers => {
            //debugger;
            this.activeUsers = activeUsers;
            //let keys = Object.getOwnPropertyNames(activeUsers);
            //for (let i = 0; i < keys.length; i++) {
            //    this.activeUsers.push({ userId: keys[i], data: { date: activeUsers[keys[i]] }})
            //}
        });
    }

    appActiveSignal(url: string) {
        if (url.indexOf('/authentication.callback') != -1) return;
        this.routes.push({ url: url, date: new Date() });
        this._appActive = (this._appActive >= 100) ? 100 : this._appActive+1;
    }

    private cleanAppActive() {
        this._appActive = 0;
    }

    setInterval() {
        this.interval = setInterval(() => {
            if (this.authenticationTrackerService.isAuthenticated() && this._appActive > 0) {
                // debugger;
                this._appActive = 0;
                this.sendActiveApp();
                this.routes = [];
            }
        }, 5000);
    }

    private sendActiveAppNavigatorCallBack(position?: any) {
        let endpoint = `${Constants.baseApiUrl}security/activeUser`;
        this.http.post(endpoint, { position: position, routes: this.routes }).subscribe();
    }

    private sendActiveApp(): any {
        // Browser
        //if (navigator.geolocation) {
        //    navigator.geolocation.getCurrentPosition(this.sendActiveAppNavigatorCallBack.bind(this));
        //}
        //else {
            this.sendActiveAppNavigatorCallBack(null);
        //}
    }

}

