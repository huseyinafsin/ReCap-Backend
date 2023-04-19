using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities;
using Core.Utilities.Results;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }


        [CacheRemoveAspect("IColorService.Get")] [SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult AddColor(Color color)
        {

            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        [CacheRemoveAspect("IColorService.Get")]
        [SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult DeleteColor(Color color)
        {

            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        [CacheAspect]
        //[SecuredOperation("admin,customer")]
        public IDataResult<List<Color>> GetAllColors()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorListed);
        }

        [CacheAspect]
        //[SecuredOperation("admin,customer")]
        public IDataResult<Color> GetColorById(Guid colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == colorId), Messages.ColorFetched);
        }

        [CacheRemoveAspect("IColorService.Get")]
        [SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult UpdateColor(Color color)
        {

            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
