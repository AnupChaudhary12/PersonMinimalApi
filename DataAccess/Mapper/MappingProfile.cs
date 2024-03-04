using AutoMapper;
using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Person,PersonGetDTO>().ReverseMap();
            CreateMap<Person,PersonCreateDTO>().ReverseMap();
        }
    }
}
