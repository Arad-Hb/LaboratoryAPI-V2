namespace DomainModel.Models;

public class Patient 
{
    public int PatientId { get; set; }
    public string? NationalCode { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Mobile { get; set; }
    public DateOnly? BirthDate { get; set; }
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public int RegisteredByEmployeeId { get; set; } 
    public Employee RegisteredByEmployee { get; set; } = null!; 

    public string FullName => $"{FirstName} {LastName}".Trim();

    public ICollection<TestRequest> TestRequests { get; set; } = new List<TestRequest>();
}
