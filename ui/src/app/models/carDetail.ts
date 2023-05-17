import { Guid } from "guid-typescript";
import { CarImage } from "./carImage";

export interface CarDetail {
  id:Guid;
  brandId:Guid
  colorId:Guid
  carName:string;
  brandName:string;
  colorName:string;
  model:string;
  images:CarImage[];
  dailyPrice:number;
  description:string;
  minFindexScore:number
}
