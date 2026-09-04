using Laboratory.Application.DTOs.Lookups;
using Laboratory.Framework.Common;

namespace Laboratory.Application.Services;

public interface ILaboratoryLookupService
{
    Task<OperationResult<IReadOnlyList<DepartmentLookupDto>>> GetDepartmentsAsync(CancellationToken cancellationToken);
    Task<OperationResult<IReadOnlyList<SampleTypeLookupDto>>> GetSampleTypesAsync(CancellationToken cancellationToken);
    Task<OperationResult<IReadOnlyList<LaboratoryTestLookupDto>>> GetLaboratoryTestsAsync(int? departmentId, CancellationToken cancellationToken);
    Task<OperationResult<IReadOnlyList<StatusLookupDto>>> GetStatusesByEntityAsync(string entityName, CancellationToken cancellationToken);
}
