import { Guid } from "guid-typescript"

export interface Cart{
  cardHolderFullName:string
  cardNumber:string
  expiredYear:string
  expiredMonth:string
  cvc:string
  carId:Guid
  customerId:number
  rentDate:Date
  returnDate:Date
  amount:number
}
