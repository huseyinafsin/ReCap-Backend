import { HttpClient, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Car } from '../models/car';
import { CarDetail } from '../models/carDetail';
import { ListResponseModel } from '../models/listResponseModel';
import { ResponseModel } from '../models/responseModel';
import { SingleResponseModel } from '../models/singleResponseModel';
import { CarGridDto } from '../models/CarGridDto';
import { CarCreateDto } from '../models/CarCreateDto';
import { Guid } from 'guid-typescript';
import { CarGridModelDto } from '../models/CarGridModelDto';
import { CarUpdateDto } from '../models/CarUpdateDto';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  apiServiceUrl:string = `${environment.apiUrl}/cars`

  constructor(private httpClient:HttpClient) { }

  getPaged(page:number,  pageSize:number):Observable<SingleResponseModel<CarGridModelDto>>{
    let path = `${this.apiServiceUrl}/getpaged?page=${page}&&pageSize=${pageSize}`
    return this.httpClient.get<SingleResponseModel<CarGridModelDto>>(path)
  }
  getCar(id:Guid):Observable<SingleResponseModel<Car>>{
    let path = `${this.apiServiceUrl}/${id}`
    return this.httpClient.get<SingleResponseModel<Car>>(path)
  }


  getCarsByColor(colorId:number):Observable<ListResponseModel<CarDetail>>{
    let path = `${this.apiServiceUrl}/getbycolor?colorId=${colorId}`
    return this.httpClient.get<ListResponseModel<CarDetail>>(path)
  }

  getCarsByBrand(brandId:number):Observable<ListResponseModel<CarDetail>>{
    let path = `${this.apiServiceUrl}/getbybrand?brandId=${brandId}`
    return this.httpClient.get<ListResponseModel<CarDetail>>(path)
  }

  getCarDetailsById(id:Guid):Observable<SingleResponseModel<CarUpdateDto>>{
    let path = `${this.apiServiceUrl}/details/${id}`
    return this.httpClient.get<SingleResponseModel<CarUpdateDto>>(path)
  }

  getCarDetails():Observable<ListResponseModel<CarDetail>>{
    let path = `${this.apiServiceUrl}/cardetails`
    return this.httpClient.get<ListResponseModel<CarDetail>>(path)
  }

  getTopCheapCars(top:number):Observable<ListResponseModel<CarDetail>>{
    let path = `${this.apiServiceUrl}/gettopcheapcars?top=${top}`
    return this.httpClient.get<ListResponseModel<CarDetail>>(path)
  }


  add(car:Car):Observable<ResponseModel>{
    console.log(car)
    let path = `${this.apiServiceUrl}`
    return this.httpClient.post<ResponseModel>(path,car)
  }

  delete(id:Guid):Observable<ResponseModel>{
    let path = `${this.apiServiceUrl}/${id}`
    return this.httpClient.delete<ResponseModel>(path)
  }

  update(car:CarUpdateDto):Observable<SingleResponseModel<ResponseModel>>{
    let path = `${this.apiServiceUrl}`
    return this.httpClient.put<SingleResponseModel<ResponseModel>>(path,car)
  }


}
