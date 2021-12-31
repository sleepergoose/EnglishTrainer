import { Component } from '@angular/core';
import { EmailPasswordData } from 'src/app/models/auth/email-password-data';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent {
  emailPasswordData = {
    email: 'bigman@server.com',
    password: ''
  } as EmailPasswordData;
  hide = true;

  constructor(private _auth: AuthService) { }

  onSubmit() {
    this._auth.signInWithEmail(this.emailPasswordData.email, this.emailPasswordData.password);
  }
}
