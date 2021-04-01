using AutoMapper;
using ChallengeNetCore.Web.Business;
using ChallengeNetCore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeNetCore.Web.Client.Models
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<PriceListDto, PriceList>()
                .ForPath(o => o.Product.Name, source => source.MapFrom(s => s.ProductName))
                .ForPath(d => d.Product.Category.Name, source => source.MapFrom(s => s.CategoryName));
        }
    }
}