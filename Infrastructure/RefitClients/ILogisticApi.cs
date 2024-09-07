using CommonModel.Contracts;
using LogisticService.Contracts.Request;
using LogisticService.Contracts.Response;
using Refit;

namespace Infrastructure.RefitClients;

public interface ILogisticApi
{
    [Get("/api/v1/locations/{request.Id}")]
    Task<CommonResponse<GetLocationResponse>> GetLocation(GetLocationRequest request);
    
    [Get("/api/v1/locations")]
    Task<CommonResponse<GetContainersLocationResponse>> GetLocationsList(
        [Body] GetContainersLocationRequest request);
    
    [Get("/api/v1/locations/orders/{request.OrderId}")]
    Task<CommonResponse<GetContainersLocationByOrderIdResponse>> GetOrderLocations(
        GetContainersLocationByOrderIdRequest request);
    
    [Put("/api/v1/locations")]
    Task<CommonResponse<UpdateContainersLocationResponse>> UpdateLocationsList(
        [Body] UpdateContainersLocationRequest request);
}