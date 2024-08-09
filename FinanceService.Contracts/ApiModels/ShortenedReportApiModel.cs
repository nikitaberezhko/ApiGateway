namespace FinanceService.Contracts.ApiModels;

public class ShortenedReportApiModel
{
    public Guid Id { get; set; }
    
    public DateOnly Date { get; set; }
    
    public double TotalRevenue { get; set; }
    
    public double TotalCost { get; set; }
}