using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web_Adidas.Models;

namespace Web_Adidas.Data
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
