using System.ComponentModel.DataAnnotations;

namespace Laboratory.Application.DTOs.Samples;

public class SampleRejectDto
{
    [Range(1, int.MaxValue)]
    public int SampleId { get; set; }

    [Required]
    [MaxLength(500)]
    public string RejectionReason { get; set; } = string.Empty;
}
