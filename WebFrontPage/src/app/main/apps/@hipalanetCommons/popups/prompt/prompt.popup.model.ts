export class PromptPopupData {
    dialogDisplayName: string;
    promptText: string;
    defaultValue: string;
}

export class PromptPopupResult {

    constructor(public action: 'YES' | 'NO', public value?: string) {
    }
}