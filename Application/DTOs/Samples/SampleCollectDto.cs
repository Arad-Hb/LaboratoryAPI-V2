using System.ComponentModel.DataAnnotations;

namespace Laboratory.Application.DTOs.Samples;

public class SampleCollectDto
{
    [Range(1, int.MaxValue)]
    public int SampleId { get; set; }

    [MaxLength(50)]
    public string? Barcode { get; set; }
}
