using Azure_First.Web.Entities;
using Azure_First.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Azure_First.Web.App_Start
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Profile, RandomProfileViewModel>()
                .ForMember(dest => dest.MemberName,
                           opt => opt.MapFrom(src => src.Member.MemberName))
                .ForMember(dest => dest.PhotoUrl,
                           opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p=>p.IsMain).Url));

            });
#pragma warning restore CS0618 // Type or member is obsolete

            //var config = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<Profile, RandomProfileViewModel>());

            //var mapper = config.CreateMapper();

            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Entities.Profile, RandomProfileViewModel>();
            //});
        }
    }
}