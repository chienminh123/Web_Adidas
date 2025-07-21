using Web_Adidas.Data;
using Web_Adidas.Models;
using Microsoft.EntityFrameworkCore;

namespace Web_Adidas.repositories
{
    public class HomeRepo : IHomeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SanPham>> GetSanPham(string keySearch = "", int MaTheLoai = 0)
        {
            keySearch = keySearch.ToLower();
            IQueryable<SanPham> query = _dbContext.DbSetSanPham;

            if (!string.IsNullOrWhiteSpace(keySearch))
            {
                query = query.Where(sp => sp.TenSanPham != null && sp.TenSanPham.ToLower().Contains(keySearch));
            }

            if (MaTheLoai > 0)
            {
                query = query.Where(sp => sp.MaTheLoai == MaTheLoai);
            }

            return await query
                .Select(sp => new SanPham
                {
                    MaSanPham = sp.MaSanPham,
                    HinhAnh = sp.HinhAnh,
                    Gia = sp.Gia,
                    TenSanPham = sp.TenSanPham,
                    TheLoai = sp.TheLoai,
                    TenTheLoai = sp.TenTheLoai,
                    SoLuong = sp.SoLuong
                })
                .ToListAsync();
        }
    }
}