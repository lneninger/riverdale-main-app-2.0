import { IUploadedFile } from "../@hipalanetCommons/fileupload/fileupload.model";
import { EnumItem } from "../@resolveServices/resolve.model";

export class ProductGrid {
    id: number;
    erpId: string;
    name: string;
}

export class Product {
    id: number;
    name: string;
    productTypeId: string;
    productColorTypeId: string;
    medias: ProductMediaGrid[];
    productAllowedColorTypes: ProductAllowedColorTypeGrid[];

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
        this.medias = (internal.medias || []).map(item => new ProductMediaGrid(item));
        //debugger;
        this.productAllowedColorTypes = (internal.productAllowedColorTypes || []).map(item => new ProductAllowedColorTypeGrid(item));
    }
}

export class CompositionProduct extends Product{
    relatedProducts: CompositionItem[];

    constructor(product?) {
        super(product);
        let internal = product || {};
        this.relatedProducts = (internal.relatedProducts || []).map(item => new CompositionItem(item));
    }
}

export class ProductMediaGrid {
    id?: number;
    fileId?: number;

    constructor(item?) {
        let internal = item || <ProductMediaGrid>{};
        this.id = internal.id;
        this.fileId = internal.fileId;
    }
}

export class ProductAllowedColorTypeGrid {
    id?: number;
    productId?: number;
    productColorTypeId?: string;

    constructor(item?) {
        let internal = item || <ProductAllowedColorTypeGrid>{};
        this.id = internal.id;
        this.productId = internal.productId;
        this.productColorTypeId = internal.productColorTypeId;
    }
}

export interface IProductMedia extends IUploadedFile {
    productId: number;
   
}


export class ProductNewDialogResult {
    goTo: 'Edit';
    data: Product;
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