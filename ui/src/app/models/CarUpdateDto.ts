import { Guid } from "guid-typescript";
import { CarImage } from "./carImage";

export class CarUpdateDto {
  id: Guid;
  brandId: Guid;
  colorId: Guid;
  carTypeId: Guid;
  gearTypeId: Guid;
  fuelTypeId: Guid;
  insertedUserId: Guid;
  carName: string;
  model: string;
  images: CarImage[];
  description: string;
  minFindexScore: number;
  hasChildSeat: boolean;
}
