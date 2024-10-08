import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DataResponse } from '../model/api-response.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export abstract class ApiHttpService {

  protected rootUrl: string = 'https://localhost:7190';

  constructor(protected httpClient: HttpClient) { }

  public post<T>(path: string, body: any | undefined) : Observable<DataResponse<T>> {
    console.log(this.createUrl(path));
    return this.httpClient.post<DataResponse<T>>(this.createUrl(path), body, {

    });
  }

  public get<T>(path: string) : Observable<DataResponse<T>>{
    return this.httpClient.get<DataResponse<T>>(this.createUrl(path));
  }

  protected createUrl(path: string) : string{
    return `${this.rootUrl}${path}`;
  }
}
