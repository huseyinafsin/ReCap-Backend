using Entities.Concrete;
using System.Collections.Generic;
using Core.Entities;
using Core.Utilities.Results;
using System;
using Entities.DTOs;
using System.Threading.Tasks;
using System.Linq;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<IQueryable<Color>> GetAllColorsAsync();
        IResult AddColor(ColorDto color);
        IResult DeleteColor(Guid id);
        IResult UpdateColor(Color color);
        IDataResult<Color> GetColorById(Guid colorId);
    }
}
