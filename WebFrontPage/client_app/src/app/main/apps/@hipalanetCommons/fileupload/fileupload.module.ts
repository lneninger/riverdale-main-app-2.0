import { NgModule } from "@angular/core";
import { FileUploadModule } from "ng2-file-upload";

import { CustomFileUploader, FileUploadService } from './fileupload.service';


export { FileUploadService, CustomFileUploader, UploaderDefaultSettings } from './fileupload.service';




@NgModule({
    imports: [
        FileUploadModule
    ]
    , providers: [
        FileUploadService
    ]
    , exports: [
        FileUploadModule
    ]
})
export class CustomFileUploadModule
{
}