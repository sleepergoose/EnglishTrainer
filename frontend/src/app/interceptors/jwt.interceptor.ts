import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpResponse,
  HttpErrorResponse
} from '@angular/common/http';
import { firstValueFrom, lastValueFrom, mergeMap, Observable, take, tap } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(private _auth: AuthService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    if (!this._auth.getAuthState()) {
      return next.handle(request);
    }
   
    return this._auth.getCurrentTokenObservable().pipe(
      take(1),
      mergeMap((token) => {
        if (token === null) {
          return next.handle(request);
        }

        const modifiedRequest = request.clone({
          setHeaders: { authorization: `Bearer ${token}` }
        });

        return next.handle(modifiedRequest);
    }));
  }
}
