using System;
using System.ComponentModel.DataAnnotations;

namespace MoiService.Models;

public class Province
{
	[Key]
	public Guid ProvinceId { get; set; }
	[Required]
	[MaxLength(100)]
	public string NameKh { get; set; }
    [MaxLength(100)]
    public string NameEn { get; set; }
    [MaxLength(20)]
	[Phone]
    public string ContactNumer { get; set; }
	public string Lat { get; set; }
	public string Lon { get; set; }
}

