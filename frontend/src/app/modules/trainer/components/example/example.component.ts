import { Component, Input } from '@angular/core';
import { Example } from 'src/app/models/examples/example';

@Component({
  selector: 'app-example',
  templateUrl: './example.component.html',
  styleUrls: ['./example.component.sass']
})
export class ExampleComponent {
  @Input() examples = [] as Example[];
  @Input() isRuHidden: boolean = false;
  @Input() isEnHidden: boolean = false;
  @Input() isBolded: boolean = false;

  constructor() { }
}
