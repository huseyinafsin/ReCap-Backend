using Entities.Concrete;
using System.Collections.Generic;
using Core.Entities;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAllColors();
        IResult AddColor(Color color);
        IResult DeleteColor(Color color);
        IResult UpdateColor(Color color);
        IDataResult<Color> GetColorById(int colorId);
    }
}
