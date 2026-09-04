using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Laboratory.Application.DTOs.TestResults;
using Laboratory.Application.Services;

namespace Laboratory.Api.Controllers;

public class TestResultsController : BaseApiController
{
    private readonly ITestResultService _resultService;

    public TestResultsController(ITestResultService resultService)
    {
        _resultService = resultService;
    }

    [Authorize(Roles = "LabTechnician,SystemAdmin")]
    [HttpGet("get-by-item-id/{testRequestItemId:int}")]
    public async Task<IActionResult> GetResultByItemIdAsync(int testRequestItemId, CancellationToken cancellationToken)
    {
        var result = await _resultService.GetResultByItemIdAsync(testRequestItemId, cancellationToken);
        return HandleResult(result);
    }

    [Authorize(Roles = "LabTechnician,SystemAdmin")]
    [HttpPost("save-result")]
    public async Task<IActionResult> SaveResultAsync([FromBody] TestResultSaveDto model, CancellationToken cancellationToken)
    {
        int employeeId = GetCurrentEmployeeId();
        var result = await _resultService.SaveResultAsync(model, employeeId, cancellationToken);
        return HandleResult(result);
    }

    [Authorize(Roles = "TechnicalManager,SystemAdmin")]
    [HttpPost("review-result")]
    public async Task<IActionResult> ReviewResultAsync([FromBody] ResultReviewActionDto model, CancellationToken cancellationToken)
    {
        int employeeId = GetCurrentEmployeeId();
        var result = await _resultService.ReviewResultAsync(model, employeeId, cancellationToken);
        return HandleResult(result);
    }
}
