import { IUploadedFile } from '../@hipalanetCommons/fileupload/fileupload.model';
import { EnumItem } from '../@resolveServices/resolve.model';

export class SaleOpportunityGrid {
    id: number;
    erpId: string;
    name: string;
}

export class SaleOpportunity {
    id: number;
    name: string;
    customerId: number;
    customerName: string;
    seasonName: string;
    targetPrices: TargetPriceItem[];
    sampleBoxes: SampleBoxItem[];
    settings: SaleOpportunitySettings;

    /**
     * Constructor
     *
     * @param product Product
     */
    constructor(product?) {
        const internal = product || {};
        this.id = internal.id;
        this.name = internal.name;
        this.seasonName = internal.seasonName;
        this.customerName = internal.customerName;
        this.customerId = internal.customerId;
        this.targetPrices = (internal.targetPrices || []).map(
            item => new TargetPriceItem(item)
        );
        this.sampleBoxes = (internal.sampleBoxes || []).map(
            item => new SampleBoxItem(item)
        );
        this.settings = new SaleOpportunitySettings(internal.settings || {});
    }
}

export class SampleBoxItem {
    id: number;
    name: string;
    order: number;
    saleOpportunityId: number;
    parentSampleBoxId: number;
    sampleBoxProducts: SampleBoxProductItem[];

    constructor(sampleBox?) {
        const internal = sampleBox || {};
        this.id = internal.id;
        this.name = internal.name;
        this.order = internal.order;
        this.saleOpportunityId = internal.saleOpportunityId;
        this.parentSampleBoxId = internal.parentSampleBoxId;
        this.sampleBoxProducts = (internal.sampleBoxProducts || []).map(
            item => new SampleBoxProductItem(item)
        );
    }
}

export class TargetPriceItem {
    id: number;
    name: string;
    targetPrice: number;
    seasonName: string;
    saleSeasonTypeId: number;
    alternativesAmount: number;
    //servedAlternativesAmount: number;
    get displayName() {
        let result = this.name || 'No name';
        result = `${result} (${this.seasonName})`;
        return result;
    }
    sampleBoxes: SampleBoxItem[];
    saleOpportunityId: number;
    saleOpportunityTargetPriceProducts: TargetPriceProductItem[];

    constructor(targetPrice?) {
        const internal = targetPrice || {};
        this.id = internal.id;
        this.name = internal.name;
        this.targetPrice = internal.targetPrice;
        this.seasonName = internal.seasonName;
        this.alternativesAmount = internal.alternativesAmount;
        //this.servedAlternativesAmount = internal.servedAlternativesAmount;
        this.saleOpportunityId = internal.saleOpportunityId;
        this.saleOpportunityTargetPriceProducts = (internal.saleOpportunityTargetPriceProducts || []).map(
            item => new TargetPriceProductItem(item)
        );
    }
}

export class TargetPriceProductItem {
    id: number;
    targetPriceId: number;
    order: number;
    sampleBoxId: number;
    productId: number;
    productName: string;
    productTypeId: string;
    productTypeName: string;
    productTypeDescription: string;
    productPictureId: number;
    productColorTypeId?: string;
    opportunityCount: number;
    firstOpportunityId: number;
    relatedProducts: TargetPriceProductSubItem[];

    get editable() {
        return this.opportunityCount == 1 && this.firstOpportunityId == this.targetPriceId;
    }

    constructor(item?) {
        const internal = item || {};
        if (internal.key) {
            this.productId = internal.key;
        } else {
            this.id = internal.id;
            this.order = internal.order;
            this.sampleBoxId = internal.sampleBoxId;
            this.productColorTypeId = internal.productColorTypeId;
            this.productId = internal.productId;
            this.productName = internal.productName;
            this.productTypeId = internal.productTypeId;
            this.productTypeName = internal.productTypeName;
            this.productTypeDescription = internal.productTypeDescription;
            this.productPictureId = internal.productPictureId;

            this.firstOpportunityId = internal.firstOpportunityId;
            this.opportunityCount = internal.opportunityCount;

            this.relatedProducts = (
                internal.relatedProducts || []
            ).map(subItem => new TargetPriceProductSubItem(subItem));
        }
    }
}

export class SampleBoxGrid {
    id?: number;
    order?: number;

    constructor(item?) {
        const internal = item || <SampleBoxGrid>{};
        this.id = internal.id;
        this.order = internal.order;
    }
}

export class ProductGrid {
    id?: number;
    fileId?: number;
    productName?: string;
    productTypeName?: string;
    productAmount: number;

    constructor(item?) {
        const internal = item || <ProductGrid>{};
        this.id = internal.id;
        this.fileId = internal.fileId;
        this.productName = internal.productName;
        this.productTypeName = internal.productTypeName;
        this.productAmount = internal.productAmount;
    }
}

export class SaleOpportunityNewDialogResult {
    goTo: 'Edit';
    data: SaleOpportunity;
}

export class SampleBoxProductItem {
    id: number;
    order: number;
    sampleBoxId: number;
    productId: number;
    productName: string;
    productTypeId: string;
    productTypeName: string;
    productTypeDescription: string;
    productPictureId: number;
    productColorTypeId?: string;
    //sampleBoxProductSubItems: SampleBoxProductSubItem[];

    constructor(item?) {
        const internal = item || {};
        if (internal.key) {
            this.productId = internal.key;
        } else {
            this.id = internal.id;
            this.order = internal.order;
            this.sampleBoxId = internal.sampleBoxId;
            this.productColorTypeId = internal.productColorTypeId;
            this.productId = internal.productId;
            this.productName = internal.productName;
            this.productTypeId = internal.productTypeId;
            this.productTypeName = internal.productTypeName;
            this.productTypeDescription = internal.productTypeDescription;
            this.productPictureId = internal.productPictureId;

            //debugger;
            //this.sampleBoxProductSubItems = (
            //    internal.sampleBoxProductSubItems || []
            //).map(subItem => new SampleBoxProductSubItem(subItem));
        }
    }
}

export class TargetPriceProductSubItem {
    id: number;
    targetPriceProductId: number;
    productId: number;
    relatedProductName: string;
    productTypeId: string;
    productTypeName: string;
    productTypeDescription: string;
    productPictureId: number;
    productAmount: number;
    colorTypeId?: string;

    constructor(item?) {
        const internal = item || {};
        if (internal.key) {
            this.productId = internal.key;
            this.productAmount = 1;
        } else {
            this.id = internal.id;
            this.targetPriceProductId = internal.targetPriceProductId;
            this.productId = internal.productId;
            this.relatedProductName = internal.relatedProductName;
            this.productTypeId = internal.productTypeId;
            this.productTypeName = internal.productTypeName;
            this.productTypeDescription = internal.productTypeDescription;
            this.productPictureId = internal.productPictureId;
            this.productAmount = internal.productAmount;
            this.colorTypeId = internal.colorTypeId;
            //debugger;
        }
    }
}

export class SaleOpportunitySettings {
    id?: number;
    delivered: boolean;
    riverdaleMargin: number;
    foc: number;
    growerId: number;
    funzaQuote: string;

    constructor(settings) {
        const internal = settings || {};
        this.id = internal.id;
        this.delivered = internal.delivered;
        this.riverdaleMargin = internal.riverdaleMargin;
        this.foc = internal.foc;
        this.growerId = internal.growerId;
    }
}

export class SampleBoxItemNewDialogInput {
    sampleBoxId: number;
}

export class SampleBoxItemNewDialogOutput {
    goTo: 'Edit';
    data: SampleBoxItem;
}

export class SaleOpportunityTargetPriceNewDialogInput {
    saleOpportunityId: number;
}

export class SaleOpportunityTargetPriceNewDialogOutput {
    goTo: string;
    data: TargetPriceItem;
}


export class SaleOpportunityTargetPriceProductNewDialogInput {
    targetPriceId: number;
    productId: number;
}

export class SaleOpportunityTargetPriceProductNewDialogOutput {
    goTo: string;
    data: TargetPriceItem;
}


export class SaleOpportunityTargetPriceSubProductNewDialogInput {
    productId: number;
    subProductId: number;
}

export class SaleOpportunityTargetPriceSubProductNewDialogOutput {
    goTo: string;
    data: TargetPriceItem;
}
