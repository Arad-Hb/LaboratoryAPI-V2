using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Laboratory.Application.Services;

namespace Laboratory.Api.Controllers;

[Authorize(Roles = "Receptionist,Sampler,LabTechnician,TechnicalManager,SystemAdmin")]
public class LookupsController : BaseApiController
{
    private readonly ILaboratoryLookupService _lookupService;

    public LookupsController(ILaboratoryLookupService lookupService)
    {
        _lookupService = lookupService;
    }

    [HttpGet("departments")]
    public async Task<IActionResult> GetDepartmentsAsync(CancellationToken cancellationToken)
    {
        var result = await _lookupService.GetDepartmentsAsync(cancellationToken);
        return HandleResult(result);
    }

    [HttpGet("sample-types")]
    public async Task<IActionResult> GetSampleTypesAsync(CancellationToken cancellationToken)
    {
        var result = await _lookupService.GetSampleTypesAsync(cancellationToken);
        return HandleResult(result);
    }

    [HttpGet("laboratory-tests")]
    public async Task<IActionResult> GetLaboratoryTestsAsync([FromQuery] int? departmentId, CancellationToken cancellationToken)
    {
        var result = await _lookupService.GetLaboratoryTestsAsync(departmentId, cancellationToken);
        return HandleResult(result);
    }

    [HttpGet("statuses/{entityName}")]
    public async Task<IActionResult> GetStatusesByEntityAsync(string entityName, CancellationToken cancellationToken)
    {
        var result = await _lookupService.GetStatusesByEntityAsync(entityName, cancellationToken);
        return HandleResult(result);
    }
}
