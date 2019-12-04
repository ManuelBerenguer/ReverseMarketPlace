using AutoMapper;
using ReverseMarketPlace.Demands.Core.Dtos;
using ReverseMarketPlace.Demands.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Mappers
{
    /// <summary>
    /// Class that defines all the auto mappings between objects
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Demands
            CreateMap<Demand, DemandDto>() // Means we want to map from Demand to DemadDto
                .ForMember(d => d.Category, opts => opts.MapFrom(src => src.Category.Name));
            //.ForMember(d => d.Status, opts => opts.MapFrom(src => src.Status) ); 

            // Groups
            CreateMap<Group, GroupDto>() // Means we want to map from Group to GroupDto
                .ForMember(g => g.NumberOfDemands, map => map.MapFrom(src => src.GetNumberOfDemands())); 
        }
    }
}
