import { Guid } from "guid-typescript";


export class CarCreateDto {
  carName: string;
  brandId: Guid;
  colorId: Guid;
  model: Guid;
  carTypeId: Guid;
  fuelTypeId: Guid;
  gearTypeId: Guid;
  insertedUserId: Guid;
  description: string;
  minFindexScore: number;
}
