
export class ProductCategoryGrid {
    id: string;
    name: string;
}

//export class ProductCategorySizeGrid {
//    id: number;
//    name: string;

//    constructor(item) {
//        const internal = <ProductCategorySizeGrid>item;
//        this.id = internal.id;
//        this.name = internal.name;
//    }
//}


export class ProductCategory
{
    id: number;
    identifier: string;
    name: string;
    allowedSizes: ProductCategoryAllowedSizeGrid[];
    allowedColors: ProductCategoryAllowedColorTypeGrid[];

    /**
     * Constructor
     *
     * @param input Input parameter
     */
    constructor(input?)
    {
        const internal = (<ProductCategory>(input || {}));
        this.identifier = internal.identifier;
        this.id = internal.id;
        this.name = internal.name;
        this.allowedSizes = (internal.allowedSizes || []).map(subItem => new ProductCategoryAllowedSizeGrid(subItem));;
        this.allowedColors = (internal.allowedColors || []).map(subItem => new ProductCategoryAllowedColorTypeGrid(subItem));;
    }
}

//export class ProductCategorySize {
//    id: string;
//    name: string;

//    /**
//     * Constructor
//     *
//     * @param input Input parameter
//     */
//    constructor(input?) {
//        this.id = (input || {}).id;
//        this.name = (input || {}).name;
//    }
//}



export class ProductCategoryNewDialogResult {
    goTo: 'Edit';
    data: ProductCategory;
}

export class ProductCategoryAllowedColorTypeGrid {
    id?: number;
    productCategoryId?: number;
    productColorTypeId?: string;

    constructor(item?) {
        let internal = item || <ProductCategoryAllowedColorTypeGrid>{};
        this.id = internal.id;
        this.productCategoryId = internal.productCategoryId;
        this.productColorTypeId = internal.productColorTypeId;
    }
}

export class ProductCategoryAllowedSizeGrid {
    id?: number;
    productCategoryId?: number;
    size?: string;

    constructor(item?) {
        let internal = item || <ProductCategoryAllowedSizeGrid>{};
        this.id = internal.id;
        this.productCategoryId = internal.productCategoryId;
        this.size = internal.size;
    }
}




