import { Resolve, RouterStateSnapshot, ActivatedRouteSnapshot } from '@angular/router';
import { SignalR, SignalRConnection, ISignalRConnection } from 'ng2-signalr';
import { Injectable } from '@angular/core';

@Injectable()
export class SignalRConnectionResolverService implements Resolve<ISignalRConnection> {

    constructor(private _signalR: SignalR) { }

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        console.log('ConnectionResolver. Resolving...');
        return this._signalR.connect();
    }
}