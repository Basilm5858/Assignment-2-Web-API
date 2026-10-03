using CINEMA_MANAGEMENT_SYSTEM.Models;
using System.ComponentModel.DataAnnotations;

namespace CINEMA_MANAGEMENT_SYSTEM.DTOs
{
    public class EndPoint6DTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();

    }
    public class CreateGenreDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }

    public class UpdateGenreDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
