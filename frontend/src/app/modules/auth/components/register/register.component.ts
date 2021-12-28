import { Component } from '@angular/core';
import { RegisterData } from 'src/app/models/auth/register-data';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.sass']
})
export class RegisterComponent   {
  registerData = {} as RegisterData;
  hide = true;

  constructor() { }

  onSubmit() {
  }
}
