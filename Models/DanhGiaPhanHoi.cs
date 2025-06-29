using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Adidas.Models
{
    [Table("DanhGiaPhanHoi")]
    public class DanhGiaPhanHoi
    {
        [Key]
        public int Id { get; set; }
        public ChiTietDonHang ChiTietDonHang { get; set; }
        [Required]
        public string? PhanHoi { get; set; }
    }
}
