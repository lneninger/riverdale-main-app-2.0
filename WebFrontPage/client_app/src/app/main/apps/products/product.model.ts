import { IUploadedFile } from "../@hipalanetCommons/fileupload/fileupload.model";

export class ProductGrid {
    id: number;
    erpId: string;
    name: string;
}

export class Product {
    id: number;
    name: string;
    medias: ProductMediaGrid[]

    /**
     * Constructor
     *
     * @param product
     */
    constructor(product?) {
        product = product || {};
        this.id = product.id;
        this.name = product.name;
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

