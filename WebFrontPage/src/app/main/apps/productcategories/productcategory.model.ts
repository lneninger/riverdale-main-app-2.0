
export class ProductCategoryGrid {
    id: string;
    name: string;
}

export class ProductCategorySizeGrid {
    id: number;
    name: string;

    constructor(item) {
        const internal = <ProductCategorySizeGrid>item;
        this.id = internal.id;
        this.name = internal.name;
    }
}


export class ProductCategory
{
    id: string;
    name: string;
    sizes: ProductCategorySizeGrid[];
    allowedColors: ProductCategoryAllowedColorTypeGrid[];

    /**
     * Constructor
     *
     * @param input Input parameter
     */
    constructor(input?)
    {
        this.id = (input || {}).id;
        this.name = (input || {}).name;
        this.sizes = ((input || {}).sizes || []).map(subItem => new ProductCategorySize(subItem));;
        this.allowedColors = ((input || {}).allowedColors || []).map(subItem => new ProductCategoryAllowedColorTypeGrid(subItem));;
    }
}

export class ProductCategorySize {
    id: string;
    name: string;

    /**
     * Constructor
     *
     * @param input Input parameter
     */
    constructor(input?) {
        this.id = (input || {}).id;
        this.name = (input || {}).name;
    }
}



export class ProductCategoryNewDialogResult {
    goTo: 'Edit';
    data: ProductCategory;
}

export class ProductCategoryAllowedColorTypeGrid {
    id?: number;
    productCategoryId?: string;
    productColorTypeId?: string;

    constructor(item?) {
        let internal = item || <ProductCategoryAllowedColorTypeGrid>{};
        this.id = internal.id;
        this.productCategoryId = internal.productCategoryId;
        this.productColorTypeId = internal.productColorTypeId;
    }
}




