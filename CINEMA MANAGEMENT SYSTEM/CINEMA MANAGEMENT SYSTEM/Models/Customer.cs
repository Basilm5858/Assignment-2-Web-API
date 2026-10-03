using System.ComponentModel.DataAnnotations;

namespace CINEMA_MANAGEMENT_SYSTEM.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}