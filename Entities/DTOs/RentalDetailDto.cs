 using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace Entities.DTOs
 {
     public class RentalDetailDto : IDto
     {
         public Guid Id { get; set; }
         public Guid CarId { get; set; }
         public string BrandName { get; set; }
         public string ColorName { get; set; }
         public string ModelFullName { get; set; }
         public Guid CustomerId { get; set; }
         public string CustomerFullName { get; set; }
         public decimal DailyPrice { get; set; }
         public DateTime RentDate { get; set; }
         public DateTime ReturnDate { get; set; }
         public Guid PaymentId { get; set; }
         public DateTime PaymentDate { get; set; }
         public bool? DeliveryStatus { get; set; }

     }
 }