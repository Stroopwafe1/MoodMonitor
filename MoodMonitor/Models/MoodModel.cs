using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MoodMonitor.Models;

public class MoodModel {
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int ID { get; set; }

	public string UserID { get; set; }

	[Range(1, 100)] [Required] public int Happiness { get; set; }

	[Range(1, 100)] [Required] public int Sadness { get; set; }

	[Range(1, 100)] [Required] public int Fear { get; set; }

	[Range(1, 100)] [Required] public int Anger { get; set; }

	[Range(1, 100)] [Required] public int Stress { get; set; }

	[Range(1, 100)] [Required] public int Emptiness { get; set; }

	[Required] [MaxLength(500)] public string Notes { get; set; }

	[Required]
	[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
	[DataType(DataType.Date)]
	public DateTime CreatedAt { get; set; } = DateTime.Now;
}