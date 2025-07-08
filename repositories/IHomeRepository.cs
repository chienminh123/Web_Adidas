using Web_Adidas.Models;

namespace Web_Adidas.repositories
{
    public interface IHomeRepository
    {
        Task<IEnumerable<SanPham>> GetSanPham(string keySeach = "", int MaTheLoai = 0);
        Task<IEnumerable<TheLoai>> TheLoais();
    }
}
