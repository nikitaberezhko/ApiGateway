namespace FinanceService.Contracts.ApiModels;

public class CostApiModel
{
    public Guid Id { get; set; }
    
    public Guid OrderId { get; set; }
    
    public double Amount { get; set; }
}