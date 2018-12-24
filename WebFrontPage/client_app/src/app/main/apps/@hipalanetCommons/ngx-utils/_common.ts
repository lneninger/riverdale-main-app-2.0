import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';

export interface BaseFileUrl {
    fileRetrieveUrl: string;
}

export const HIPALANET_UTILS_CONFIGPROVIDER = 'HIPALANETUTILSCONFIGPROVIDER';

//export declare type EnvironmentProvider = { [key: string]: any }
export class EnvironmentData implements BaseFileUrl {
    fileRetrieveUrl: string;
}

export abstract class EnvironmentProvider {
    abstract getEnvironnmentData(): Observable<EnvironmentData>;
}