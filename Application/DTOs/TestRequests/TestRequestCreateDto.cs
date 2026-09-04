using System.ComponentModel.DataAnnotations;

namespace Laboratory.Application.DTOs.TestRequests;

public class TestRequestCreateDto
{
    [Range(1, int.MaxValue)]
    public int PatientId { get; set; }

    [Required]
    [MinLength(1)]
    public IReadOnlyList<int> LaboratoryTestIds { get; set; } = Array.Empty<int>();
}
