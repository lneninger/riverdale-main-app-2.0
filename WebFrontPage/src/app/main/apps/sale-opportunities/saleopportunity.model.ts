import { IUploadedFile } from '../@hipalanetCommons/fileupload/fileupload.model';
import { EnumItem } from '../@resolveServices/resolve.model';

export class SaleOpportunityGrid {
    id: number;
    erpId: string;
    name: string;
}

export class SaleOpportunity {
    id: number;
    name: string;
    customerId: number;
    customerName: string;
    seasonName: string;
    targetPrice: number;
    sampleBoxes: SampleBoxItem[];
    settings: SaleOpportunitySettings;

    /**
     * Constructor
     *
     * @param product Product
     */
    constructor(product?) {
        const internal = product || {};
        this.id = internal.id;
        this.name = internal.name;
        this.seasonName = internal.seasonName;
        this.customerName = internal.customerName;
        this.customerId = internal.customerId;
        this.targetPrice = internal.targetPrice;
        this.sampleBoxes = (internal.sampleBoxes || []).map(item => new SampleBoxItem(item));
        this.settings = new SaleOpportunitySettings(internal.settings || {});
    }
}

export class SampleBoxItem{
    id: number;
    name: string;
    order: number;
    saleOpportunityId: number;
    parentSampleBoxId: number;
    relatedProducts: SampleBoxProductItem[];

    constructor(sampleBox?){
        const internal = sampleBox || {};
        this.id = internal.id;
        this.name = internal.name;
        this.order = internal.order;
        this.saleOpportunityId = internal.saleOpportunityId;
        this.parentSampleBoxId = internal.parentSampleBoxId;
        this.relatedProducts = (internal.relatedProducts || []).map(item => new SampleBoxProductItem(item));

    }

}

export class SampleBoxGrid {
    id?: number;
    order?: number;

    constructor(item?) {
        const internal = item || <SampleBoxGrid>{};
        this.id = internal.id;
        this.order = internal.order;
    }
}

export class ProductGrid {
    id?: number;
    fileId?: number;
    productName?: string;
    productTypeName?: string;
    productAmount: number;

    constructor(item?) {
        const internal = item || <ProductGrid>{};
        this.id = internal.id;
        this.fileId = internal.fileId;
        this.productName = internal.productName;
        this.productTypeName = internal.productTypeName;
        this.productAmount = internal.productAmount;
    }
}

export class SaleOpportunityNewDialogResult {
    goTo: 'Edit';
    data: SaleOpportunity;
}



export class SampleBoxProductItem {
    id: number;
    sampleBoxId: number;
    productId: number;
    productName: string;
    productTypeId: string;
    productTypeName: string;
    productTypeDescription: string;
    productPictureId: number;
    sampleBoxProductSubItems: SampleBoxProductSubItem[];

    constructor(item?) {
        const internal = item || {};
        if (internal.key) {
            this.productId = internal.key;
        }
        else {
            this.id = internal.id;
            this.sampleBoxId = internal.sampleBoxId;
            this.productId = internal.productId;
            this.productName = internal.productName;
            this.productTypeId = internal.productTypeId;
            this.productTypeName = internal.productTypeName;
            this.productTypeDescription = internal.productTypeDescription;
            this.productPictureId = internal.productPictureId;
            this.sampleBoxProductSubItems = (internal.sampleBoxProductSubItems || []).map(subItem => new SampleBoxProductSubItem(subItem));
        }
    }
}

export class SampleBoxProductSubItem {
    id: number;
    sampleBoxId: number;
    productId: number;
    productName: string;
    productTypeId: string;
    productTypeName: string;
    productTypeDescription: string;
    productPictureId: number;
    productAmount: number;
    productColorTypeId?: string;

    constructor(item?) {
        const internal = item || {};
        if (internal.key) {
            this.productId = internal.key;
            this.productAmount = 1;
        }
        else {
            this.id = internal.id;
            this.sampleBoxId = internal.sampleBoxId;
            this.productId = internal.productId;
            this.productName = internal.productName;
            this.productTypeId = internal.productTypeId;
            this.productTypeName = internal.productTypeName;
            this.productTypeDescription = internal.productTypeDescription;
            this.productPictureId = internal.productPictureId;
            this.productAmount = internal.productAmount;
            this.productColorTypeId = internal.productColorTypeId;
        }
    }
}

export class SaleOpportunitySettings {
    id?: number;
    delivered: boolean;
    riverdaleMargin: number;
    foc: number;
    growerId: number;
    funzaQuote: string;

    constructor(settings) {

        const internal = settings || {};
        this.id = internal.id;
        this.delivered = internal.delivered;
        this.riverdaleMargin = internal.riverdaleMargin;
        this.foc = internal.foc;
        this.growerId = internal.growerId;
    }
}


export class SampleBoxItemNewDialogResult{
    goTo: 'Edit';
    data: SampleBoxItem;
}


