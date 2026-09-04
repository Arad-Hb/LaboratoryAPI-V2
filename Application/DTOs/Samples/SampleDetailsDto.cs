namespace Laboratory.Application.DTOs.Samples;

public class SampleListDto
{
    public int SampleId { get; set; }
    public string Barcode { get; set; } = string.Empty;
    public int TestRequestId { get; set; }
    public int SampleTypeId { get; set; }
    public int LaboratoryDepartmentId { get; set; }
    public int StatusId { get; set; }
    public string StatusTitle { get; set; } = string.Empty;
    public int? CollectedByEmployeeId { get; set; }
    public DateTime? CollectedAtUtc { get; set; }
}

public class SampleDetailsDto
{
    public int SampleId { get; set; }
    public string Barcode { get; set; } = string.Empty;
    public int TestRequestId { get; set; }
    public string RequestNumber { get; set; } = string.Empty;
    public int SampleTypeId { get; set; }
    public string SampleTypeName { get; set; } = string.Empty;
    public int LaboratoryDepartmentId { get; set; }
    public string DepartmentName { get; set; } = string.Empty;
    public int StatusId { get; set; }
    public string StatusTitle { get; set; } = string.Empty;
    public int? CollectedByEmployeeId { get; set; }
    public string? CollectedByEmployeeName { get; set; }
    public DateTime? CollectedAtUtc { get; set; }
    public string? RejectionReason { get; set; }
}
