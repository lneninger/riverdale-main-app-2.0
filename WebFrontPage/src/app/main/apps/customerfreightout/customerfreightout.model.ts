

export class CustomerFreightout {
    id?: number;
    customerId?: number;
    customerFreightoutRateTypeId: string;
    cost?: number
    secondLeg?: string;
    thirdPartyCustomerId?: string;
    surchargeHourly?: number;
    surchargeYearly?: number;
    wProtect?: number;
    dateFrom?: Date;
    dateTo?: Date;

    constructor(gridModel?: CustomerFreightout) {
        let internal = gridModel || <CustomerFreightout>{};
        this.id = internal.id;
        this.customerId = internal.customerId;
        this.customerFreightoutRateTypeId = internal.customerFreightoutRateTypeId;
        this.cost = internal.cost;
        this.secondLeg = internal.secondLeg;
        this.surchargeHourly = internal.surchargeHourly;
        this.surchargeYearly = internal.surchargeYearly;
        this.wProtect = internal.wProtect;
        this.dateFrom = internal.dateFrom;
        this.dateTo = internal.dateTo;
    }
}




//export class Freightout {

//    id: number;
//    customerId: number;
//    rateType: string;
//    cost: number;
//    wProtect: number;
//    secondLeg: number;
//    surchargeHourly: number;
//    surchargeYearly: number;
//    dateBegin: Date;
//    dateEnd: Date;


//    constructor(freightout?) {
//        freightout = freightout || {};
//        this.id = freightout.id;
//        this.customerId = freightout.customerId;
//        this.cost = freightout.cost;
//        this.wProtect = freightout.wProtect;
//        this.dateBegin = freightout.dateBegin;
//        this.dateEnd = freightout.dateEnd;
//    }
//}

