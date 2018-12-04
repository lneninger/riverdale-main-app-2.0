import { RolePermissionGrid } from "../role-permissions/rolepermission.core.module";
import { User } from "../users/user.core.module";

export class UserRoleGrid {
    id: number;
    erpId: string;
    name: string;
}

export class UserRole {
    id: number;
    name: string;
    rolePermissions: RolePermissionGrid[]

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


