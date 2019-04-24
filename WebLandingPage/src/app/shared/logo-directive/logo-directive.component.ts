import { Component, Input } from "@angular/core";



@Component({
  selector: 'logo-directive',
  templateUrl: './logo-directive.component.html',
  styleUrls: []
})
export class LogoDirective {

  @Input()
  logoType: LogoType = 'text';

  @Input()
  font: string = `\'Cinzel Decorative\', cursive`;

  @Input()
  size: string = '60px';

  @Input()
  color: string = '#FFFFFF';

  constructor() { }
}


declare type LogoType = 'text' | 'initial';
