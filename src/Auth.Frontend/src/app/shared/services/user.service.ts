import { Injectable } from '@angular/core';
import { JwtTokenService } from './jwt-token.service';
import { ApiHttpService } from './api-http.service';
import { HttpClient } from '@angular/common/http';
import { IRegisterUser, IUser, IUserLogin } from '../model/user.model';
import { map, Observable } from 'rxjs';
import { DataResponse } from '../model/api-response.model';

@Injectable({
  providedIn: 'root',
})
export class UserService extends ApiHttpService {
  constructor(
    private jwtTokenService: JwtTokenService,
    httpClient: HttpClient
  ) {
    super(httpClient);
  }

  public isAuthenticated(): boolean {
    return this.jwtTokenService.isExpTokenValid() && this.jwtTokenService.getUser() !== undefined;
  }

  public login(userLogin: IUserLogin): Observable<IUser | undefined> {
    return super
      .post<string>('/login', {
        ...userLogin,
      })
      .pipe(
        map((response) => {
          this.jwtTokenService.safeToken(response.data);
          const user = this.jwtTokenService.getUser();
          return user;
        })
      );
  }

  public register(registerUser: IRegisterUser) : Observable<DataResponse<boolean>> {
    return super
    .post<boolean>('/register', {
      ...registerUser,
    });
  }
}
