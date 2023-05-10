using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoiService.Models;

public class District
{
    public Guid DistrictId { get; set; }
    [ForeignKey("Province")]
    public Guid ProvinceId { get; set; }
    [Required]
    [MaxLength(100)]
    public string NameKh { get; set; }
    [MaxLength(100)]
    public string NameEn { get; set; }
    [MaxLength(20)]
    [Phone]
    public string ContactNumer { get; set; }
    public Province Province { get; set; }
}

