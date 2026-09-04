namespace Laboratory.Application.DTOs.TestRequests;

public class TestRequestListDto
{
    public int TestRequestId { get; set; }
    public string RequestNumber { get; set; } = string.Empty;
    public int PatientId { get; set; }
    public string PatientFullName { get; set; } = string.Empty;
    public int StatusId { get; set; }
    public string StatusTitle { get; set; } = string.Empty;
    public int RegisteredByEmployeeId { get; set; }
    public string? RegisteredByEmployeeName { get; set; }
    public DateTime RegisteredAtUtc { get; set; }
    public DateTime? CompletedAtUtc { get; set; }
}
