import { NgModule } from '@angular/core';
import { ProductAliasService } from './productalias.service';

export { ProductAliasService } from './productalias.service';
export * from './productalias.model';

@NgModule({
    providers: [
        ProductAliasService
    ]
})
export class ProductAliasCoreModule {
}

