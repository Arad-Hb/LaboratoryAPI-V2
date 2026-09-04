namespace DomainModel.Models;

public class TestRequest
{
    public int TestRequestId { get; set; }
    public string RequestNumber { get; set; } = string.Empty;
    public int PatientId { get; set; }
    public Patient? Patient { get; set; }
    public int StatusId { get; set; }
    public Status? Status { get; set; }
    //public string RegisteredByUserId { get; set; }
    public int RegisteredByEmployeeId { get; set; }
    public Employee RegisteredByEmployee { get; set; } = null!;
    public DateTime RegisteredAtUtc { get; set; } = DateTime.UtcNow;
    public DateTime? CompletedAtUtc { get; set; }
    public byte[] RowVersion { get; set; } = Array.Empty<byte>();

    public ICollection<Sample> Samples { get; set; } = new List<Sample>();
    public ICollection<TestRequestItem> Items { get; set; } = new List<TestRequestItem>();
}
