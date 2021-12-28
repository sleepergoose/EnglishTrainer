import { Component } from '@angular/core';
import { LoginData } from 'src/app/models/auth/login-data';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent {
  loginData = {} as LoginData;
  hide = true;

  constructor() { }

  onSubmit() {
  }
}
