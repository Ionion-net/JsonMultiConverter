using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JsonMultiConverter.Models;
using JsonMultiConverter.Models.JsonModels;

namespace JsonMultiConverter.Mapping
{
    class JsonMapping : Profile
    {
        public JsonMapping()
        {
            CreateMap<JsonTypeFirstInsurer, Person>()
                .ConstructUsing(x =>
               new Person
               {
                   Name = String.Join(" ", x.FirstName, x.LastName)
               });

            CreateMap<JsonTypeThirdPerson, Person>()
                .ConstructUsing(x =>
               new Person
               {
                   Name = String.Join(" ", x.InsurerFirstName, x.InsurerLastName)
               });

            CreateMap<JsonTypeFirstVehicle, Vehicle>()
                .ConstructUsing(x =>
               new Vehicle
               {
                   MarkName = x.Mark,
                   ModelName = x.Model
               });

            CreateMap<JsonTypeFirst, BasePolicy>()
                .ForMember(x => x.EffectiveDate, o => o.MapFrom(s => Convert.ToDateTime(s.DateBegin)))
                .ForMember(x => x.ExpirationDate, o => o.MapFrom(s => Convert.ToDateTime(s.DateEnd)))
                .ForMember(x => x.Insurer, o => o.MapFrom(s => s.Insurer))
                .ForMember(x => x.Vehicle, o => o.MapFrom(s => s.Vehicle));

            CreateMap<JsonTypeSecond, BasePolicy>()
                .ForMember(x => x.EffectiveDate, o => o.MapFrom(s => Convert.ToDateTime(s.EffectiveDate)))
                .ForMember(x => x.ExpirationDate, o => o.MapFrom(s => Convert.ToDateTime(s.ExpirationDate)))
                .ForMember(x => x.Insurer, o => o.MapFrom(s => new Person
                { Name = String.Join(" ", s.InsurerFirstName, s.InsurerLastName) } ))
                .ForMember(x => x.Vehicle, o => o.MapFrom(s => s.Vehicle));

            CreateMap<JsonTypeThird, BasePolicy>()
                .ForMember(x => x.EffectiveDate, o => o.MapFrom(s => Convert.ToDateTime(s.DateBegin)))
                .ForMember(x => x.ExpirationDate, o => o.MapFrom(s => Convert.ToDateTime(s.DateEnd)))
                .ForMember(x => x.Insurer, o => o.MapFrom(s => s.Insurer.Person))
                .ForMember(x => x.Vehicle, o => o.MapFrom(s => new Vehicle
                {
                    MarkName = s.VehicleMark,
                    ModelName = s.VehicleModel
                }));
        }
    }
}
