using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Adidas.Models
{
    [Table("DonHang")]
    public class DonHang
    {
        [Key]
        public string MaDonHang { get; set; }
        [Required]
        public string MaNguoiDung { get; set; }
        public DateTime NgayTaoDonHang { get; set; } = DateTime.UtcNow;
        //[Required]
        //public int MaTrangThaiDonHang { get; set; }
        public bool DaXoa { get; set; } = false;
        public TrangThaiDonHang TrangThaiDonHang { get; set; }
        [Required]
        [MaxLength(200)]
        public string? DiaChi { get; set; }
        [Required]
        [MaxLength(20)]
        public string? SDT { get; set; }
        [Required]
        [MaxLength(20)]
        public string? PTThanhToan { get; set; }
        public bool ThanhToan { get; set; } = false;
        public List<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
