using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Rental: BaseEntity
    {

        public Guid CarId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Guid PaymentId { get; set; }
        public int Amount { get; set; }
        public int PayAmount { get; set; }
        public bool? DeliveryStatus { get; set; }

    }
}
