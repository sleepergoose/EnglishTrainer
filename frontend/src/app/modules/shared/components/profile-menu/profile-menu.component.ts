import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, NavigationEnd   } from '@angular/router';
import { take } from 'rxjs';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-profile-menu',
  templateUrl: './profile-menu.component.html',
  styleUrls: ['./profile-menu.component.sass']
})
export class ProfileMenuComponent implements OnInit{
  userName: string | null = '';
  isAdmin: boolean = false;
  isStudioNow: boolean = false;

  constructor(
    private _auth: AuthService,
    private _router: Router
  ) {}

  async ngOnInit() {
      const user = await this._auth.getUser();
      const userRole = await this._auth.getUserRole();
 
      if (+userRole! === 1) {
        this.isAdmin = true;
      }

      if (user) {
        this.userName = user.displayName;
      }

      if (this._router.url.split('/')[1] === 'admin') {
        this.isStudioNow = true;
      }
      else {
        this.isStudioNow = false;
      }
  }

  signOut() {
    this._auth.signOut();
  }

  goToStudio() {
    this._router.navigate([`admin`]);
    this.isStudioNow = true;
  }

  goToTrainer() {
    this._router.navigate([``]);
    this.isStudioNow = false;
  }
}
