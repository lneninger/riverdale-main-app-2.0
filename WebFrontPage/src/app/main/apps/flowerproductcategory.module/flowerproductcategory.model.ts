
export class FlowerProductCategoryGrid {
    id: string;
    name: string;
}

export class FlowerProductCategoryGradeGrid {
    id: number;
    name: string;
}


export class FlowerProductCategory
{
    id: string;
    name: string;
    grades: any[];

    /**
     * Constructor
     *
     * @param input Input parameter
     */
    constructor(input?)
    {
        this.id = (input || {}).id;
        this.name = (input || {}).name;
        this.grades = ((input || {}).grades || []).map(subItem => new FlowerProductCategoryGrade(subItem));;
    }
}

export class FlowerProductCategoryGrade {
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



export class FlowerProductCategoryNewDialogResult {
    goTo: 'Edit';
    data: FlowerProductCategory;
}
