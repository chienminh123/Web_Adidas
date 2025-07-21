using Web_Adidas.Models;

namespace Web_Adidas.repositories
{
    public interface IHomeRepository
    {
        Task<IEnumerable<SanPham>> SearchProducts(string query);
        Task<IEnumerable<SanPham>> SapXep(int maTheLoai, string filter = "");
    }
}
