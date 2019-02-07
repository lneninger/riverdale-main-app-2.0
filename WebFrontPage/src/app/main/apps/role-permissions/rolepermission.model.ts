

export class RolePermissionGrid {
    id?: number;
    roleId?: number
    permissionId?: string;

    constructor(gridModel?: RolePermissionGrid) {
        let internal = gridModel || <RolePermissionGrid>{};
        this.id = internal.id;
        this.roleId = internal.roleId;
        this.permissionId = internal.permissionId;
    }
}

