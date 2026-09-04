using Laboratory.Application.DTOs.Patients;
using Laboratory.Application.Services;
using Laboratory.Framework.Common;

namespace Laboratory.ApplicationService;

public class PatientService : IPatientService
{
    public Task<OperationResult<PagedResult<PatientListDto>>> GetPagedPatientsAsync(PageRequest request, CancellationToken cancellationToken)
        => NotImplemented<PagedResult<PatientListDto>>();

    public Task<OperationResult<PatientDetailsDto>> GetPatientByIdAsync(int id, CancellationToken cancellationToken)
        => NotImplemented<PatientDetailsDto>();

    public Task<OperationResult<PatientDetailsDto>> GetPatientByNationalCodeAsync(string nationalCode, CancellationToken cancellationToken)
        => NotImplemented<PatientDetailsDto>();

    public Task<OperationResult<PatientDetailsDto>> CreatePatientAsync(PatientCreateDto model, int employeeId, CancellationToken cancellationToken)
        => NotImplemented<PatientDetailsDto>();

    public Task<OperationResult<PatientDetailsDto>> UpdatePatientAsync(int id, PatientUpdateDto model, CancellationToken cancellationToken)
        => NotImplemented<PatientDetailsDto>();

    public Task<OperationResult> DeletePatientAsync(int id, CancellationToken cancellationToken)
        => Task.FromResult(OperationResult.Failure("سرویس هنوز پیاده‌سازی نشده است.", 501));

    private static Task<OperationResult<T>> NotImplemented<T>()
        => Task.FromResult(OperationResult<T>.Failure("سرویس هنوز پیاده‌سازی نشده است.", 501));
}
