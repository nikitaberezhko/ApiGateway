using AutoMapper;
using Services.Models.OtherModels;
using Services.Models.Request;
using Services.Models.Response;
using WebApi.Models.OtherModels;
using WebApi.Models.Request;
using WebApi.Models.Response;

namespace WebApi.Mapper;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        // Requests -> Request models
        CreateMap<GetCompositeContainerRequest, GetCompositeContainerModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id));


        
        // Response models -> Responses
        CreateMap<CompositeContainerModel, GetCompositeContainerResponse>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.TypeId, map => map.MapFrom(c => c.TypeId))
            .ForMember(d => d.IsoNumber, map => map.MapFrom(c => c.IsoNumber))
            .ForMember(d => d.IsEngaged, map => map.MapFrom(c => c.IsEngaged))
            .ForMember(d => d.EngagedUntil, map => map.MapFrom(c => c.EngagedUntil))
            .ForMember(d => d.Type, map => map.MapFrom(c => c.Type));
        
        CreateMap<TypeModel, TypeApiModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Name, map => map.MapFrom(c => c.Name))
            .ForMember(d => d.PricePerDay, map => map.MapFrom(c => c.PricePerDay));
    }
}