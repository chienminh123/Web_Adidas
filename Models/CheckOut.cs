using System.ComponentModel.DataAnnotations;

namespace Web_Adidas.Models
{
    public class CheckOut 
    {

        [Required]
        [MaxLength(100)]
        public string? name { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string? Sdt { get; set; }
        [Required]
        public string? DiaChi { get; set; }
        [Required]
        public string? PtThanhToan { get; set; }
        //public virtual ICollection<ChiTietGioHang> ChiTietGioHangs { get; set; }
        
    }
}
