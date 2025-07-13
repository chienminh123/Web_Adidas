using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Adidas.Models
{
    [Table("ChiTietDonHang")]
    public class ChiTietDonHang
    {
        [Key]
        public int MaChiTietDonHAng { get; set; }
       
        [Required]
        public int SoLuong { get; set; }
        [Required]
        public double DonGia { get; set; }
        // Foreign Key properties: Khóa ngoại tới SanPham và DonHang
        public int MaSanPham { get; set; }
        public int MaDonHang { get; set; } // MaDonHang là string trong DonHang

        // Navigation properties: Tham chiếu đến các đối tượng liên quan
        [ForeignKey("MaSanPham")]
        public SanPham SanPham { get; set; }

        [ForeignKey("MaDonHang")]
        public DonHang DonHang { get; set; }
    }
}
