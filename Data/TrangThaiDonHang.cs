using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Adidas.Data
{
    [Table("TrangThaiDonHang")]
    public class TrangThaiDonHang
    {
        [Key]
        public int MaTrangThaiDonHang { get; set; }
        [Required]
        [MaxLength(50)]
        public string? TenTrangThaiDonHang { get; set; }
    }
}
