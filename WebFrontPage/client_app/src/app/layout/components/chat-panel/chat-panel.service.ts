import { Injectable, NgZone } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { FuseUtils } from '@fuse/utils';


/*Notifcation Module*/
import { NotificationModule, NotificationGroupService, IFocusNotificationOptions, NotificationGroupClient, OnChannelNotificationEventArgs } from 'hipalanet-notificationsjs';
import { AuthenticationService, AuthenticationInfo } from '../../../main/apps/@hipalanetCommons/authentication/authentication.core.module';

/*************************Custom***********************************/
//import { AngularFireAuth } from '@angular/fire/auth';

@Injectable()
export class ChatPanelService {
    // Notification Package Declarations
    private _chatGroup: NotificationGroupService;
    get chatGroup() {
        return this._chatGroup;
    }

    _selectedContact: NotificationGroupClient;

    get selectedContact() {
        return this._selectedContact;
    }

    set selectedContact(value: NotificationGroupClient) {
        this._selectedContact = value;
        if (value == null) return;

        let channelService = this.chatGroup.getNotificationChannelByClient(value);
        if (channelService.length > 0) {
            channelService[0].markMessagesAsRead();
        }
    }

    chatInitialized: boolean;

    contacts: any[];
    chats: any[];
    user: any;

    /*Notifcation Module*/
    notifcationModule: NotificationModule;

    /**
     * Constructor
     *
     * @param {HttpClient} _httpClient
     */
    constructor(
        private auth: AuthenticationService
        //private auth: AngularFireAuth
        , private _httpClient: HttpClient
        , private ngZone: NgZone
    ) {

        /*Notifcation Module*/

        this.auth.onChangedUserInfo.subscribe((user: AuthenticationInfo) => {
            this.user = user;
            if (this.user) {
                let option: IFocusNotificationOptions = {
                    clientInfo: { clientId: user.email, pictureUrl: user.pictureUrl }
                };

                //debugger;
                this.notifcationModule = new NotificationModule('intance0', '-LPwbRsfymRP688W6ony', option);
                this.notifcationModule.onInitialized.subscribe(res => {
                    console.log(`ChatPanelService: Notification Module Initialized!! Chat Groups  Amount: ${this.notifcationModule.notificationGroups.length}`);
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
        });


        //this.auth.auth.onAuthStateChanged(user => {
        //    this.user = user;
        //    if (this.user) {
        //        let option: IFocusNotificationOptions = {
        //            clientInfo: { clientId: user.email, pictureUrl: user.photoURL }
        //        };

        //        //debugger;
        //        this.notifcationModule = new NotificationModule('intance0', '-LPwbRsfymRP688W6ony', option);
        //        this.notifcationModule.onInitialized.subscribe(res => {
        //            console.log(`ChatPanelService: Notification Module Initialized!! Chat Groups  Amount: ${this.notifcationModule.notificationGroups.length}`);
        //            this.chatInitialized = true;
        //            this._chatGroup = this.notifcationModule.notificationGroups[0];
        //            this._chatGroup.onClientConnected.subscribe(client => {
        //                this.ngZone.run(() => { });
        //            });

        //            this._chatGroup.onChannelNotification.subscribe((args: OnChannelNotificationEventArgs) => {
        //                if (args.direction == 'received') {
        //                    if (!this.selectedContact || this.selectedContact.clientIdentifier != args.notificationChannelService.client.clientIdentifier) {
        //                        args.notificationChannelService.client.unreadMessages += (!args.channelNotification.read);
        //                    }
        //                    else {
        //                        args.notificationChannelService.setMessageAsRead(args.channelNotification.key);
        //                    }
        //                }

        //                this.ngZone.run(() => { });
        //            });
        //        });
        //    }
        //});


    }

    /**
     * Loader
     *
     * @returns {Promise<any> | any}
     */
    loadContacts(): Promise<any> | any {
        return new Promise((resolve, reject) => {
            Promise.all([
                this.getContacts(),
                this.getUser()
            ]).then(
                ([contacts, user]) => {
                    this.contacts = contacts;
                    this.user = user;
                    // debugger;
                    resolve();
                },
                reject
            );
        });
    }

    /**
     * Get chat
     *
     * @param contactId
     * @returns {Promise<any>}
     */
    getChat(contactId): Promise<any> {
        const chatItem = this.user.chatList.find((item) => {
            return item.contactId === contactId;
        });

        // Get the chat
        return new Promise((resolve, reject) => {

            // If there is a chat with this user, return that.
            if (chatItem) {
                this._httpClient.get('api/chat-panel-chats/' + chatItem.chatId)
                    .subscribe((chat) => {

                        // Resolve the promise
                        resolve(chat);

                    }, reject);
            }
            // If there is no chat with this user, create one...
            else {
                this.createNewChat(contactId).then(() => {

                    // and then recall the getChat method
                    this.getChat(contactId).then((chat) => {
                        resolve(chat);
                    });
                });
            }
        });
    }

    /**
     * Create new chat
     *
     * @param contactId
     * @returns {Promise<any>}
     */
    createNewChat(contactId): Promise<any> {
        return new Promise((resolve, reject) => {

            // Generate a new id
            const chatId = FuseUtils.generateGUID();

            // Prepare the chat object
            const chat = {
                id: chatId,
                dialog: []
            };

            // Prepare the chat list entry
            const chatListItem = {
                chatId: chatId,
                contactId: contactId,
                lastMessageTime: '2017-02-18T10:30:18.931Z'
            };

            // Add new chat list item to the user's chat list
            this.user.chatList.push(chatListItem);

            // Post the created chat to the server
            this._httpClient.post('api/chat-panel-chats', { ...chat })
                .subscribe(() => {

                    // Post the updated user data to the server
                    this._httpClient.post('api/chat-panel-user/' + this.user.id, this.user)
                        .subscribe(() => {

                            // Resolve the promise
                            resolve();
                        });
                }, reject);
        });
    }

    /**
     * Update the chat
     *
     * @param chatId
     * @param dialog
     * @returns {Promise<any>}
     */
    updateChat(chatId, dialog): Promise<any> {
        return new Promise((resolve, reject) => {

            const newData = {
                id: chatId,
                dialog: dialog
            };

            this._httpClient.post('api/chat-panel-chats/' + chatId, newData)
                .subscribe(updatedChat => {
                    resolve(updatedChat);
                }, reject);
        });
    }

    /**
     * Get contacts
     *
     * @returns {Promise<any>}
     */
    getContacts(): Promise<any> {
        return new Promise((resolve, reject) => {
            this._httpClient.get('api/chat-panel-contacts')
                .subscribe((response: any) => {
                    resolve(response);
                }, reject);
        });
    }

    /**
     * Get user
     *
     * @returns {Promise<any>}
     */
    getUser(): Promise<any> {
        return new Promise((resolve, reject) => {
            this._httpClient.get('api/chat-panel-user')
                .subscribe((response: any) => {
                    resolve(response[0]);
                }, reject);
        });
    }
}
