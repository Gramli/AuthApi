import { Injectable } from '@angular/core';
import { ApiHttpService } from '../../shared';
import { Observable } from 'rxjs';
import { DataResponse } from '../../shared/model/api-response.model';
import { IServiceInfo } from './service-info.model';

@Injectable({
  providedIn: 'root'
})
export class ServiceInfoService {

  constructor(private httpApiService: ApiHttpService) { }

  public getUserInfo(): Observable<DataResponse<IServiceInfo>>{
    return this.httpApiService
    .get<IServiceInfo>('/v1/user/service-info');
  }
}
