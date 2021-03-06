import { IUploadedFile } from '../@hipalanetCommons/fileupload/fileupload.model';
import { EnumItem } from '../@resolveServices/resolve.model';
import { Observable } from 'rxjs';
import { constants } from 'perf_hooks';

export class ProductGrid {
    id: number;
    flowerProductCategoryName: string;
    name: string;
}

export class Product {
    id: number;
    name: string;
    productTypeId: string;
    productCategoryId: number;
    medias: ProductMediaGrid[];
    productAllowedColorTypes: ProductAllowedColorTypeGrid[];

    /**
     * Constructor
     *
     * @param product input parameter
     */
    constructor(product?) {
        const internal = product || {};
        this.id = internal.id;
        this.name = internal.name;
        this.productTypeId = internal.productTypeId;
        this.productCategoryId = internal.productCategoryId;
        this.medias = (internal.medias || []).map(item => new ProductMediaGrid(item));
        // debugger;
        this.productAllowedColorTypes = (internal.productAllowedColorTypes || []).map(item => new ProductAllowedColorTypeGrid(item));
    }
}

export class CompositionProduct extends Product{
    relatedProducts: CompositionItem[];

    constructor(product?) {
        super(product);
        const internal = product || {};
        this.relatedProducts = (internal.relatedProducts || []).map(item => new CompositionItem(item));
    }
}

export class ProductMediaGrid {
    id?: number;
    fileId?: number;
    isDeleted: boolean;

    constructor(item?) {
        const internal = item || <ProductMediaGrid>{};
        this.id = internal.id;
        this.fileId = internal.fileId;
        this.isDeleted = internal.isDeleted;
    }
}

export class ProductAllowedColorTypeGrid {
    id?: number;
    productId?: number;
    productColorTypeId?: string;

    constructor(item?) {
        const internal = item || <ProductAllowedColorTypeGrid>{};
        this.id = internal.id;
        this.productId = internal.productId;
        this.productColorTypeId = internal.productColorTypeId;
    }
}

export interface IProductMedia extends IUploadedFile {
    productId: number;
   
}


export class ProductNewDialogInput {
    listProductType$: Observable<EnumItem<number>>;
    listProductCategory$: Observable<EnumItem<number>>;
}

export class ProductNewDialogResult {
    goTo: 'Edit';
    data: Product;
}



export class CompositionItem {
    id: number;
    colorTypeId: string;
    productId: number;
    relatedProductId: number;
    relatedProductTypeId: string;
    relatedProductName: string;
    relatedProductTypeName: string;
    relatedProductTypeDescription: string;
    relatedProductPictureId: number;
    relatedProductSizeId: number;
    relatedProductAmount: number;

    constructor(item?: any) {
        const internal = item || {};
        if (internal.key) {
            this.relatedProductId = internal.key;
            this.relatedProductAmount = 1;
        }
        else {
            this.id = internal.id;
            this.productId = internal.productId;
            this.relatedProductId = internal.relatedProductId;
            this.relatedProductName = internal.relatedProductName;
            this.relatedProductTypeId = internal.relatedProductTypeId;
            this.relatedProductTypeName = internal.relatedProductTypeName;
            this.relatedProductTypeDescription = internal.relatedProductTypeDescription;
            this.relatedProductPictureId = internal.relatedProductPictureId;
            this.relatedProductSizeId = internal.relatedProductSizeId;
            this.relatedProductAmount = internal.relatedProductAmount;
            this.colorTypeId = internal.colorTypeId;
        }
    }
}


export class CompositionItemNewDialogInput {
    listProductType: EnumItem<string>[];
    productRef: CompositionItem;
}

export class CompositionItemNewDialogResult {
    result: 'Saved' | 'Closed';
}
