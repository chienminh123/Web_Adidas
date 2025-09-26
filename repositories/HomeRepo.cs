using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Web_Adidas.Data;
using Web_Adidas.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Web_Adidas.repositories
{
    public class HomeRepo : IHomeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SanPham>> SearchProducts(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return await Task.FromResult(Enumerable.Empty<SanPham>());
            }

            Console.WriteLine($"Tìm kiếm với query: {query}");
            var results = await _dbContext.DbSetSanPham
                .Where(sp => sp.TenSanPham.ToLower().Contains(query.ToLower()))
                .Select(sp => new SanPham
                {
                    MaSanPham = sp.MaSanPham,
                    HinhAnh = sp.HinhAnh,
                    Gia = sp.Gia,
                    TenSanPham = sp.TenSanPham,
                    Size = sp.Size,
                    SoLuong = sp.SoLuong,
                    MaTheLoai=sp.MaTheLoai
                })
                
                .ToListAsync();
            Console.WriteLine($"Số sản phẩm tìm thấy: {results.Count}");
            return results;
        }

        public async Task<IEnumerable<SanPham>> SapXep(int maTheLoai, string filter = "")
        {
            if (maTheLoai == 0)
            {
                IQueryable<SanPham> query = _dbContext.DbSetSanPham;
                    
                Console.WriteLine($"Số sản phẩm trước khi lọc: {query.Count()}");
                if (filter != "")
                {
                    if (filter == "1")
                    {
                        query = query.OrderBy(sp => sp.Gia);
                    }
                    else if (filter == "2")
                    {
                        query = query.OrderByDescending(sp => sp.Gia);
                    }
                }
                var result = await query
                    .Select(sp => new SanPham
                    {
                        MaSanPham = sp.MaSanPham,
                        MaTheLoai = sp.MaTheLoai,
                        HinhAnh = sp.HinhAnh,
                        Gia = sp.Gia,
                        TenSanPham = sp.TenSanPham,
                        Size = sp.Size,
                        SoLuong = sp.SoLuong
                    })
                    .ToListAsync();
                Console.WriteLine($"Số sản phẩm sau khi lọc: {result.Count}");
                return result;
            }
            else
            {
                IQueryable<SanPham> query = _dbContext.DbSetSanPham
                    .Where(sp => sp.MaTheLoai == maTheLoai);
                Console.WriteLine($"Số sản phẩm trước khi lọc: {query.Count()}");
                if (filter != "")
                {
                    if (filter == "1")
                    {
                        query = query.OrderBy(sp => sp.Gia);
                    }
                    else if (filter == "2")
                    {
                        query = query.OrderByDescending(sp => sp.Gia);
                    }
                }
                var result = await query
                    .Select(sp => new SanPham
                    {
                        MaSanPham = sp.MaSanPham,
                        MaTheLoai = sp.MaTheLoai,
                        HinhAnh = sp.HinhAnh,
                        Gia = sp.Gia,
                        TenSanPham = sp.TenSanPham,
                        Size = sp.Size,
                        SoLuong = sp.SoLuong
                    })
                    .ToListAsync();
                Console.WriteLine($"Số sản phẩm sau khi lọc: {result.Count}");
                return result;
            }
                
        }
    } 
}