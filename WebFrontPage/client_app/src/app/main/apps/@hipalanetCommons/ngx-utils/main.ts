import { NgModule, ModuleWithProviders, Type, Injector, Inject, InjectionToken } from "@angular/core";
import { DirectivesModule } from "./directives.module";
import { PipesModule } from "./pipes.module";
import { EnvironmentProvider, EnvironmentData, HIPALANET_UTILS_CONFIGPROVIDER } from "./_common";

declare type UtilsConfigType = EnvironmentData | Type<EnvironmentProvider>;

export const HIPALANET_UTILS_CONFIGINTERNAL = new InjectionToken<UtilsConfigType>('HIPALANETUTILSCONFIGINTERNAL');

export function utilsInjector(config: UtilsConfigType, injector: Injector) {
    //debugger
    if (!config) {
        return { fileRetrieveUrl: null };
    }

    if ((<EnvironmentData>config).fileRetrieveUrl !== undefined) {
        return <EnvironmentData>config;
    }
    else {
        let service = injector.get(<Type<EnvironmentProvider>>config);
        return service;
    }

}

@NgModule({
    imports: [
        DirectivesModule
        , PipesModule
    ],
    exports: [
        DirectivesModule
        , PipesModule
    ]
})
export class HipalanetUtils {

    static forRoot(config: UtilsConfigType): ModuleWithProviders {
        return {
            ngModule: HipalanetUtils,
            providers: [
                { provide: HIPALANET_UTILS_CONFIGINTERNAL, useValue: config }
                , { provide: HIPALANET_UTILS_CONFIGPROVIDER, useFactory: utilsInjector, deps: [HIPALANET_UTILS_CONFIGINTERNAL, Injector] }]
        }
    }
}
