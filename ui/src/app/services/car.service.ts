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

  getCarsByColor(colorId:number):Observable<ListResponseModel<CarDetail>>{
    let path = `${this.apiServiceUrl}/getbycolor?colorId=${colorId}`
    return this.httpClient.get<ListResponseModel<CarDetail>>(path)
  }

  getCarsByBrand(brandId:number):Observable<ListResponseModel<CarDetail>>{
    let path = `${this.apiServiceUrl}/getbybrand?brandId=${brandId}`
    return this.httpClient.get<ListResponseModel<CarDetail>>(path)
  }

  getCarDetailsById(carId:number):Observable<SingleResponseModel<CarDetail>>{
    let path = `${this.apiServiceUrl}/cardetailsbyid?carId=${carId}`
    return this.httpClient.get<SingleResponseModel<CarDetail>>(path)
  }

  getCarDetails():Observable<ListResponseModel<CarDetail>>{
    let path = `${this.apiServiceUrl}/cardetails`
    return this.httpClient.get<ListResponseModel<CarDetail>>(path)
  }

  getTopCheapCars(top:number):Observable<ListResponseModel<CarDetail>>{
    let path = `${this.apiServiceUrl}/gettopcheapcars?top=${top}`
    return this.httpClient.get<ListResponseModel<CarDetail>>(path)
  }


  add(car:CarCreateDto):Observable<ResponseModel>{
    console.log(car)
    let path = `${this.apiServiceUrl}`
    return this.httpClient.post<ResponseModel>(path,car)
  }

  delete(id:Guid):Observable<ResponseModel>{
    let path = `${this.apiServiceUrl}/${id}`
    return this.httpClient.delete<ResponseModel>(path)
  }

  update(car:Car):Observable<HttpEvent<ResponseModel>>{
    let path = `${this.apiServiceUrl}/update`
    return this.httpClient.post<HttpEvent<ResponseModel>>(path,car)
  }


}
