import { DomSanitizer } from '@angular/platform-browser'
import { PipeTransform, Pipe, Inject } from '@angular/core';
import { EnvironmentProvider, EnvironmentData, HIPALANET_UTILS_CONFIGPROVIDER } from './_common';
//import { Constants } from '../../shared/smartadmin.config';
import { Observable, Subject, of } from 'rxjs';
import { map, switchMap, mergeMap } from 'rxjs/operators'


@Pipe({ name: 'fileUrl' })
export class FileUrlPipe implements PipeTransform {
    constructor(private sanitized: DomSanitizer/*, private config: EnvironmentData*/, @Inject(HIPALANET_UTILS_CONFIGPROVIDER) private envProvider: EnvironmentData | EnvironmentProvider) { }
    transform(value: string, defaultSrc?: string, thumbnail: boolean = true): Observable<string> {

        let configDataObservable: Observable<EnvironmentData>;
        if ((<EnvironmentData>this.envProvider).fileRetrieveUrl !== undefined) {
            configDataObservable = of(<EnvironmentData>this.envProvider);
        }
        else if ((<EnvironmentProvider>this.envProvider).getEnvironnmentData !== undefined) {
            configDataObservable = (<EnvironmentProvider>this.envProvider).getEnvironnmentData();
        }
        else {
            console.log('HIPALANET: No configuration found');
            return Observable.throw('HIPALANET: No configuration found');
        }

        if (!value) {
            if (defaultSrc) {
                return of(defaultSrc);
            }
            else {
                return null;
            }
        }

        if (value.toString().indexOf('http') == 0) {
            return of(value);
        }

        //let internalOptions = <FileUrlPipeOptions>{ thumbnail: true };
        //if (options != null) {
        //    internalOptions = { ...internalOptions, ...options };
        //}

       

        if (thumbnail !== undefined) {
            //debugger;
            return configDataObservable.pipe(mergeMap(config => {
                return of(`${config.fileRetrieveUrl}?id=${value}&thumbnail=${thumbnail}`);
            }));
        }
        else {
            return configDataObservable.pipe(mergeMap(config => {
                return of(`${config.fileRetrieveUrl}?id=${value}&thumbnail=true`);
            }));
        }
    }
}

//export class FileUrlPipeOptions {
//    thumbnail?: boolean;
//    defaultSrc?: string;
//}