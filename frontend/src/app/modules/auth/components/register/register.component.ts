import { Component } from '@angular/core';
import { take } from 'rxjs';
import { RegisterData } from 'src/app/models/auth/register-data';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.sass']
})
export class RegisterComponent   {
  registerData = {} as RegisterData;
  hide = true;

  constructor(private _authService: AuthService) { }

  onSubmit() {
    this._authService.registerUserWithEmail(this.registerData)
  }
}
