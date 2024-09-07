using AutoMapper;
using ContainerService.Contracts.Response.Container;
using ContainerService.Contracts.Response.Type;
using Services.Models.OtherModels;
using Services.Models.Response;

namespace Services.Mapper;

public class ServiceMappingProfile : Profile
{
    public ServiceMappingProfile()
    {
        // API Responses => Response models
        CreateMap<GetContainerByIdResponse, CompositeContainerModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.TypeId, map => map.MapFrom(c => c.TypeId))
            .ForMember(d => d.IsoNumber, map => map.MapFrom(c => c.IsoNumber))
            .ForMember(d => d.IsEngaged, map => map.MapFrom(c => c.IsEngaged))
            .ForMember(d => d.EngagedUntil, map => map.MapFrom(c => c.EngagedUntil))
            .ForMember(d => d.Type, map => map.Ignore());

        CreateMap<GetTypeByIdResponse, TypeModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.PricePerDay, map => map.MapFrom(c => c.PricePerDay));
    }
}