using Web_Adidas.Data;
using Web_Adidas.Models;
using Microsoft.EntityFrameworkCore;

namespace Web_Adidas.repositories
{
    public class HomeRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SanPham>> GetSanPham(string keySeach = "", int MaTheLoai = 0)
        {
            keySeach = keySeach.ToLower();
            IEnumerable<SanPham> sanPham = await (from Sp in _dbContext.DbSetSanPham
                                                  join theLoai in _dbContext.DbSetTheLoai
                                                  on Sp.MaSanPham equals theLoai.MaTheLoai
                                                  where string.IsNullOrWhiteSpace(keySeach) ||
                                                        (Sp != null && Sp.TenSanPham != null && Sp.TenSanPham.ToLower().StartsWith(keySeach.ToLower()))
                                                  select new SanPham
                                                  {
                                                      MaSanPham = Sp.MaSanPham,
                                                      HinhAnh = Sp.HinhAnh,
                                                      Gia = Sp.Gia,
                                                      TenSanPham = Sp.TenSanPham,
                                                      TheLoai = Sp.TheLoai,
                                                      TenTheLoai = Sp.TenTheLoai,
                                                      SoLuong = Sp.SoLuong
                                                  }).ToListAsync();  

            return sanPham;
        }
    }
}
