import { ThirdPartyGrid } from "../userRolethirdpartyappsetting/userRolethirdpartyappsetting.model";
import { UserRoleFreightout } from "../userRolefreightout/userRolefreightout.core.module";

export class UserRoleGrid {
    id: number;
    erpId: string;
    name: string;
}

export class UserRole {
    id: number;
    name: string;
    freightout: UserRoleFreightout
    thirdPartySettings: ThirdPartyGrid[]

    /**
     * Constructor
     *
     * @param userRole
     */
    constructor(userRole?) {
        userRole = userRole || {};
        this.id = userRole.id;
        this.name = userRole.name;
    }
}


