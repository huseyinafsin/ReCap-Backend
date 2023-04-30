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
using Entities.DTOs;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }


        [CacheRemoveAspect("IColorService.Get")]
        //[SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult AddColor(ColorDto color)
        {
            var newColor = new Color() { Name= color.Name };
            _colorDal.Add(newColor);
            return new SuccessResult(Messages.ColorAdded);
        }

        [CacheRemoveAspect("IColorService.Get")]
        //[SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(ColorValidator))]
        public  IResult DeleteColor(Guid id)
        {
            var color = _colorDal.Get(x=>x.Id==id);
            _colorDal.Remove(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        [CacheAspect]
        //[SecuredOperation("admin,customer")]
        public  IDataResult<IQueryable<Color>> GetAllColorsAsync()
        {
            var result = _colorDal.GetAll();
            return new SuccessDataResult<IQueryable<Color>>(result, Messages.ColorListed);
        }

        [CacheAspect]
        //[SecuredOperation("admin,customer")]
        public IDataResult<Color> GetColorById(Guid colorId)
        {
            return new SuccessDataResult<Color>( _colorDal.Get(c => c.Id == colorId), Messages.ColorFetched);
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
