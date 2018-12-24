import { NgModule, ModuleWithProviders, Type } from "@angular/core";
import { DirectivesModule } from "./directives.module";
import { PipesModule } from "./pipes.module";
import { EnvironmentProvider, EnvironmentData, HIPALANET_UTILS_CONFIGPROVIDER } from "./_common";


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

    static forRoot(config?: EnvironmentData | Type<EnvironmentProvider>): ModuleWithProviders {
        //debugger
        if (!config) {
            return {
                ngModule: HipalanetUtils,
                providers: [{
                    provide: HIPALANET_UTILS_CONFIGPROVIDER, useValue: <EnvironmentData>{ fileRetrieveUrl: null }
                }]
            }
        }

        if ((<EnvironmentData>config).fileRetrieveUrl !== undefined) {
            return {
                ngModule: HipalanetUtils,
                providers: [{
                    provide: HIPALANET_UTILS_CONFIGPROVIDER, useValue: config
                }]
            }
        }
        else {
            return {
                ngModule: HipalanetUtils,
                providers: [{
                    provide: HIPALANET_UTILS_CONFIGPROVIDER, useClass: (<Type<EnvironmentProvider>>config)
                }]
            }
        }

    }
}
