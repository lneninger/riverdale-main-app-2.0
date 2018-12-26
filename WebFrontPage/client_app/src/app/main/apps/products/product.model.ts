import { IUploadedFile } from "../@hipalanetCommons/fileupload/fileupload.model";

export class ProductGrid {
    id: number;
    erpId: string;
    name: string;
}

export class Product {
    id: number;
    name: string;
    productTypeId: string;
    medias: ProductMediaGrid[]

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
        this.medias = (internal.medias || []).map(item => new ProductMediaGrid(item));
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

export interface IProductMedia extends IUploadedFile {
    productId: number;
   
}


export class ProductNewDialogResult {
    goTo: 'Edit';
    data: Product;
}