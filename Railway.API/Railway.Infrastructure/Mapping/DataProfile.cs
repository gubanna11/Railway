using AutoMapper;
using Railway.Core.Entities;
using Railway.Infrastructure.Dtos;
using Railway.Infrastructure.Dtos.CreateDtos;
using Railway.Infrastructure.Dtos.Registration;
using System.Linq;

namespace Railway.Infrastructure.Mapping;

public class DataProfile : Profile
{
    public DataProfile()
    {
        CreateMap<CreateRouteDto, Route>()
            .ForMember(dest => dest.RouteDetails, opt => opt.Ignore())
            .ForMember(dest => dest.RouteStops, opt => opt.Ignore())
            .ForMember(dest => dest.FromStationTrack, opt => opt.Ignore())
            .ForMember(dest => dest.ToStationTrack, opt => opt.Ignore());

        //CreateMap<ICollection<Schedule>, ScheduleDto>()
        //    .ForMember(dest => dest.Frequencies, opt => opt.MapFrom(src =>
        //      src.Select(s => s.Frequency).ToList()));

        CreateMap<Route, RouteDto>()
            .ForMember(dest => dest.Schedule, opt => opt.MapFrom(src =>
                 new ScheduleDto
                 {
                     RouteId = src.Id,
                     Frequencies = src.Schedules.Select(s => s.Frequency).ToList()
                 }));

        CreateMap<CreateRouteStopDto, RouteStop>()
            .ForMember(dest => dest.StationTrack, opt => opt.Ignore());

        CreateMap<CreateRouteDetailDto, RouteDetail>();

        CreateMap<Train, TrainDto>()
            .ReverseMap();

        CreateMap<TrainType, TrainTypeDto>()
           .ForMember(dest => dest.CoachTypes, s => s.MapFrom(s => s.TrainTypeDetails.Select(td => td.CoachType)))
           .ReverseMap();

        CreateMap<Locality, LocalityDto>()
            .ReverseMap();

        CreateMap<Station, StationDto>()
            .ReverseMap();


        CreateMap<CreateTicketDto, Ticket>();

        CreateMap<TicketDto, Ticket>()
            .ForMember(dest => dest.TicketOptions, s => s.MapFrom(s => s.Options.Select(o => new TicketOption
            {
                OptionId = o.Id
            })));

        CreateMap<Ticket, TicketDto>()
           .ForMember(dest => dest.Options, s => s.MapFrom(s => s.TicketOptions.Select(o => new OptionDto
           {
               Id = o.OptionId,
               ExtraCharge = o.Option.ExtraCharge,
               Name = o.Option.Name,
           })));

        CreateMap<TicketOptionDto, TicketOption>()
            .ReverseMap();

        CreateMap<OptionDto, Option>()
            .ReverseMap();


        CreateMap<UserForRegistrationDto, User>()
             .ForMember(u => u.UserName, opt => opt.MapFrom(dto => dto.Email));
    }
}