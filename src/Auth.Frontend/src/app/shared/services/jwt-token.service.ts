import { Injectable } from '@angular/core';
import { IUser } from '../model/user.model';
import { LocalStorageService } from './local-storage.service';
import { jwtDecode, JwtPayload } from 'jwt-decode';

interface AuthApiJwtPayload extends JwtPayload {
  uniqueName: string;
  role: string;
}

@Injectable({
  providedIn: 'root',
})
export class JwtTokenService {
  readonly tokenKeyName = 'token';

  private _decodedToken: AuthApiJwtPayload | undefined;

  constructor(private localStorageService: LocalStorageService) {}

  public getUser(): IUser | undefined {
    const token = this.decodedToken();
    if (token) {
      return {
        username: token.uniqueName,
        role: token.role,
      };
    }

    return undefined;
  }

  public isExpTokenValid(): boolean {
    const token = this.decodedToken();

    if(token && token.exp){
      var expDate = new Date(token.exp * 1000);
      var now = new Date();
      if(expDate > now){
        return true;
      }
    }

    return false;
  }

  public safeToken(token: string): void {
    this.localStorageService.set(this.tokenKeyName, token);
  }

  public removeToken(){
    this.localStorageService.remove(this.tokenKeyName);
  }

  public getToken(){
    return this.localStorageService.get(this.tokenKeyName);
  }

  private decodedToken(): AuthApiJwtPayload | undefined {
    if (this._decodedToken) {
      return this._decodedToken;
    }

    const tokenValue = this.localStorageService.get(this.tokenKeyName);

    if (tokenValue) {
      this._decodedToken = jwtDecode<AuthApiJwtPayload>(tokenValue);
      return this._decodedToken;
    }

    return undefined;
  }
}
