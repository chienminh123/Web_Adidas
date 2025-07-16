using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using Web_Adidas.Data;
using Web_Adidas.Models;
using Web_Adidas.repositories;

namespace Web_Adidas.Controllers;

public class HomeController : Controller
{
    //private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    


    public HomeController(ApplicationDbContext context, IcartRepository cartRepository)
    {
        _context = context;
        
    }


    public IActionResult Index()
    {
        var model = new TheLoai
        {
            SanPhams = _context.DbSetSanPham.ToList() ?? new List<SanPham>() 
        }
        ;
        return View(model);
        //return View();

    }
    public IActionResult SamBa()
    {
        var model = new TheLoai
        {
            SanPhams = _context.DbSetSanPham.ToList() ?? new List<SanPham>() 
        };
        return View(model);
    }
    public IActionResult Gazelle()
    {
        var model = new TheLoai
        {
            SanPhams = _context.DbSetSanPham.ToList() ?? new List<SanPham>() 
        };
        return View(model);
    }
    public IActionResult Adizero()
    {
        var model = new TheLoai
        {
            SanPhams = _context.DbSetSanPham.ToList() ?? new List<SanPham>() 
        };
        return View(model);
    }
    public IActionResult Superstar()
    {
        var model = new TheLoai
        {
            SanPhams = _context.DbSetSanPham.ToList() ?? new List<SanPham>() 
        };
        return View(model);
    }
    public IActionResult Sports()
    {
        var model = new TheLoai
        {
            SanPhams = _context.DbSetSanPham.ToList() ?? new List<SanPham>() 
        };
        return View(model);
    }
    public IActionResult Dep()
    {
        var model = new TheLoai
        {
            SanPhams = _context.DbSetSanPham.ToList() ?? new List<SanPham>()
        };
        return View(model);
    }
    public IActionResult Quan()
    {
        var model = new TheLoai
        {
            SanPhams = _context.DbSetSanPham.ToList() ?? new List<SanPham>()
        };
        return View(model);
    }
    public IActionResult Ao()
    {
        var model = new TheLoai
        {
            SanPhams = _context.DbSetSanPham.ToList() ?? new List<SanPham>()
        };
        return View(model);
    }
    public IActionResult All_SanPham()
    {
        var model = new TheLoai
        {
            SanPhams = _context.DbSetSanPham.ToList() ?? new List<SanPham>() 
        };
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> TrangSanPham(string hinhAnh)
    {
        if (string.IsNullOrEmpty(hinhAnh))
        {
            ViewBag.Message = "Hình ảnh sản phẩm không hợp lệ.";
            return View(new TheLoai { SanPhams = new List<SanPham>() });
        }

        // Lấy tất cả sản phẩm có cùng HinhAnh
        var sanPhams = await _context.DbSetSanPham
            .Where(sp => sp.HinhAnh == hinhAnh)
            .ToListAsync();

        if (sanPhams == null || !sanPhams.Any())
        {
            ViewBag.Message = "Không tìm thấy sản phẩm.";
            return View(new TheLoai { SanPhams = new List<SanPham>() });
        }

        var model = new TheLoai
        {
            SanPhams = sanPhams // Trả về danh sách sản phẩm với các kích thước
        };
        return View(model);
    }

    public IActionResult LichSuDatHang()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var chiTietDonHangs = _context.DbSetChiTietDonHang
        .Include(ct => ct.DonHang) // Đảm bảo nạp dữ liệu DonHang
        .Where(ct => ct.DonHang.MaNguoiDung == userId)
        .ToList();
        var model = new DonHang
        {
            ChiTietDonHangs = _context.DbSetChiTietDonHang.ToList() ?? new List<ChiTietDonHang>()
        };
        return View(model);
    }








    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
