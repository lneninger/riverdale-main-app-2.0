



export interface OperationResponseValued<T extends Object> extends OperationResponse {
    bag: T;
}

export interface OperationResponse {
    isSucceed: boolean;
    messages: OperationMessage[]
}

export interface OperationMessage {
    message: string;
}