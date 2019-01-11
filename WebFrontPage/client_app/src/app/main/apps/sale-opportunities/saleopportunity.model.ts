import { IUploadedFile } from "../@hipalanetCommons/fileupload/fileupload.model";
import { EnumItem } from "../@resolveServices/resolve.model";

export class SaleOpportunityGrid {
    id: number;
    erpId: string;
    name: string;
}

export class SaleOpportunity {
    id: number;
    name: string;
    customerName: string;
    seasonName: string;
    targetPrice: number;
    productTypeId: string;
    productColorTypeId: string;
    relatedProducts: SaleOpportunityItem[];
    settings: SaleOpportunitySettings;

    /**
     * Constructor
     *
     * @param product
     */
    constructor(product?) {
        let internal = product || {};
        this.id = internal.id;
        this.name = internal.name;
        this.seasonName = internal.seasonName;
        this.customerName = internal.customerName;
        this.targetPrice = internal.targetPrice;
        this.productTypeId = internal.productTypeId
        this.productColorTypeId = internal.productColorTypeId;
        this.relatedProducts = (internal.relatedProducts || []).map(item => new SaleOpportunityItem(item));
        this.settings = new SaleOpportunitySettings(internal.settings || {});
    }
}

export class ProductGrid {
    id?: number;
    fileId?: number;
    productName?: string;
    productTypeName?: string;
    productAmount: number;

    constructor(item?) {
        let internal = item || <ProductGrid>{};
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



export class SaleOpportunityItem {
    id: number;
    saleOpportunityId: number;
    productId: number;
    productName: string;
    productTypeId: string;
    productTypeName: string;
    productTypeDescription: string;
    productPictureId: number;
    productAmount: number;

    constructor(item?) {
        let internal = item || {};
        if (internal.key) {
            this.productId = internal.key;
            this.productAmount = 1;
        }
        else {
            this.id = internal.id;
            this.saleOpportunityId = internal.saleOpportunityId;
            this.productId = internal.productId;
            this.productName = internal.productName;
            this.productTypeId = internal.productTypeId;
            this.productTypeName = internal.productTypeName;
            this.productTypeDescription = internal.productTypeDescription;
            this.productPictureId = internal.productPictureId;
            this.productAmount = internal.productAmount;
        }
    }
}

export class SaleOpportunitySettings {
    id?: number;
    delivered: boolean;
    riverdaleMargin: number;
    foc: number;
    growerId: number;

    constructor(settings) {

        let internal = settings || {};
        this.id = internal.id;
        this.delivered = internal.delivered;
        this.riverdaleMargin = internal.riverdaleMargin;
        this.foc = internal.foc;
        this.growerId = internal.growerId;
    }
}