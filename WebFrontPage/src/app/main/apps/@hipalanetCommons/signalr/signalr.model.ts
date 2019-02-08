import { HubConnection } from "@aspnet/signalr";

export class HubItem {
    hubName: string;
    rawConnection: HubConnection;
}

export class HubConnectionOptions {

}

export interface ISignalREventArgs {

    eventName: string;
    action: string;
    entityName?: string;
    entity?: any;
}
