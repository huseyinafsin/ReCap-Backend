using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<CarCreateDto>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).NotEmpty();
            RuleFor(c => c.Model).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.FuelTypeId).NotNull();
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.CarTypeId).NotEmpty();
            RuleFor(c => c.GearTypeId).NotEmpty();
            RuleFor(c => c.MinFindexScore).NotEmpty();

        }


    }
}
