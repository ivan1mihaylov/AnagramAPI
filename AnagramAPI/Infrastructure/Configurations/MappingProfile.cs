using AutoMapper;
using Domain.DTOs;
using Entity.Entities.Anagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramAPI.Infrastructure.Configurations
{
    internal class MappingProfile : Profile
    {
        /// <summary>
        /// Mapping profile for AutoMapper
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Word, BaseDTO>().ReverseMap();
            CreateMap<CheckResult, ResultDTO>().ReverseMap();
            CreateMap<CheckResult, CheckResultDTO>().ReverseMap();
        }
    }
}
