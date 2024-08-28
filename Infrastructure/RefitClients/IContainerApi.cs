using CommonModel.Contracts;
using ContainerService.Contracts.Request.Container;
using ContainerService.Contracts.Request.Price;
using ContainerService.Contracts.Request.Type;
using ContainerService.Contracts.Response.Container;
using ContainerService.Contracts.Response.Price;
using ContainerService.Contracts.Response.Type;
using Refit;

namespace Infrastructure.RefitClients;

public interface IContainerApi
{
    // Containers
    [Post("/api/v1/containers")]
    Task<CommonResponse<CreateContainerResponse>> CreateContainer(
        [Body] CreateContainerRequest request);

    [Put("/api/v1/containers")]
    Task<CommonResponse<UpdateContainerResponse>> UpdateContainer(
        [Body] UpdateContainerRequest request);
    
    [Delete("/api/v1/containers/{request.Id}")]
    Task<CommonResponse<DeleteContainerResponse>> DeleteContainer(
        DeleteContainerRequest request);
    
    [Get("/api/v1/containers/{request.Id}")]
    Task<CommonResponse<GetContainerByIdResponse>> GetContainerById(
        GetContainerByIdRequest request);
    
    [Get("/api/v1/containers")]
    Task<CommonResponse<GetContainersByTypeIdResponse>> GetContainersByTypeId(
        [Body] GetContainersByTypeIdRequest request);
    
    [Get("/api/v1/containers/iso-numbers/{request.IsoNumber}")]
    Task<CommonResponse<GetContainerByIsoResponse>> GetContainerByIso(
        GetContainerByIsoRequest request);
    
    
    // Price
    [Get("/api/v1/price")]
    Task<CommonResponse<GetContainersPriceResponse>> GetPrice(
        [Body] GetContainersPriceRequest request);


    // Container types
    [Post("/api/v1/container-types")]
    Task<CommonResponse<CreateTypeResponse>> CreateType([Body] CreateTypeRequest request);
    
    [Put("/api/v1/container-types")]
    Task<CommonResponse<UpdateTypeResponse>> UpdateType([Body] UpdateTypeRequest request);
    
    [Delete("/api/v1/container-types/{request.Id}")]
    Task<CommonResponse<DeleteTypeResponse>> DeleteType(DeleteTypeRequest request);
    
    [Get("/api/v1/container-types/{request.Id}")]
    Task<CommonResponse<GetTypeByIdResponse>> GetTypeById(GetTypeByIdRequest request);
    
    [Get("/api/v1/container-types")]
    Task<CommonResponse<GetAllTypesResponse>> GetAllTypes([Query] GetAllTypesRequest request);
}