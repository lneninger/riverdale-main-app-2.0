
export class ProductCategoryGrid {
    id: string;
    name: string;
}

export class ProductCategoryGradeGrid {
    id: number;
    name: string;

    constructor(item) {
        const internal = <ProductCategoryGradeGrid>item;
        this.id = internal.id;
        this.name = internal.name;
    }
}


export class ProductCategory
{
    id: string;
    name: string;
    grades: ProductCategoryGradeGrid[];
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
        this.grades = ((input || {}).grades || []).map(subItem => new ProductCategoryGrade(subItem));;
        this.allowedColors = ((input || {}).allowedColors || []).map(subItem => new ProductCategoryAllowedColorTypeGrid(subItem));;
    }
}

export class ProductCategoryGrade {
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
    productCategoryColorTypeId?: string;

    constructor(item?) {
        let internal = item || <ProductCategoryAllowedColorTypeGrid>{};
        this.id = internal.id;
        this.productCategoryId = internal.productCategoryId;
        this.productCategoryColorTypeId = internal.productColorTypeId;
    }
}




