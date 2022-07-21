using System.ComponentModel.DataAnnotations;

namespace WebApplicationRazor.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public string? Make { get; set; }
        [Required]
        public string? Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int Doors { get; set; }
        [Required]
        public string? Color { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
		public bool ShowPrice { get; set; }
    }
}
