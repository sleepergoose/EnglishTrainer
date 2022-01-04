import { Component, SkipSelf } from '@angular/core';
import { take } from 'rxjs';
import { HttpInternalService } from 'src/app/services/http-internal.service';

@Component({
  selector: 'app-left-side-menu',
  templateUrl: './left-side-menu.component.html',
  styleUrls: ['./left-side-menu.component.sass']
})
export class LeftSideMenuComponent {
  isMyTrackContainerShown: boolean = false;

  constructor(@SkipSelf() private _http: HttpInternalService) { }

  // The method below is just for test
  go() {
    this._http.getRequest('/api/Words/1')
      .pipe(take(1))
      .subscribe((word: any) => {
        console.log(word);
      });
  }
}
