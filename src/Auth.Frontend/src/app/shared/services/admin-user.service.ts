import { Injectable } from '@angular/core';
import { ApiHttpService } from './api-http.service';
import {
  IUser,
} from '../model/user.model';
import { Observable } from 'rxjs';
import { DataResponse } from '../model/api-response.model';

@Injectable({
  providedIn: 'root',
})
export class AdminUserService {
  constructor(
    private httpApiService: ApiHttpService
  ) {}

  public getUsers(): Observable<DataResponse<IUser[]>> {
    return this.httpApiService.get<IUser[]>('/v1/users');
  }

  public changeRole(
    id: number,
    roleName: string
  ): Observable<DataResponse<boolean>> {
    console.log(id);
    return this.httpApiService.patch<boolean>(`/v1/users/${id}/role`, {
      roleName,
    });
  }

  public getRoles(): Observable<DataResponse<string[]>> {
    return this.httpApiService.get<string[]>('/v1/users/roles');
  }
}
