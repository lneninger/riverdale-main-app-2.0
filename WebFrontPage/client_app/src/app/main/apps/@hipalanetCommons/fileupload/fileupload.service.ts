import { Injectable } from "@angular/core";
import { FileUploader, FileUploaderOptions, FileItem } from 'ng2-file-upload';
import { environment } from "environments/environment";
import { Subject } from "rxjs";



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
    onCompleteAll: Subject<any> = new Subject<any>();
    onCompleteItem: Subject<UploadedFile> = new Subject<UploadedFile>();

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
                    (<any>fileItem).base64 = (<FileReader>event.target).result;
                }
            }
        };

        this.uploader.onBeforeUploadItem = (item) => {
            item.withCredentials = false;
        }

        this.uploader.onCompleteAll = () => {
            //debugger;
            this.onCompleteAll.next();
            //this.onCompleteAll.complete();
        };

        this.uploader.onCompleteItem = (item, response, status, header) => {
            let responseJson = JSON.parse(response);
            let uploader = this.uploader;

            //debugger;
            let uploadResponse = responseJson[0];
            let uploadedFile = <UploadedFile>uploadResponse;
            uploadedFile.base64 = (<any>item).base64;

            this.onCompleteItem.next(uploadedFile);
            //this.onCompleteItem.complete();

            console.log(item);
        };
    }
}

export interface UploaderDefaultSettings extends FileUploaderOptions {
}

export interface UploadedFile {
    uniqueIdentifier: string;
    url: string;
    base64: string;
}