import { Component } from '@angular/core';
import { LoginData } from 'src/app/models/auth/login-data';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent {
  loginData = {} as LoginData;
  hide = true;

  constructor(private _auth: AuthService) { }

  onSubmit() {
    this._auth.signInWithEmail(this.loginData.email, this.loginData.password);
  }
}
