import { Injectable } from '@angular/core';
import { RegisterData } from '../models/auth/register-data';
import { HttpInternalService } from './http-internal.service';
import {
  Auth,
  signOut,
  signInWithPopup,
  user,
  signInWithEmailAndPassword,
  createUserWithEmailAndPassword,
  updateProfile,
  sendEmailVerification,
  sendPasswordResetEmail,
  getAdditionalUserInfo,
  OAuthProvider,
  linkWithPopup,
  unlink,
  updateEmail,
  updatePassword,
  User,
  reauthenticateWithPopup,
  authState,
  onAuthStateChanged,
  setPersistence,
  browserLocalPersistence,
  browserSessionPersistence
} from '@angular/fire/auth';
import { firstValueFrom, lastValueFrom, Observable, take } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _user$: Observable<User | null>;
  
  constructor(
    private _http: HttpInternalService,
    private _auth: Auth,
    private _router: Router) {
      this._user$ = new Observable((observer: any) =>
        onAuthStateChanged(this._auth, observer)
      );
  }

  async getUser(): Promise<User | null> {
    return await firstValueFrom(this._user$)
  }

  async registerUserWithEmail(registerData: RegisterData) {
    const response = this._http.postFullRequest('/api/Auth/register', registerData);
    
    if (!(await lastValueFrom(response)).ok) {
      return;
    }

    await this.signInWithEmail(registerData.email, registerData.password);

    this._router.navigateByUrl('/mainpage')
  }

  async signInWithEmail(email: string, password: string) {
    // await this._setPersistence();
    await signInWithEmailAndPassword(this._auth, email, password);
    this._router.navigateByUrl('/mainpage')
  }

  private _setPersistence() {
    return setPersistence(this._auth, browserLocalPersistence);
  }

  signOut() {
    return signOut(this._auth)
      .then(() => this._router.navigateByUrl('/auth/login'));
  }
}
