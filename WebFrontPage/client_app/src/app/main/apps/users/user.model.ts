import { RoleUserGrid } from "../role-users/roleuser.model";

export class UserGrid {
    id: string;
    email: string;
    userName: string;
    firstName: string;
    lastName: string;
}

export class User {
    id: string;
    userName: string;
    email: string;
    password: string;
    firstName: string;
    lastName: string;
    pictureUrl: string;
    userRoles: RoleUserGrid[];


    /**
     * Constructor
     *
     * @param user
     */
    constructor(user?) {
        user = user || {};
        this.id = user.id;
        this.userName = user.userName;
        this.email = user.email;
        this.password = user.password;
        this.firstName = user.firstName;
        this.lastName = user.lastName;
        this.pictureUrl = user.pictureUrl;
        this.userRoles = user.userRoles || [];
    }
}



export class UserNewDialogResult {
    goTo: 'Edit';
    data: User;
}


