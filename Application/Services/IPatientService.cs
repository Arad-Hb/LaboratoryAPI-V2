using Laboratory.Application.DTOs.Patients;
using Laboratory.Framework.Common;

namespace Laboratory.Application.Services;

public interface IPatientService
{
    Task<OperationResult<PagedResult<PatientListDto>>> GetPagedPatientsAsync(PageRequest request, CancellationToken cancellationToken);
    Task<OperationResult<PatientDetailsDto>> GetPatientByIdAsync(int id, CancellationToken cancellationToken);
    Task<OperationResult<PatientDetailsDto>> GetPatientByNationalCodeAsync(string nationalCode, CancellationToken cancellationToken);
    Task<OperationResult<PatientDetailsDto>> CreatePatientAsync(PatientCreateDto model, int employeeId, CancellationToken cancellationToken);
    Task<OperationResult<PatientDetailsDto>> UpdatePatientAsync(int id, PatientUpdateDto model, CancellationToken cancellationToken);
    Task<OperationResult> DeletePatientAsync(int id, CancellationToken cancellationToken);
}
