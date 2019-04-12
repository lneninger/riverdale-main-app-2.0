import { Component, ViewEncapsulation } from '@angular/core';
import { MatSnackBar, MatDialog } from '@angular/material';

import { fuseAnimations } from '@fuse/animations';
import { AuthenticationService, AuthenticationInfo } from '../../../main/apps/@hipalanetCommons/authentication/authentication.core.module';
import { PromptPopupComponent, PromptPopupData, PromptPopupResult } from '../../apps/@hipalanetCommons/popups/prompt/prompt.popup.module';
import { UserService } from '../../../main/apps/users/user.service';
import { UserProfilePicture } from 'app/main/apps/users/user.model';

@Component({
    selector     : 'profile',
    templateUrl  : './profile.component.html',
    styleUrls    : ['./profile.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations   : fuseAnimations
})
export class ProfileComponent
{
    user: AuthenticationInfo;//firebase.User;

    get userPhoto() {
        if (this.user) {
            return this.user.pictureUrl;
            //return this.user.photoURL;
        }

        return null;
    }
    /**
     * Constructor
     */
    constructor(
        private authenticationService: AuthenticationService
        , private userService: UserService
        , private matDialog: MatDialog
        , private _matSnackBar: MatSnackBar
    )
    {
        this.user = this.authenticationService.userData;

        this.authenticationService.onChangedUserInfo.subscribe(user => {
            this.user = user;
        });
    }

    promptNewProfilePicture() {
        const dialogRef = this.matDialog.open(PromptPopupComponent, {
            width: '500px',
            data: <PromptPopupData>{ dialogDisplayName: 'Update Picture', promptText: 'New Profile Picture', defaultValue: this.userPhoto }
        });

        dialogRef.afterClosed().subscribe((result: PromptPopupResult) => {
            if (result.action === 'YES') {
                const payload = new UserProfilePicture(null, result.value);
                this.userService.updateUserProfilePicture(payload)
                    .then(() => {
                        this._matSnackBar.open('Profile picture updated', 'OK', {
                            verticalPosition: 'top',
                            duration: 2000
                        });
                    });
            }
        });
    }
}
