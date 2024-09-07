using Services.Models.Request;
using Services.Models.Response;

namespace Services.Services.Interfaces;

public interface ICompositeContainerFacade
{
    Task<CompositeContainerModel> CompositeContainerWithType
        (GetCompositeContainerModel model);
}