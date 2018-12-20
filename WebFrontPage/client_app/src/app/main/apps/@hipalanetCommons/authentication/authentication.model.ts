




export class Register {

    email: string;

    userName: string;

    firstName: string;

    lastName: string;

    password: string;

    confirmPassword: string;

    pictureUrl: string;

    constructor(register?: any) {
        let internal = register || {};
        this.email = internal.email;

        this.firstName = internal.firstName;

        this.lastName = internal.lastName;

        this.userName = internal.userName;

        this.password = internal.password;

        this.confirmPassword = internal.confirmPassword;

        this.pictureUrl = internal.pictureUrl;
    }
}


export class Authenticate {

    userName: string;

    password: string;

    constructor(authentication?: any) {
        let internal = authentication || {};
        this.userName = authentication.userName;
        this.password = authentication.password;
    }
}

export class AuthenticationInfo {
    userName: string;
    firstName: string;
    lastName: string;
    accessToken: string;
    pictureUrl: string;
    expiresAt: Date;
    permissions: string[]
    roles: string[]
}


export interface INavigationAccessRights {
    permissions?: string[];
    roles?: string[];
    accessExtraFilter?: (AuthenticationInfo) => boolean;
}

export interface INavigationItem extends INavigationAccessRights {

}