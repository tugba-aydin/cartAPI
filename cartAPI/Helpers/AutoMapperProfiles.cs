using AutoMapper;
using cartAPI.Dtos;
using cartAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cartAPI.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Cart, CartForAddingDto>();
        }
    }
}
