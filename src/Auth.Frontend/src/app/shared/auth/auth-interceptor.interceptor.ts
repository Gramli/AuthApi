import {
  HttpHandlerFn,
  HttpRequest,
} from '@angular/common/http';
import { inject } from '@angular/core';
import { JwtTokenService } from '../services/jwt-token.service';

export function authInterceptor(req: HttpRequest<unknown>, next: HttpHandlerFn) {
  const authToken = inject(JwtTokenService).getToken();
  if (authToken) {
    const authReq = req.clone({
      headers: req.headers.set('Authorization', `Bearer ${authToken}`),
    });

    return next(authReq);
  }

  return next(req);
  };
