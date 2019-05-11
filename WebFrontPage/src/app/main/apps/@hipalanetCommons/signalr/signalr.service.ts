import { Injectable, EventEmitter } from '@angular/core';
import { BaseSignalRService } from './basesignalr.service';
import { Subject } from 'rxjs';
import { ISignalREventArgs } from './signalr.model';

declare var $: any;

@Injectable()
export class SignalRService extends BaseSignalRService {
    onDataChanged: Subject<ISignalREventArgs> = new Subject<
        ISignalREventArgs
    >();
    onCustomerDataChanged: Subject<ISignalREventArgs> = new Subject<
        ISignalREventArgs
    >();
    onProductDataChanged: Subject<ISignalREventArgs> = new Subject<
        ISignalREventArgs
    >();
    onProductColorDataChanged: Subject<ISignalREventArgs> = new Subject<
        ISignalREventArgs
    >();

    onProductMediaDataChanged: Subject<ISignalREventArgs> = new Subject<
        ISignalREventArgs
    >();

    onProductAllowedColorDataChanged: Subject<ISignalREventArgs> = new Subject<
        ISignalREventArgs
    >();

    onActiveUsers: Subject<any> = new Subject<any>();

    constructor() {
        super();
        const promise = this.connect('globalhub');

        promise.then(hubItem => {
            this.addListener(
                'globalhub',
                'dataChanged',
                (data: ISignalREventArgs) => {
                    // debugger;
                    console.log(`event from Server: `, data);
                    this.onDataChanged.next(data);
                    this.processDataChanged(data);
                }
            );

            this.addListener('globalhub', 'activeUsers', (data: any) => {
                // debugger;
                console.log(`event from Server: `, data);
                this.onActiveUsers.next(data);
            });
        });
    }

    processDataChanged(eventData: ISignalREventArgs): void {
        debugger;
        switch (eventData.entityName) {
            case 'Customer':
                // debugger;
                this.onCustomerDataChanged.next(eventData);
                break;
            case 'Product':
             debugger;
             this.onProductDataChanged.next(eventData);
             break;
            case 'ProductMedia':
             // debugger;
             this.onProductMediaDataChanged.next(eventData);
             break;
            case 'ProductAllowedColorType':
                // debugger;
                this.onProductAllowedColorDataChanged.next(eventData);
                break;

            case 'ProductColorType':
                // debugger;
                this.onProductColorDataChanged.next(eventData);
                break;
        }
    }
}
