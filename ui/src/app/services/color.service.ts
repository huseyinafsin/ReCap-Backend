import { Injectable } from '@angular/core';
import { HttpClient}  from '@angular/common/http'
import { Observable } from 'rxjs';
import { ListResponseModel } from '../models/listResponseModel';
import { Color } from '../models/color';
import { ColorDto } from '../models/colorDto';
import { environment } from 'src/environments/environment';
import { ResponseModel } from '../models/responseModel';
import { Guid } from 'guid-typescript';


@Injectable({
  providedIn: 'root'
})
export class ColorService {
  apiServiceUrl:string = `${environment.apiUrl}/colors`

  constructor(private httpClient: HttpClient) { }

  getColors():Observable<ListResponseModel<Color>>{
      let path = `${this.apiServiceUrl}/getall`
      return this.httpClient.get<ListResponseModel<Color>>(path);
  }

  add(color:ColorDto): Observable<ResponseModel>{
    console.log(color)
    let path = `${this.apiServiceUrl}/add`
    return this.httpClient.post<ResponseModel>(path,color)
  }

  update(color:Color): Observable<ResponseModel>{
    let path = `${this.apiServiceUrl}/update`
    return this.httpClient.post<ResponseModel>(path,color)
  }

  delete(id:Guid): Observable<ResponseModel>{

    let path = `${this.apiServiceUrl}/${id}`
    return this.httpClient.delete<ResponseModel>(path)
  }

}
