using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Web_Adidas.Models
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        public int MaSanPham { get; set; }
        [MaxLength(50)]
        public string? TenSanPham  { get; set; }
        public string Size { get; set; }
        [Required]
        public int SoLuong { get; set; }
        [Required]
        public double Gia { get; set; }

        public string? HinhAnh { get; set; }
        
        public int MaTheLoai { get; set; }

        // Navigation property: Tham chiếu đến đối tượng TheLoai
        [ForeignKey("MaTheLoai")]
        public TheLoai TheLoai { get; set; }

        // Navigation collections: Một sản phẩm có thể có trong nhiều chi tiết giỏ hàng và chi tiết đơn hàng
        public List<ChiTietGioHang> ChiTietGioHangs { get; set; } = new List<ChiTietGioHang>();
        public List<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();

        [NotMapped] // Thuộc tính này không được ánh xạ vào cơ sở dữ liệu
        public string TenTheLoai { get; set; }
    }
}
