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
            _colorDal.AddAsync(newColor);
            return new SuccessResult(Messages.ColorAdded);
        }

        [CacheRemoveAspect("IColorService.Get")]
        //[SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(ColorValidator))]
        public async Task<IResult> DeleteColor(Guid id)
        {
            var color =await _colorDal.GetAsync(x=>x.Id==id);
            _colorDal.Remove(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        [CacheAspect]
        //[SecuredOperation("admin,customer")]
        public async Task<IDataResult<List<Color>>> GetAllColorsAsync()
        {
            var result =await _colorDal.GetAll();
            return new SuccessDataResult<List<Color>>(result, Messages.ColorListed);
        }

        [CacheAspect]
        //[SecuredOperation("admin,customer")]
        public async Task<IDataResult<Color>> GetColorById(Guid colorId)
        {
            return new SuccessDataResult<Color>(await _colorDal.GetAsync(c => c.Id == colorId), Messages.ColorFetched);
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
