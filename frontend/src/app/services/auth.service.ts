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
  idToken,
  getIdToken,
  CustomParameters
} from '@angular/fire/auth';
import { firstValueFrom, from, lastValueFrom, Observable, of, take } from 'rxjs';
import { Router } from '@angular/router';
import { LoginData } from '../models/auth/login-data';
import { AuthUser } from '../models/auth/auth-user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _user$: Observable<User | null>;
  private _currentAuthState: boolean = false;
  private _user = {} as User;
  
  authUser = {} as AuthUser;

  constructor(
    private _http: HttpInternalService,
    private _auth: Auth,
    private _router: Router) {
      this._user$ = authState(this._auth);

      onAuthStateChanged(this._auth, (user) => {
        if (user) {
          this._setAuthState(true);
        }
        else {
          this._setAuthState(false);
        }
      });
      // this._tokenId$ = new Observable((observer: any) => this._auth.onIdTokenChanged(observer));
  }

  async getTokenResult() {
    return await this._auth.currentUser!.getIdTokenResult(true);
  }

  async getUser(): Promise<User | null> {
    return await firstValueFrom(this._user$)
  }

  async getUserId() {
    const token = await this.getTokenResult();
    return token.claims['id'];
  }

  getAuthState(): boolean {
    return this._currentAuthState;
  }

  getCurrentTokenObservable() {
    return from(this._auth.currentUser!.getIdToken());
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
    signInWithEmailAndPassword(this._auth, email, password)
      .then((userCredentials) => {
          if (userCredentials.user.email) {
            this._currentAuthState = true;
            this._user = userCredentials.user;
            this._updateAuthState(userCredentials.user);
            this._router.navigateByUrl('/mainpage')
          }
      });
  }

  signOut() {
    return signOut(this._auth)
      .then(() => {
        this._router.navigateByUrl('/auth/login');
        this._currentAuthState = false;
      });
  }

  private _setAuthState(state: boolean) {
    this._currentAuthState = state;
  }

  private async _updateAuthState(user: User | null) {
    if (!user?.email) {
      this._setAuthState(false);
      return;
    }

    const loginData: LoginData = {
      accessToken: await getIdToken(user),
      firebaseId: user.uid,
      name: user.displayName!,
      email: user.email!
    };

    const response = this._http.postFullRequest('/api/Auth/login', loginData);
    
    if (!(await lastValueFrom(response)).ok) {
      this.signOut();
      return;
    }
      
    const tokenResult = await (await this._user.getIdTokenResult(true));
    
    this.authUser = {
      id: <any>tokenResult.claims['id'],
      role: <any>tokenResult.claims['role'],
      firebaseId: user.uid,
      name: user.displayName!,
      email: user.email!,
      accessToken: tokenResult.token,
      refreshToken: user.refreshToken
    };

    this._setAuthState(true);
  }
}
