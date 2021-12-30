import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-profile-menu',
  templateUrl: './profile-menu.component.html',
  styleUrls: ['./profile-menu.component.sass']
})
export class ProfileMenuComponent implements OnInit{
  userName: string | null = '';

  constructor(private _auth: AuthService) {}

  async ngOnInit() {
      const user = await this._auth.getUser();
      
      if (user) {
        this.userName = user.displayName;
      }
  }

  signOut() {
    this._auth.signOut();
  }
}
