import { NgModule } from '@angular/core';
import { SafeHtmlPipe } from './safehtml.pipe';
import { FileUrlPipe } from './fileurl.pipe';

export { SafeHtmlPipe } from './safehtml.pipe';
export { FileUrlPipe } from './fileurl.pipe';


@NgModule({
    imports: []
    , declarations: [SafeHtmlPipe, FileUrlPipe]
    , providers: [SafeHtmlPipe, FileUrlPipe]
    , exports: [SafeHtmlPipe, FileUrlPipe]
})
export class PipesModule {
    static forRoot() {
        return {
            ngModule: PipesModule,
            providers: [],
        };
    }
}



