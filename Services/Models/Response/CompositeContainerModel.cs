using Services.Models.OtherModels;

namespace Services.Models.Response;

public class CompositeContainerModel
{
    public Guid Id { get; set; }

    public string IsoNumber { get; set; }

    public int TypeId { get; set; }

    public bool IsEngaged { get; set; }

    public DateTime? EngagedUntil { get; set; }
    
    public TypeModel Type { get; set; }
}