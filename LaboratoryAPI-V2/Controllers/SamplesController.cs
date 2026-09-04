using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Laboratory.Application.DTOs.Samples;
using Laboratory.Application.Services;
using Laboratory.Framework.Common;

namespace Laboratory.Api.Controllers;

[Authorize(Roles = "Sampler,SystemAdmin")]
public class SamplesController : BaseApiController
{
    private readonly ISampleService _sampleService;

    public SamplesController(ISampleService sampleService)
    {
        _sampleService = sampleService;
    }

    [HttpGet("get-paged-list")]
    public async Task<IActionResult> GetPagedSamplesAsync(
        [FromQuery] PageRequest request, 
        [FromQuery] int? departmentId, 
        [FromQuery] int? statusId, 
        CancellationToken cancellationToken)
    {
        var result = await _sampleService.GetPagedSamplesAsync(request, departmentId, statusId, cancellationToken);
        return HandleResult(result);
    }

    [HttpGet("get-by-barcode/{barcode}")]
    public async Task<IActionResult> GetSampleByBarcodeAsync(string barcode, CancellationToken cancellationToken)
    {
        var result = await _sampleService.GetSampleByBarcodeAsync(barcode, cancellationToken);
        return HandleResult(result);
    }

    [HttpPost("collect-sample")]
    public async Task<IActionResult> CollectSampleAsync([FromBody] SampleCollectDto model, CancellationToken cancellationToken)
    {
        int employeeId = GetCurrentEmployeeId();
        var result = await _sampleService.CollectSampleAsync(model, employeeId, cancellationToken);
        return HandleResult(result);
    }

    [HttpPost("deliver-sample/{sampleId:int}")]
    public async Task<IActionResult> DeliverSampleAsync(int sampleId, CancellationToken cancellationToken)
    {
        var result = await _sampleService.DeliverSampleToDepartmentAsync(sampleId, cancellationToken);
        return HandleResult(result);
    }

    [HttpPost("reject-sample")]
    public async Task<IActionResult> RejectSampleAsync([FromBody] SampleRejectDto model, CancellationToken cancellationToken)
    {
        var result = await _sampleService.RejectSampleAsync(model, cancellationToken);
        return HandleResult(result);
    }
}
