using System.ComponentModel.DataAnnotations;

namespace Laboratory.Application.DTOs.Patients;

public class PatientCreateDto
{
    [MaxLength(20)]
    public string? NationalCode { get; set; }

    [Required]
    [MaxLength(80)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(20)]
    public string? Mobile { get; set; }

    public DateOnly? BirthDate { get; set; }
}
