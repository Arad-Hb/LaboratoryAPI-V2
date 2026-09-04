namespace Laboratory.Application.DTOs.Patients;

public class PatientListDto
{
    public int PatientId { get; set; }
    public string? NationalCode { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string? Mobile { get; set; }
    public DateOnly? BirthDate { get; set; }
    public int RegisteredByEmployeeId { get; set; }
    public DateTime CreatedAtUtc { get; set; }
}
