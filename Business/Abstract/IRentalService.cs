using System;
using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAllRentals();
        IResult AddRental(Rental rental);
        IResult DeleteRental(Rental rental);
        IResult UpdateRental(Rental rental);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IDataResult<Rental> GetRentalById(Guid rentalId);
        public IDataResult<bool> IsRentable(Guid carId, DateTime rentDate, DateTime returnDate);
        IResult AddRentalWithDetails(RentalAddDto rental);
    }
}
