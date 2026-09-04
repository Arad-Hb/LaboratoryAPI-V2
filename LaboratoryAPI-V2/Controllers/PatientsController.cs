using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Laboratory.Application.DTOs.Patients;
using Laboratory.Application.Services;
using Laboratory.Framework.Common;

namespace Laboratory.Api.Controllers;

public class PatientsController : BaseApiController
{
    private readonly IPatientService _patientService;

    public PatientsController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [Authorize(Roles = "Receptionist,TechnicalManager,SystemAdmin")]
    [HttpGet("get-paged-list")]
    public async Task<IActionResult> GetPagedPatientsAsync([FromQuery] PageRequest request, CancellationToken cancellationToken)
    {
        var result = await _patientService.GetPagedPatientsAsync(request, cancellationToken);
        return HandleResult(result);
    }

    [Authorize(Roles = "Receptionist,SystemAdmin")]
    [HttpGet("get-by-id/{id:int}")]
    public async Task<IActionResult> GetPatientByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _patientService.GetPatientByIdAsync(id, cancellationToken);
        return HandleResult(result);
    }

    [Authorize(Roles = "Receptionist,SystemAdmin")]
    [HttpGet("get-by-national-code/{nationalCode}")]
    public async Task<IActionResult> GetPatientByNationalCodeAsync(string nationalCode, CancellationToken cancellationToken)
    {
        var result = await _patientService.GetPatientByNationalCodeAsync(nationalCode, cancellationToken);
        return HandleResult(result);
    }

    [Authorize(Roles = "Receptionist,SystemAdmin")]
    [HttpPost("create-patient")]
    public async Task<IActionResult> CreatePatientAsync([FromBody] PatientCreateDto model, CancellationToken cancellationToken)
    {
        int employeeId = GetCurrentEmployeeId();
        var result = await _patientService.CreatePatientAsync(model, employeeId, cancellationToken);
        return HandleResult(result);
    }

    [Authorize(Roles = "Receptionist,SystemAdmin")]
    [HttpPut("update-patient/{id:int}")]
    public async Task<IActionResult> UpdatePatientAsync(int id, [FromBody] PatientUpdateDto model, CancellationToken cancellationToken)
    {
        var result = await _patientService.UpdatePatientAsync(id, model, cancellationToken);
        return HandleResult(result);
    }

    [Authorize(Roles = "Receptionist,SystemAdmin")]
    [HttpDelete("delete-patient/{id:int}")]
    public async Task<IActionResult> DeletePatientAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _patientService.DeletePatientAsync(id, cancellationToken);
        return HandleResult(result);
    }
}
