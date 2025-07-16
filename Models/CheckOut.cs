using System.ComponentModel.DataAnnotations;

namespace Web_Adidas.Models
{
    public class CheckOut
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        
        [Required]
        [MaxLength(10)]
        public string? Sdt { get; set; }

        [Required]
        public string? DiaChi { get; set; }
        [Required]
        public string? PtThanhToan { get; set; }
    }
}
