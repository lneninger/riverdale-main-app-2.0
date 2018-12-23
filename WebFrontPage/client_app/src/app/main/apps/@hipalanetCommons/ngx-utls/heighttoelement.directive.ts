import { DomSanitizer } from '@angular/platform-browser'
import { Directive, Input, ElementRef, OnInit, AfterViewInit, HostListener } from '@angular/core';

declare var $: any;


@Directive({
    selector: '[heightTo]'
})
export class HeightToElementDirective implements OnInit, AfterViewInit {
    processed: boolean = false;

    @Input('heightTo')
    targetElementSelector: string;

    @Input('heightFromChild')
    sourceElementSelector: string;

    @Input('currentPadding')
    currentPadding: number;

    @HostListener('window:resize', ['$event'])
    onResize(event) {
        event.target.innerWidth;
    }

    constructor(private elementRef: ElementRef/*, private layoutService: LayoutService*/) {
        //debugger;
    }

    ngAfterViewInit(): void {
        this.setElementHeight();
    }

    ngOnInit(): void {

    }

    setElementHeight() {
        this.clearElementHeight();

        setTimeout(() => {
            let elementHeight = $(this.getSourceElement()).css('height');
            if (this.processed) return;
            elementHeight = this.calculateHeight();
            $(this.getSourceElement()).css('height', elementHeight);
            console.log('after set: ', elementHeight);
            //this.processed = true;
        }, 100);
    }

    getSourceElement() {
        let result = (this.sourceElementSelector ? $(this.elementRef.nativeElement).find(this.sourceElementSelector)[0] : this.elementRef.nativeElement);
        return result;
    }

    clearElementHeight() {
        $(this.getSourceElement()).css('height', '');
        let elementHeight = $(this.getSourceElement()).css('height');
        console.log('after clear: ', elementHeight);
    }

    calculateHeight() {
        let targetElement = $(this.targetElementSelector)[0];
        let targetElementVerticalPosition = targetElement.offsetTop;
        console.log('target element top: ', targetElementVerticalPosition);

        let sourceElement = this.getSourceElement();
        let currentElementVerticalPosition = 0;
        if (sourceElement) {
            currentElementVerticalPosition = sourceElement.offsetTop;
            let currentElementHeight = sourceElement.offsetHeight;
        }

        console.log('curruent element top: ', currentElementVerticalPosition);

        let result = targetElementVerticalPosition - currentElementVerticalPosition;

        if (this.currentPadding) {
            result -= this.currentPadding;
        }

        return result;
    }
}