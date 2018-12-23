import { Directive, Input } from '@angular/core';


@Directive({
    selector: 'img[src][defaultSrc]',
    host: {
        '(error)': 'onError()',
        '[src]': 'src'
    }
})

export class DefaultImage {
    error: boolean;
    @Input() src: string;

    _defaultSrc: string;
    @Input()
    set defaultSrc(value) {
        this._defaultSrc = value;
        this.SetDefaultUrl();
    }

    get defaultSrc() {
        return this._defaultSrc;
    }

    onError() {
        this.error = true;
        this.SetDefaultUrl();
    }
    SetDefaultUrl() {
        //debugger;
        if (this.error) {
            this.src = this.defaultSrc || 'images/angular.png';
        }
    }
}