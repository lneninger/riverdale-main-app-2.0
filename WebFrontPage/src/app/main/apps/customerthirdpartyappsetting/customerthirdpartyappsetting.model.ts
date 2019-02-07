

export class ThirdPartyGrid {
    id?: number;
    customerId?: number
    thirdPartyAppTypeId?: string;
    thirdPartyCustomerId?: string;

    constructor(gridModel?: ThirdPartyGrid) {
        let internal = gridModel || <ThirdPartyGrid>{};
        this.id = internal.id;
        this.customerId = internal.customerId;
        this.thirdPartyAppTypeId = internal.thirdPartyAppTypeId;
        this.thirdPartyCustomerId = internal.thirdPartyCustomerId;
    }
}

