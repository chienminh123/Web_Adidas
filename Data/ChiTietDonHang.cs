using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web_Adidas.Models;

namespace Web_Adidas.Data
{
    [Table("ChiTietDonHang")]
    public class ChiTietDonHang
    {
        [Key]
        public int MaChiTietDonHAng { get; set; }
        [Required]
        public int MaDonHang { get; set; }
        [Required]
        public int MaSanPham { get; set; }
        [Required]
        public int SoLuong { get; set; }
        [Required]
        public double DonGia { get; set; }
        public SanPham Sach { get; set; }
        public DonHang DonHang { get; set; }
    }
}
