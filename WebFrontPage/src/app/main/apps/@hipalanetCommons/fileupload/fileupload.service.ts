import { Injectable } from '@angular/core';
import { FileUploader, FileUploaderOptions, FileItem } from 'ng2-file-upload';
import { environment } from 'environments/environment';
import { Subject } from 'rxjs';
import { IUploadedFile, ISelectedFile } from './fileupload.model';
import { HttpClient } from '@aspnet/signalr';
import { SecureHttpClientService } from '../authentication/authentication.core.module';

@Injectable()
export class FileUploadService {
    constructor(private http: SecureHttpClientService) {

    }

    create(options?: UploaderDefaultSettings): CustomFileUploader {
        return new CustomFileUploader(this.http, options);
    }
}

export class CustomFileUploader {
    private uploaderDefaultSettings: UploaderDefaultSettings = {
        url: `${environment.appApi.apiProjectUrl}upload.axd`,
        autoUpload: true
    };

    options: UploaderDefaultSettings;
    uploader: FileUploader;
    onSelectedNew: Subject<ISelectedFile> = new Subject<ISelectedFile>();
    onCompleteAll: Subject<any> = new Subject<any>();
    onCompleteItem: Subject<IUploadedFile> = new Subject<IUploadedFile>();

    constructor(private http: SecureHttpClientService, options?: UploaderDefaultSettings) {
        this.options = options || <UploaderDefaultSettings>{};
        this.options = {
            ...this.uploaderDefaultSettings,
            ...this.options
        };

        this.uploader = new FileUploader(this.options);

        this.uploader.onAfterAddingFile = (fileItem: FileItem) => {
            // debugger;
            if (fileItem && fileItem._file) {
                const reader = new FileReader();

                reader.readAsDataURL(fileItem._file); // read file as data url

                reader.onload = event => {
                    // called once readAsDataURL is completed
                    // debugger;
                    const selectedFile = <ISelectedFile>{
                        base64: (<FileReader>event.target).result,
                        fileItem: fileItem
                    };

                    this.onSelectedNew.next(selectedFile);

                    (<any>fileItem).selectedFile = selectedFile;
                };
            }
        };

        this.uploader.onBeforeUploadItem = item => {
            item.withCredentials = false;
        };

        this.uploader.onCompleteAll = () => {
            // debugger;
            this.onCompleteAll.next();
        };

        this.uploader.onCompleteItem = (item, response, status, header) => {
            const responseJson = JSON.parse(response);
            const uploader = this.uploader;

            // debugger;
            const uploadResponse = responseJson[0];
            const uploadedFile = <IUploadedFile>uploadResponse;
            uploadedFile.base64 = (<ISelectedFile>(
                (<any>item).selectedFile
            )).base64;

            this.onCompleteItem.next(uploadedFile);

            console.log(item);
        };
    }

    isUploaded(obj: any): boolean {
        return (<ISelectedFile>obj).fileItem !== undefined;
    }

    delete(id: number): Promise<any>
    {
        return this.http.delete(this.options.url + `?id=${id}`).toPromise();
    }
}

export interface UploaderDefaultSettings extends FileUploaderOptions {}
