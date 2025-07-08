using System.ComponentModel.DataAnnotations;

namespace Web_Adidas.Models
{
    public class CheckOut
    {
        [Required]
        [MaxLength(20)]
        public string? name { get; set; }
        [Required]
        [EmailAddress]

        public string? Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Sdt { get; set; }
        [Required]
        public string? DiaChi { get; set; }
        [Required]
        public string? PtThanhToan { get; set; }
    }
}
