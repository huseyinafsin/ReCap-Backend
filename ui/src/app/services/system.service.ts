import { Injectable } from '@angular/core';
import { SystemTable, environment } from '../../environments/environment';
import { ResponseModel} from '../models/responseModel'
import { ListResponseModel} from '../models/listResponseModel'
import { Observable } from 'rxjs';
import { SystemCreateDto } from '../models/SystemCreate';
import { SystemDto } from '../models/systemDto';
import { Guid } from 'guid-typescript';
import { HttpClient } from '@angular/common/http';
import { SingleResponseModel } from '../models/singleResponseModel';

@Injectable({
  providedIn: 'root'
})
export class SystemService {

  apiServiceUrl = `${environment.apiUrl}/system`

  constructor(private httpClient:HttpClient) {}

  getAll(table:SystemTable):Observable<ListResponseModel<SystemDto>>{
    let path = `${this.apiServiceUrl}/${table}`
    return this.httpClient.get<ListResponseModel<SystemDto>>(path);
  }

  get(table:SystemTable, id:Guid):Observable<SingleResponseModel<SystemDto>>{
    let path = `${this.apiServiceUrl}/${table}/${id}`
    return this.httpClient.get<SingleResponseModel<SystemDto>>(path);
  }
  add(table:SystemTable, createDto:SystemCreateDto):Observable<ResponseModel>{
    let path = `${this.apiServiceUrl}/${table}`
    return this.httpClient.post<ResponseModel>(path,createDto);
  }

  update(table:SystemTable, updateDto:SystemCreateDto):Observable<ResponseModel>{
    let path = `${this.apiServiceUrl}/${table}`
    return this.httpClient.put<ResponseModel>(path, updateDto);
  }

  delete(table:SystemTable,id:Guid):Observable<ResponseModel>{
    let path = `${this.apiServiceUrl}/${table}/${id}`
    return this.httpClient.delete<ResponseModel>(path);
  }
}

