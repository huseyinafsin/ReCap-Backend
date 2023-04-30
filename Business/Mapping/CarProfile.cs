using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarCreateDto>()
                .ForMember(x => x.CarName, cd => cd.MapFrom(map => map.CarName))
                .ForMember(x => x.ColorId, cd => cd.MapFrom(map => map.ColorId))
                .ForMember(x => x.BrandId, cd => cd.MapFrom(map => map.BrandId))
                .ForMember(x => x.GearTypeId, cd => cd.MapFrom(map => map.GearTypeId))
                .ForMember(x => x.FuelTypeId, cd => cd.MapFrom(map => map.FuelTypeId))
                .ForMember(x => x.CarTypeId, cd => cd.MapFrom(map => map.CarTypeId))
                .ForMember(x => x.InsertedUserId, cd => cd.MapFrom(map => map.InsertedUserId))
                .ForMember(x => x.MinFindexScore, cd => cd.MapFrom(map => map.MinFindexScore))
                .ForMember(x => x.Model, cd => cd.MapFrom(map => map.Model))
                .ForMember(x => x.Description, cd => cd.MapFrom(map => map.Description)
                ).ReverseMap();


            CreateMap<Car, CarUpdateDto>()
               .ForMember(x => x.Id, cd => cd.MapFrom(map => map.Id))
               .ForMember(x => x.CarName, cd => cd.MapFrom(map => map.CarName))
               .ForMember(x => x.ColorId, cd => cd.MapFrom(map => map.ColorId))
               .ForMember(x => x.BrandId, cd => cd.MapFrom(map => map.BrandId))
               .ForMember(x => x.GearTypeId, cd => cd.MapFrom(map => map.GearTypeId))
               .ForMember(x => x.FuelTypeId, cd => cd.MapFrom(map => map.FuelTypeId))
               .ForMember(x => x.CarTypeId, cd => cd.MapFrom(map => map.CarTypeId))
               .ForMember(x => x.InsertedUserId, cd => cd.MapFrom(map => map.InsertedUserId))
               .ForMember(x => x.MinFindexScore, cd => cd.MapFrom(map => map.MinFindexScore))
               .ForMember(x => x.Model, cd => cd.MapFrom(map => map.Model))
               .ForMember(x => x.Description, cd => cd.MapFrom(map => map.Description)
               ).ReverseMap();

        }
    }
}
