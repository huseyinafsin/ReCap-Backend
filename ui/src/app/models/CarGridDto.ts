import { Guid } from "guid-typescript";

export class CarGridDto {
  id: Guid;
  carName: string;
  model : string;
  carType :string
  fuel : string;
  gear: string;
  brand: string;
  color: string;
  minFindexScore: number;
}


