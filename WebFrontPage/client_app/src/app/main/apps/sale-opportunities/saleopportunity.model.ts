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
    productTypeId: string;
    productColorTypeId: string;
    relatedProducts: ProductGrid[]

    /**
     * Constructor
     *
     * @param product
     */
    constructor(product?) {
        let internal = product || {};
        this.id = internal.id;
        this.name = internal.name;
        this.productTypeId = internal.productTypeId
        this.productColorTypeId = internal.productColorTypeId;
        this.relatedProducts = (internal.relatedProducts || []).map(item => new ProductGrid(item));
    }
}

export class ProductGrid {
    id?: number;
    fileId?: number;

    constructor(item?) {
        let internal = item || <ProductGrid>{};
        this.id = internal.id;
        this.fileId = internal.fileId;
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
            this.saleOpportunityId = internal.saleOpportunityId
            this.productId = internal.productId
            this.productName = internal.productName
            this.productTypeName = internal.productTypeName
            this.productTypeDescription = internal.productTypeDescription
            this.productPictureId = internal.productPictureId
            this.productAmount = internal.productAmount;
        }
    }
}