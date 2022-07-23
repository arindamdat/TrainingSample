using System.ComponentModel.DataAnnotations;

namespace TrainingSample.Models
{
    public class Product
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Stock { get; set; }
    }
}
