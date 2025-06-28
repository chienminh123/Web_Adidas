using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Adidas.Models
{
    [Table("ChiTietGioHang")]
    public class ChiTietGioHang
    {
        [Key]
        public int MaChiTietGioHang { get; set; }
        //[Required]
        //public int MaGioHang { get; set; }
        //[Required]
        //public int MaSanPhan { get; set; }
        [Required]
        public int SoLuong { get; set; }
        [Required]
        public double DonGia { get; set; }

        public GioHang GioHang { get; set; }
        public SanPham SanPham { get; set; }

    }
}
