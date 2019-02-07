import { FileItem } from "ng2-file-upload";

export interface ISelectedFile {
    base64?: string;
    fileItem: FileItem;
}

export interface IUploadedFile extends ISelectedFile {

    contentLength: number

    /*"image/jpeg"*/
    contentType: string;

    originalFileName: string;

    temporaryFileName: string;

    uniqueIdentifier: string;
}
