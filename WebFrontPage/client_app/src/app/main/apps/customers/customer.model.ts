import { MatChipInputEvent } from '@angular/material';

import { FuseUtils } from '@fuse/utils';

export class CustomerGrid {
    id: number;
    erpId: string;
    name: string;
}


export class Customer
{
    id: string;
    name: string;
    erpId: string;

    /**
     * Constructor
     *
     * @param customer
     */
    constructor(customer?)
    {
        customer = customer || {};
        this.id = customer.id;
        this.name = customer.name;
        this.erpId = customer.erpId;
    }
}
