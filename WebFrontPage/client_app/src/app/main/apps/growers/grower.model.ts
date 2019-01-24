import { ThirdPartyGrid } from "../growerthirdpartyappsetting/growerthirdpartyappsetting.model";
import { GrowerFreightout } from "../growerfreightout/growerfreightout.core.module";

export class GrowerGrid {
    id: number;
    erpId: string;
    name: string;
}

export class Grower {
    id: number;
    name: string;
    freightout: GrowerFreightout
    thirdPartySettings: ThirdPartyGrid[]

    /**
     * Constructor
     *
     * @param grower
     */
    constructor(grower?) {
        grower = grower || {};
        this.id = grower.id;
        this.name = grower.name;
    }
}


export class GrowerNewDialogResult {
    goTo: 'Edit';
    data: Grower;
}