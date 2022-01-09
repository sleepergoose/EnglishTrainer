import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateChild, CanLoad, Route, Router, RouterStateSnapshot, UrlSegment, UrlTree } from '@angular/router';
import { Observable, take } from 'rxjs';
import { UserRoles } from '../models/auth/user-roles';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class RoleGuard implements CanActivate, CanActivateChild, CanLoad {
  constructor(
    private _auth: AuthService,
    private _router: Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): 
    Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      let roles = route.data['roles'] as Array<string>;

      return this.canActivateByRoleObservable(roles);
  }

  canActivateChild(
    childRoute: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return true;
  }

  canLoad(
    route: Route,
    segments: UrlSegment[]): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return true;
  }

  protected async canActivateByRoleObservable(roles: string[]) {
    const user = await this._auth.getUser();
    const role = await this._auth.getUserRole();

    if (roles?.includes(this._userRoleToString(+role! as UserRoles))) {
      return true;
    }
    else {
      return false;
    }
  }

  private _userRoleToString(role: UserRoles) {
    switch (role) {
      case UserRoles.admin: return 'admin';
      default: return 'user';
    }
  }
}
