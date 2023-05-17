import { Guid } from "guid-typescript"

export interface CarImage{
  id:Guid
  carId:Guid
  imagePath:string
  date:Date
}
