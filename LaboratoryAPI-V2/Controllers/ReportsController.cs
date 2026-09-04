using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Laboratory.Application.Services;

namespace Laboratory.Api.Controllers;

public class ReportsController : BaseApiController
{
    private readonly IReportService _reportService;

    public ReportsController(IReportService reportService)
    {
        _reportService = reportService;
    }

    /// <summary>
    /// کارتابل بخش با اجرای Stored Procedure (usp_GetDepartmentWorkList)
    /// </summary>
    [Authorize(Roles = "LabTechnician,SystemAdmin")]
    [HttpGet("department-worklist/{departmentId:int}")]
    public async Task<IActionResult> GetDepartmentWorkListAsync(
        int departmentId, 
        [FromQuery] int pageNumber = 1, 
        [FromQuery] int pageSize = 20, 
        CancellationToken cancellationToken = default)
    {
        var result = await _reportService.GetDepartmentWorkListAsync(departmentId, pageNumber, pageSize, cancellationToken);
        return HandleResult(result);
    }

    /// <summary>
    /// جوابیه رسمی و گزارش نهایی آزمایش با اجرای Stored Procedure (usp_GetFinalReport)
    /// </summary>
    [Authorize(Roles = "Receptionist,TechnicalManager,SystemAdmin")]
    [HttpGet("final-report/{testRequestId:int}")]
    public async Task<IActionResult> GetFinalReportAsync(int testRequestId, CancellationToken cancellationToken)
    {
        var result = await _reportService.GetFinalReportAsync(testRequestId, cancellationToken);
        return HandleResult(result);
    }

    /// <summary>
    /// آمار روزانه آزمایشگاه با اجرای Stored Procedure (usp_GetDailyLaboratoryStatistics)
    /// </summary>
    [Authorize(Roles = "TechnicalManager,SystemAdmin")]
    [HttpGet("daily-statistics")]
    public async Task<IActionResult> GetDailyStatisticsAsync(
        [FromQuery] DateTime? fromDate, 
        [FromQuery] DateTime? toDate, 
        CancellationToken cancellationToken = default)
    {
        var from = fromDate ?? DateTime.UtcNow.AddDays(-30);
        var to = toDate ?? DateTime.UtcNow;

        var result = await _reportService.GetDailyStatisticsAsync(from, to, cancellationToken);
        return HandleResult(result);
    }
}
