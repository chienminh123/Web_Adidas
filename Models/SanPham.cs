using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web_Adidas.Data;

namespace Web_Adidas.Models
{
    [Table("Sach")]
    public class SanPham
    {
        [Key]
        public int MaSanPham { get; set; }
        [MaxLength(50)]
        public string? TenSanPham  { get; set; }
        public float Size { get; set; }
        [Required]
        public double Gia { get; set; }
        public string? HinhAnh { get; set; }
        [Required]
        public int MaTheLoai { get; set; }
        public TheLoai TheLoai { get; set; }
        public List<ChiTietGioHang> ChiTietGioHangs { get; set; }
        public List<ChiTietDonHang> ChiTietDonHangs { get; set; }
        [NotMapped]
        public string TenTheLoai { get; set; }
    }
}
