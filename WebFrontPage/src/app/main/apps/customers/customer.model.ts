import { ThirdPartyGrid } from "../customerthirdpartyappsetting/customerthirdpartyappsetting.model";
import { CustomerFreightout } from "../customerfreightout/customerfreightout.core.module";

export class CustomerGrid {
    id: number;
    erpId: string;
    name: string;
}

export class Customer {
    id: number;
    name: string;
    freightout: CustomerFreightout
    thirdPartySettings: ThirdPartyGrid[]

    /**
     * Constructor
     *
     * @param customer
     */
    constructor(customer?) {
        customer = customer || {};
        this.id = customer.id;
        this.name = customer.name;
    }
}


export class CustomerNewDialogResult {
    goTo: 'Edit';
    data: Customer;
}