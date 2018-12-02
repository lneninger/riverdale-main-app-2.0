
export class ProductColorGrid {
    id: string;
    name: string;
    hexCode: string;
    isBunchColor: boolean;
}


export class ProductColor
{
    id: string;
    name: string;
    hexCode: string;
    isBunchColor: boolean;

    /**
     * Constructor
     *
     * @param productColor
     */
    constructor(input?)
    {
        this.id = (input || {}).id;
        this.name = (input || {}).name;
        this.hexCode = (input || {}).hexCode;
        this.isBunchColor = (input || {}).isBunchColor;
    }
}