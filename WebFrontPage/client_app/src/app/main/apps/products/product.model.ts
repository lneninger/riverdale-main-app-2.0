
export class ProductGrid {
    id: number;
    erpId: string;
    name: string;
}

export class Product {
    id: number;
    name: string;
    pictures: ProductPictureGrid[]

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

export class ProductPictureGrid {

    constructor(item?) {
        let internal = item || <ProductPictureGrid>{};

    }
}

