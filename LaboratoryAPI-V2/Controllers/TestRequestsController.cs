using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Laboratory.Application.DTOs.TestRequests;
using Laboratory.Application.Services;
using Laboratory.Framework.Common;

namespace Laboratory.Api.Controllers;

public class TestRequestsController : BaseApiController
{
    private readonly ITestRequestService _requestService;

    public TestRequestsController(ITestRequestService requestService)
    {
        _requestService = requestService;
    }

    [Authorize(Roles = "Receptionist,TechnicalManager,SystemAdmin")]
    [HttpGet("get-paged-list")]
    public async Task<IActionResult> GetPagedRequestsAsync([FromQuery] PageRequest request, [FromQuery] int? statusId, CancellationToken cancellationToken)
    {
        var result = await _requestService.GetPagedTestRequestsAsync(request, statusId, cancellationToken);
        return HandleResult(result);
    }

    [Authorize(Roles = "Receptionist,TechnicalManager,SystemAdmin")]
    [HttpGet("get-by-id/{id:int}")]
    public async Task<IActionResult> GetRequestByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _requestService.GetTestRequestByIdAsync(id, cancellationToken);
        return HandleResult(result);
    }

    [Authorize(Roles = "Receptionist,TechnicalManager,SystemAdmin")]
    [HttpGet("get-by-number/{requestNumber}")]
    public async Task<IActionResult> GetRequestByNumberAsync(string requestNumber, CancellationToken cancellationToken)
    {
        var result = await _requestService.GetTestRequestByNumberAsync(requestNumber, cancellationToken);
        return HandleResult(result);
    }

    [Authorize(Roles = "Receptionist,SystemAdmin")]
    [HttpPost("create-request")]
    public async Task<IActionResult> CreateRequestAsync([FromBody] TestRequestCreateDto model, CancellationToken cancellationToken)
    {
        int employeeId = GetCurrentEmployeeId();
        var result = await _requestService.CreateTestRequestAsync(model, employeeId, cancellationToken);
        return HandleResult(result);
    }

    [Authorize(Roles = "Receptionist,SystemAdmin")]
    [HttpPost("cancel-request/{id:int}")]
    public async Task<IActionResult> CancelRequestAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _requestService.CancelTestRequestAsync(id, cancellationToken);
        return HandleResult(result);
    }
}
