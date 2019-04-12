export class PromptPopupData {
    promptText: string;
    defaultValue: string;
}

export class PromptPopupResult {

    constructor(public action: 'YES' | 'NO', public value?: string) {
    }
}