import { NgModule } from '@angular/core';
import { GrowerService } from './grower.service';

export { GrowerService } from './grower.service';

@NgModule({
    providers: [
        GrowerService
    ]
})
export class GrowerCoreModule {
}

