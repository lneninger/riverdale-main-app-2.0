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
    products: ProductGrid[]

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
        this.products = (internal.products || []).map(item => new ProductGrid(item));
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



export class CompositionItem {
    id: number;
    productId: number;
    relatedProductId: number;
    relatedProductName: string;
    relatedProductTypeName: string;
    relatedProductTypeDescription: string;
    relatedProductPictureId: number;
    stems: number;

    constructor(item?) {
        let internal = item || {};
        if (internal.key) {
            this.relatedProductId = internal.key;
            this.stems = 1;
        }
        else {
            this.id = internal.id;
            this.productId = internal.productId
            this.relatedProductId = internal.relatedProductId
            this.relatedProductName = internal.relatedProductName
            this.relatedProductTypeName = internal.relatedProductTypeName
            this.relatedProductTypeDescription = internal.relatedProductTypeDescription
            this.relatedProductPictureId = internal.relatedProductPictureId
            this.stems = internal.stems;
        }
    }
}