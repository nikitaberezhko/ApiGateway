using AutoMapper;
using ContainerService.Contracts.Request.Container;
using ContainerService.Contracts.Request.Type;
using Infrastructure.RefitClients;
using Services.Models.OtherModels;
using Services.Models.Request;
using Services.Models.Response;
using Services.Services.Interfaces;

namespace Services.Services;

public class CompositeContainerFacade(
    IContainerApi containerApi,
    IMapper mapper) : ICompositeContainerFacade
{
    public async Task<CompositeContainerModel> CompositeContainerWithType(
        GetCompositeContainerModel model)
    {
        var container = 
            await containerApi.GetContainerById(new GetContainerByIdRequest
        { Id = model.Id });
        
        var type = 
            await containerApi.GetTypeById(new GetTypeByIdRequest
        { Id = container.Data!.TypeId });

        var result = mapper.Map<CompositeContainerModel>(container.Data);
        result.Type = mapper.Map<TypeModel>(type.Data);
        
        return result;
    }
}