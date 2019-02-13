import { Injectable } from '@angular/core';
import {
  HttpEvent,
  HttpInterceptor,
  HttpHandler,
  HttpRequest,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { AuthService } from './auth.service';
import { Constants } from '../constants';
import { Router } from '@angular/router';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(
    private authService: AuthService,
    private router: Router) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    if (req.url.startsWith(Constants.ApiRoot)) {

      const accessToken = this.authService.getAuthorizationHeaderValue();
      const headers = req.headers.set('Authorization', accessToken);
      const authReq = req.clone({ headers });

      return next.handle(authReq).pipe(tap(() => {}, error => {
        const respError = error as HttpErrorResponse;
        if (respError && (respError.status === 401 || respError.status === 403)) {
          this.router.navigate(['/home']);
        }
      }));
    } else {
      return next.handle(req);
    }
  }
}
