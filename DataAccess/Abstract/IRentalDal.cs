using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.Utilities.Results;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IRepository<Rental>
    {
        List<RentalDetailDto> RentalDetails();
        IResult AddRentalWithDetails( RentalAddDto rental);
    }
}