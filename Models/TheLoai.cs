using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Adidas.Models
{
    [Table("TheLoai")]
    public class TheLoai
    {
        [Key]
        public int MaTheLoai { get; set; }
        [MaxLength(50)]
        public string? TenTheLoai { get; set; }
        public List<SanPham> SanPhams { get; set; }
    }
}
