namespace ContainerService.Contracts.Request.Container;

public class GetContainersByTypeIdRequest
{
    public int TypeId { get; set; }
    
    public int Page { get; set; }
    
    public int PageSize { get; set; }
}