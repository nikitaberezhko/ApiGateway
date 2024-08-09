using Asp.Versioning;
using CommonModel.Contracts;
using FinanceService.Contracts.Request;
using FinanceService.Contracts.Response;
using Infrastructure.RefitClients;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v{v:apiVersion}/reports")]
[ApiVersion(1)]
public class ReportController(IFinanceApi financeApi) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CommonResponse<GenerateReportResponse>>> Generate(
        GenerateReportRequest request)
    {
        var response = await financeApi.GenerateReport(request);
        
        return response;
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<CommonResponse<DeleteReportResponse>>> Delete(
        [FromRoute] DeleteReportRequest request)
    {
        var response = await financeApi.DeleteReport(request);
        
        return response;
    }

    [HttpGet]
    public async Task<ActionResult<CommonResponse<GetAllReportsResponse>>> GetAll(
        [FromQuery] GetAllReportsRequest request)
    {
        var response = await financeApi.GetAllReports(request);
        
        return response;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CommonResponse<GetReportByIdResponse>>> GetById(
        [FromRoute] GetReportByIdRequest request)
    {
        var response = await financeApi.GetReportById(request);
        
        return response;
    }
}