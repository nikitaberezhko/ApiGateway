using WebApi.Models.OtherModels;

namespace WebApi.Models.Response;

public class GetCompositeContainerResponse
{
    public Guid Id { get; set; }

    public string IsoNumber { get; set; }

    public int TypeId { get; set; }

    public bool IsEngaged { get; set; }

    public DateTime? EngagedUntil { get; set; }
    
    public TypeApiModel Type { get; set; }
}