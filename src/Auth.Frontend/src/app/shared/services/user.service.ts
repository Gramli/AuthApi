import { Injectable } from '@angular/core';
import { JwtTokenService } from './jwt-token.service';
import { ApiHttpService } from './api-http.service';
import { IRegisterUser, IUser, IUserInfo, IUserLogin } from '../model/user.model';
import { map, Observable } from 'rxjs';
import { DataResponse } from '../model/api-response.model';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  public get loggedUser(): IUser | undefined {
    return this.jwtTokenService.getUser();
  }

  constructor(
    private jwtTokenService: JwtTokenService,
    private httpApiService: ApiHttpService
  ) {
  }

  public isAuthenticated(): boolean {
    return this.jwtTokenService.isExpTokenValid() && this.jwtTokenService.getUser() !== undefined;
  }

  public login(userLogin: IUserLogin): Observable<IUser | undefined> {
    return this.httpApiService
      .post<string>('/v1/user/login', {
        ...userLogin,
      })
      .pipe(
        map(response => {
          this.jwtTokenService.safeToken(response.data);
          const user = this.jwtTokenService.getUser();
          return user;
        })
      );
  }

  public logout(): void {
    this.jwtTokenService.removeToken();
  }

  public register(registerUser: IRegisterUser) : Observable<DataResponse<boolean>> {
    return this.httpApiService
    .post<boolean>('/v1/user/register', {
      ...registerUser,
    });
  }

  public getUserInfo(): Observable<DataResponse<IUserInfo>>{
    return this.httpApiService
    .get<IUserInfo>('/v1/user/user-info');
  }

  public getUsersInfo(): Observable<DataResponse<IUser[]>>{
    return this.httpApiService
    .get<IUser[]>('/v1/user/users-info');
  }
}
