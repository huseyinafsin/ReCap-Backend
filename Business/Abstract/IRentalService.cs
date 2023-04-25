using System;
using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        Task<IDataResult<List<Rental>>> GetAllRentals();
        Task<IResult> AddRental(Rental rental);
        IResult DeleteRental(Rental rental);
        IResult UpdateRental(Rental rental);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        Task<IDataResult<Rental>> GetRentalById(Guid rentalId);
        Task<IDataResult<bool>> IsRentable(Guid carId, DateTime rentDate, DateTime returnDate);
        IResult AddRentalWithDetails(RentalAddDto rental);
    }
}
