import { MatChipInputEvent } from '@angular/material';

import { FuseUtils } from '@fuse/utils';

export class CustomerGrid {
    id: number;
    erpId: string;
    name: string;
}


export class Customer {
    id: string;
    name: string;
    freightout: Freightout

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



export class Freightout {
   
    id: number;
    customerId: number;
    rateType: string;
    cost: number;
    wProtect: number;
    secondLeg: number;
    surchargeHourly: number;
    surchargeYearly: number;
    dateBegin: Date;
    dateEnd: Date;


    constructor(freightout?) {
        freightout = freightout || {};
        this.id = freightout.id;
        this.customerId = freightout.customerId;
        this.cost = freightout.cost;
        this.wProtect = freightout.wProtect;
        this.dateBegin = freightout.dateBegin;
        this.dateEnd = freightout.dateEnd;
    }
}