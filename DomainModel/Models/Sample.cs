namespace DomainModel.Models;

public class Sample
{
    public int SampleId { get; set; }
    public string Barcode { get; set; } = string.Empty;
    public int TestRequestId { get; set; }
    public TestRequest? TestRequest { get; set; }
    public int SampleTypeId { get; set; }
    public SampleType? SampleType { get; set; }
    public int LaboratoryDepartmentId { get; set; }
    public LaboratoryDepartment? LaboratoryDepartment { get; set; }
    public int StatusId { get; set; }
    public Status? Status { get; set; }
    public int? CollectedByEmployeeId { get; set; }
    public Employee? CollectedByEmployee { get; set; }
    public DateTime? CollectedAtUtc { get; set; }
    public string? RejectionReason { get; set; }
    public byte[] RowVersion { get; set; } = Array.Empty<byte>();

    public ICollection<TestRequestItem> TestRequestItems { get; set; } = new List<TestRequestItem>();
}
