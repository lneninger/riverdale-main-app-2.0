import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { FuseSidebarService } from '@fuse/components/sidebar/sidebar.service';

@Component({
    selector   : 'notification-group-settings',
    templateUrl: './settings.component.html',
    styleUrls: ['./settings.component.scss']
})
export class SettingsComponent implements OnInit
{
    /**
     * Constructor
     *
     * @param {FuseSidebarService} _fuseSidebarService
     */
    constructor(
        private _fuseSidebarService: FuseSidebarService
        , private route: ActivatedRoute
        , private router: Router
    )
    {
        
    }


    currentEntity: any;
    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * Toggle sidebar
     *
     * @param name
     */
    toggleSidebar(name): void
    {
        this._fuseSidebarService.getSidebar(name).toggleOpen();
    }


    /*Insterfaces implementations*/
    ngOnInit() {
        //debugger;
        this.currentEntity = this.route.snapshot.data['data'];
        if (this.currentEntity == null) {
            this.router.navigate(['apps/notification-groups']);
        }
        else {
            //debugger;
            this.setCode();
        }
    }

    _code: string;
    get code() {
        return this._code;
    }

    setCode() {
        this._code = `
constructor(
        private auth: AngularFireAuth
        , private _httpClient: HttpClient
        , private ngZone: NgZone
    ) {
    // Notification module instanciation. It accepts the NotificationAccountId, the NotificationGroupId and an options object.
    this.notifcationModule = new NotificationModule('${this.currentEntity.entity.accountId}', '${this.currentEntity.id}', options);
    this.notifcationModule.onInitialized.subscribe(res => {
        this.chatInitialized = true;
        this._chatGroup = this.notifcationModule.notificationGroups[0];
        this._chatGroup.onClientConnected.subscribe(client => {
            this.ngZone.run(() => { });
        });

        this._chatGroup.onChannelNotification.subscribe((args: OnChannelNotificationEventArgs) => {
            if (args.direction == 'received') {
                if (!this.selectedContact || this.selectedContact.clientIdentifier != args.notificationChannelService.client.clientIdentifier) {
                    args.notificationChannelService.client.unreadMessages += (!args.channelNotification.read);
                }
                else {
                    args.notificationChannelService.setMessageAsRead(args.channelNotification.key);
                }
            }

            this.ngZone.run(() => { });
        });
    });
}
        `;
    }

}
