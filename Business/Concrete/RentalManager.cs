using Business.Abstract;
using Business.Constants;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private  readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [CacheRemoveAspect("IRentalService.Get")]
        //[SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult AddRental(Rental rental)
        {
          var activeRentals = _rentalDal.GetAll(x => x.ReturnDate == null).Select(x=>x.CarId);

            if (activeRentals.Contains(rental.CarId))
            {
                return new ErrorResult(Messages.RentalError);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }


        [CacheRemoveAspect("IRentalService.Get")]
        [SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult DeleteRental(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        [CacheAspect]
       // [SecuredOperation("admin,customer")]
        public IDataResult<List<Rental>> GetAllRentals()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        [CacheAspect]
        //[SecuredOperation("admin,customer")]
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.RentalDetails(), Messages.RentalListed);
        }    

        [CacheAspect]
        [SecuredOperation("admin,customer")]
        public IDataResult<Rental> GetRentalById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(x => x.Id == rentalId), Messages.RentalFetched);
        }

  
        public IDataResult<bool> IsRentable(int carId, DateTime rentDate, DateTime returnDate)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId);

            if (result.Any(r =>
                    r.ReturnDate >= rentDate &&
                    r.RentDate <= returnDate
                )) return new SuccessDataResult<bool>(false,Messages.CarCanNotRentable);

            return new SuccessDataResult<bool>(true,Messages.CarCanRentable);
        }

        public IResult AddRentalWithDetails(RentalAddDto rental)
        {
            var result = _rentalDal.AddRentalWithDetails(rental);
            if (result.Success)
            {
                return new SuccessResult(result.Message);
            }
            else
            {
                return new ErrorResult(result.Message);
            }
        }


        [CacheRemoveAspect("IRentalService.Get")]
        [SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult UpdateRental(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
