using FinanceService.Contracts.ApiModels;

namespace FinanceService.Contracts.Response;

public class GetReportByIdResponse
{
    public Guid Id { get; set; }
    
    public DateOnly Date { get; set; }
    
    public ICollection<RevenueApiModel> Revenues { get; set; }
    
    public ICollection<CostApiModel> Costs { get; set; }
    
    public double TotalRevenue { get; set; }
    
    public double TotalCost { get; set; }
}