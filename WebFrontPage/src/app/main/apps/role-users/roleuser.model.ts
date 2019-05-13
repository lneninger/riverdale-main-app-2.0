

export class RoleUserGrid {
    id?: number;
    roleId?: number
    userId?: string;

    constructor(gridModel?: RoleUserGrid) {
        const internal = gridModel || <RoleUserGrid>{};
        this.id = internal.id;
        this.roleId = internal.roleId;
        this.userId = internal.userId;
    }
}

