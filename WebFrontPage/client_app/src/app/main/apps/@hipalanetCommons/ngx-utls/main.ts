import { NgModule, ModuleWithProviders } from "@angular/core";
import { DirectivesModule } from "./directives.module";
import { PipesModule } from "./pipes.module";
import { EnvironmentProvider, EnvironmentData } from "./_common";


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

    static forRoot(config?: EnvironmentData): ModuleWithProviders {
        return {
            ngModule: HipalanetUtils,
            providers: [{
                provide: EnvironmentData, useValue: config
            }]
        }

    }
}
