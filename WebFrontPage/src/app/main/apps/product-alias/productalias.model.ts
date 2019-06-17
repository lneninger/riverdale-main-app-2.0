import { IUploadedFile } from '../@hipalanetCommons/fileupload/fileupload.model';
import { EnumItem } from '../@resolveServices/resolve.model';
import { Observable } from 'rxjs';
import { constants } from 'perf_hooks';

export class ProductAliasGrid {
    id: number;
    name: string;

    productId: number;
    productName: string;

    productCategorySizeId: number;
    productCategorySize: string;

    colorTypeId: number;
    colorType: string;

    createdAt: Date;

}

export class ProductAlias {
    id: number;
    name: string;
    productTypeId: string;
    productCategoryId: number;

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
    }
}

export class ProductAliasAllowedColorTypeGrid {
    id?: number;
    productId?: number;
    productColorTypeId?: string;

    constructor(item?) {
        const internal = item || <ProductAliasAllowedColorTypeGrid>{};
        this.id = internal.id;
        this.productId = internal.productId;
        this.productColorTypeId = internal.productColorTypeId;
    }
}

export interface IProductMedia extends IUploadedFile {
    productId: number;
   
}


export class ProductAliasNewDialogInput {
    listProductType$: Observable<EnumItem<number>>;
    listProductCategory$: Observable<EnumItem<number>>;
}

export class ProductAliasNewDialogResult {
    goTo: 'Edit';
    data: ProductAlias;
}

