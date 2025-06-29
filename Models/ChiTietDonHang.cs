using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Adidas.Models
{
    [Table("ChiTietDonHang")]
    public class ChiTietDonHang
    {
        [Key]
        public int MaChiTietDonHAng { get; set; }
        //[Required]
        //public int MaDonHang { get; set; }
        //[Required]
        //public int MaSanPham { get; set; }
        [Required]
        public int SoLuong { get; set; }
        [Required]
        public double DonGia { get; set; }
        public SanPham SanPham { get; set; }
        public DonHang DonHang { get; set; }
    }
}
