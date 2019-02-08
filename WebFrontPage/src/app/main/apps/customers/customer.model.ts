import { ThirdPartyGrid } from "../customerthirdpartyappsetting/customerthirdpartyappsetting.model";
import { CustomerFreightout } from "../customerfreightout/customerfreightout.core.module";
import { CustomerThirdPartyAppSettingCoreModule, CustomerThirdPartyAppSettingService } from "../customerthirdpartyappsetting/customerthirdpartyappsetting.core.module";

export class CustomerGrid {
    id: number;
    erpId: string;
    name: string;
}

export class Customer {
    id: number;
    name: string;
    customerSettings: CustomerThirdPartyAppSettingCoreModule;
    freightout: CustomerFreightout;
    thirdPartySettings: ThirdPartyGrid[];

    /**
     * Constructor
     *
     * @param customer
     */
    constructor(customer?) {
        customer = customer || {};
        this.id = customer.id;
        this.name = customer.name;
        this.customerSettings = new CustomerSettings(customer.customerSettings);
    }
}

export class CustomerSettings{
    defaultDuty: boolean;
    defaultIsDeliver: boolean;
    defaultIsWet: boolean;
    defaultOther: boolean;
    defaultRebate: number;
    id: number;

    constructor(customerSettings?) {
        const internal = customerSettings || {};
        this.defaultDuty = internal.id;
        this.defaultIsDeliver = internal.defaultIsDeliver;
        this.defaultIsWet = internal.defaultIsWet;
        this.defaultOther = internal.defaultOther;
        this.defaultRebate = internal.defaultRebate;

    }

}

export class CustomerNewDialogResult {
    goTo: 'Edit';
    data: Customer;
}