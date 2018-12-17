import { Injectable } from "@angular/core";
import { FileUploader, FileUploaderOptions, FileItem } from 'ng2-file-upload';
import { environment } from "environments/environment";
import { Subject } from "rxjs";
import { IUploadedFile, ISelectedFile } from "./fileupload.model";



@Injectable()
export class FileUploadService {

    constructor() {
    }

    create(options?: UploaderDefaultSettings) {
        return new CustomFileUploader(options);
    }
}

export class CustomFileUploader {
    private uploaderDefaultSettings: UploaderDefaultSettings = {
        url: `${environment.appApi.apiProjectUrl}upload.axd`,
        autoUpload: true,
    };

    options: UploaderDefaultSettings;
    uploader: FileUploader;
    onSelectedNew: Subject<ISelectedFile> = new Subject<ISelectedFile>();
    onCompleteAll: Subject<any> = new Subject<any>();
    onCompleteItem: Subject<IUploadedFile> = new Subject<IUploadedFile>();

    constructor(options?: UploaderDefaultSettings) {
        this.options = options || <UploaderDefaultSettings>{};
        this.options = {
            ...this.uploaderDefaultSettings, ...this.options
        };

        this.uploader = new FileUploader(this.options);

        this.uploader.onAfterAddingFile = (fileItem: FileItem) => {
            // debugger;
            if (fileItem && fileItem._file) {
                var reader = new FileReader();

                reader.readAsDataURL(fileItem._file); // read file as data url

                reader.onload = (event) => { // called once readAsDataURL is completed
                    // debugger;
                    let selectedFile = <ISelectedFile>{
                        base64: (<FileReader>event.target).result,
                        fileItem: fileItem
                    };

                    this.onSelectedNew.next(selectedFile);

                    (<any>fileItem).selectedFile = selectedFile;
                }
            }
        };

        this.uploader.onBeforeUploadItem = (item) => {
            item.withCredentials = false;
        }

        this.uploader.onCompleteAll = () => {
            //debugger;
            this.onCompleteAll.next();
        };

        this.uploader.onCompleteItem = (item, response, status, header) => {
            let responseJson = JSON.parse(response);
            let uploader = this.uploader;

            //debugger;
            let uploadResponse = responseJson[0];
            let uploadedFile = <IUploadedFile>uploadResponse;
            uploadedFile.base64 = (<ISelectedFile>(<any>item).selectedFile).base64;

            this.onCompleteItem.next(uploadedFile);

            console.log(item);
        };
    }
}

export interface UploaderDefaultSettings extends FileUploaderOptions {
}

