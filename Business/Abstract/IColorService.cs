using Entities.Concrete;
using System.Collections.Generic;
using Core.Entities;
using Core.Utilities.Results;
using System;
using Entities.DTOs;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        Task<IDataResult<List<Color>>> GetAllColorsAsync();
        IResult AddColor(ColorDto color);
        Task<IResult> DeleteColor(Guid id);
        IResult UpdateColor(Color color);
        Task<IDataResult<Color>> GetColorById(Guid colorId);
    }
}
