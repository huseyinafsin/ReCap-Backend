using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RentalAddDto
    {
        public string CardHolderFullName { get; set; }
        public string CardNumber { get; set; }
        public string ExpiredYear { get; set; }
        public string ExpiredMonth { get; set; }
        public string Cvc { get; set; }
        public decimal Amount { get; set; }
        public Guid CarId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
