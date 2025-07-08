using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Adidas.Models
{
    [Table("ChiTietGioHang")]
    public class ChiTietGioHang
    {
        [Key]
        public int MaChiTietGioHang { get; set; }
       
        [Required]
        public int SoLuong { get; set; }
        [Required]
        public double DonGia { get; set; }

        public int MaGioHang { get; set; }
        public int MaSanPham { get; set; }

        // Navigation properties: Tham chiếu đến các đối tượng liên quan
        [ForeignKey("MaGioHang")]
        public GioHang GioHang { get; set; }

        [ForeignKey("MaSanPham")]
        public SanPham SanPham { get; set; }

    }
}
