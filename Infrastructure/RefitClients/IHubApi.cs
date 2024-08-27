using CommonModel.Contracts;
using HubService.Contracts.Request;
using HubService.Contracts.Response;
using Refit;

namespace Infrastructure.RefitClients;

public interface IHubApi
{
    [Post("/api/v1/hubs")]
    Task<CommonResponse<CreateHubResponse>> CreateHub([Body] CreateHubRequest request);
    
    [Put("/api/v1/hubs")]
    Task<CommonResponse<UpdateHubResponse>> UpdateHub([Body] UpdateHubRequest request);
    
    [Delete("/api/v1/hubs/{request.id}")]
    Task<CommonResponse<DeleteHubResponse>> DeleteHub(DeleteHubRequest request);
    
    [Get("/api/v1/hubs/{request.id}")]
    Task<CommonResponse<GetHubByIdResponse>> GetHubById(GetHubByIdRequest request);
    
    [Get("/api/v1/hubs/cities/{request.city}")]
    Task<CommonResponse<GetHubsByCityResponse>> GetHubsByCity(GetHubsByCityRequest request);
    
    [Get("/api/v1/hubs")]
    Task<CommonResponse<GetAllHubsResponse>> GetAllHubs([Query] GetAllHubsRequest request);
}