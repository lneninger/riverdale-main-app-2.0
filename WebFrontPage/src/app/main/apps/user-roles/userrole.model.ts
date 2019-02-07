import { RolePermissionGrid } from "../role-permissions/rolepermission.core.module";
import { User } from "../users/user.core.module";
import { RoleUserGrid } from "../role-users/roleuser.model";

export class UserRoleGrid {
    id: number;
    erpId: string;
    name: string;
}

export class UserRole {
    id: number;
    name: string;
    rolePermissions: RolePermissionGrid[];
    roleUsers: RoleUserGrid[];

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



export class UserRoleNewDialogResult {
    goTo: 'Edit';
    data: UserRole;
}


