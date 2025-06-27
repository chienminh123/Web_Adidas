using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Adidas.Data
{
    [Table("DonHang")]
    public class DonHang
    {
        [Key]
        public int MaDonHang { get; set; }
        [Required]
        public string MaNguoiDung { get; set; }
        public DateTime NgayTaoDonHang { get; set; } = DateTime.UtcNow;
        [Required]
        public int MaTrangThaiDonHang { get; set; }
        public bool DaXoa { get; set; } = false;
        public TrangThaiDonHang TrangThaiDonHang { get; set; }
        public List<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
