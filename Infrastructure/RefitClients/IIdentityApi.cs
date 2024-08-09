using CommonModel.Contracts;
using IdentityService.Contracts.Request;
using IdentityService.Contracts.Response;
using Refit;

namespace Infrastructure.RefitClients;

public interface IIdentityApi
{
    [Post("/api/v1/users")]
    Task<CommonResponse<CreateUserResponse>> CreateUser(
        [Body] CreateUserRequest request);
    
    [Post("/api/v1/users/authenticate")]
    Task<CommonResponse<AuthenticateUserResponse>> AuthenticateUser(
        [Body] AuthenticateUserRequest request);
    
    [Post("/api/v1/users/authorize")]
    Task<ApiResponse<CommonResponse<AuthorizeResponse>>> AuthorizeUser(
        [Body] AuthorizeUserRequest request);
    
    [Delete("/api/v1/users/{request.Id}")]
    Task<CommonResponse<DeleteUserResponse>> DeleteUser(DeleteUserRequest request);
}