using AutoMapper;
using Railway.Core.Entities;
using Railway.Infrastructure.Dtos;
using Railway.Infrastructure.Dtos.CreateDtos;
using System.Linq;

namespace Railway.Infrastructure.Mapping;

public class DataProfile : Profile
{
    public DataProfile()
    {
        CreateMap<CreateRouteDto, Route>()
            .ForMember(dest => dest.RouteDetails, opt => opt.Ignore());

        CreateMap<Route, RouteDto>()
            .ReverseMap();

        CreateMap<CreateRouteDetailDto, RouteDetail>();

        CreateMap<Train, TrainDto>()
            .ReverseMap();

        CreateMap<TrainType, TrainTypeDto>()
           .ForMember(dest => dest.CoachTypes, s => s.MapFrom(s => s.TrainTypeDetails.Select(td => td.CoachType)))
           .ReverseMap();
    }
}