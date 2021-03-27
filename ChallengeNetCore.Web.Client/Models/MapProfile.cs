using AutoMapper;
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
            CreateMap<PriceListDto, PriceList>(); // means you want to map from Employee to EmployeeDTO  
            //.ForMember(d => d.Name, source => source.MapFrom(s => s.FirstName + " " + s.LastName))
            //.ForMember(d => d.Address, source => source.MapFrom(s => s.StreetAddress + ", " + s.City + ", " + s.Province + ", " + s.Country))
            //.ForMember(d => d.Phone, source => source.MapFrom(s => s.Phone))
            //.ForMember(d => d.Email, source => source.MapFrom(s => s.Email));
        }
    }
}