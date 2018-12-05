
export class UserGrid {
    id: number;
    email: string;
    userName: string;
    firstName: string;
    lastName: string;
}

export class User {
    id: number;
    userName: string;
    email: string;
    password: string;
    firstName: string;
    lastName: string;
    pictureUrl: string;


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
    }
}

