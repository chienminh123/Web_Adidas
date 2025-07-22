using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using Web_Adidas.Data;
using Web_Adidas.Models;
using Web_Adidas.repositories;

namespace Web_Adidas.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly IHomeRepository _homeRepository;


    public HomeController(ApplicationDbContext context, IHomeRepository homeRepository)
    {
        _context = context;
        _homeRepository = homeRepository;
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
    public async Task<IActionResult> SamBa(string filter="")
    {
        var sanPhams = await _homeRepository.SapXep(1, filter);
        var model = new TheLoai
        {
            SanPhams = sanPhams.ToList() ?? new List<SanPham>()
        };

        ViewBag.SelectedFilter = filter;
        if (!model.SanPhams.Any())
        {
            ViewBag.Message = "Không tìm thấy sản phẩm nào thuộc danh mục Áo.";
        }
        return View(model);
    }
    public async Task<IActionResult> Gazelle(string filter = "")
    {
        var sanPhams = await _homeRepository.SapXep(2, filter);
        var model = new TheLoai
        {
            SanPhams = sanPhams.ToList() ?? new List<SanPham>()
        };

        ViewBag.SelectedFilter = filter;
        if (!model.SanPhams.Any())
        {
            ViewBag.Message = "Không tìm thấy sản phẩm nào thuộc danh mục Áo.";
        }
        return View(model);
    }
    public async Task<IActionResult> Adizero(string filter = "")
    {
        var sanPhams = await _homeRepository.SapXep(3, filter);
        var model = new TheLoai
        {
            SanPhams = sanPhams.ToList() ?? new List<SanPham>()
        };

        ViewBag.SelectedFilter = filter;
        if (!model.SanPhams.Any())
        {
            ViewBag.Message = "Không tìm thấy sản phẩm nào thuộc danh mục Áo.";
        }
        return View(model);
    }
    public async Task<IActionResult> Superstar(string filter = "")
    {
        var sanPhams = await _homeRepository.SapXep(4, filter);
        var model = new TheLoai
        {
            SanPhams = sanPhams.ToList() ?? new List<SanPham>()
        };

        ViewBag.SelectedFilter = filter;
        if (!model.SanPhams.Any())
        {
            ViewBag.Message = "Không tìm thấy sản phẩm nào thuộc danh mục Áo.";
        }
        return View(model);
    }
    public async Task<IActionResult> Sports(string filter = "")
    {
        var sanPhams = await _homeRepository.SapXep(5, filter);
        var model = new TheLoai
        {
            SanPhams = sanPhams.ToList() ?? new List<SanPham>()
        };

        ViewBag.SelectedFilter = filter;
        if (!model.SanPhams.Any())
        {
            ViewBag.Message = "Không tìm thấy sản phẩm nào thuộc danh mục Áo.";
        }
        return View(model);
    }
    public async Task<IActionResult> Dep(string filter = "")
    {
        var sanPhams = await _homeRepository.SapXep(8, filter);
        var model = new TheLoai
        {
            SanPhams = sanPhams.ToList() ?? new List<SanPham>()
        };
        
        ViewBag.SelectedFilter = filter;
        if (!model.SanPhams.Any())
        {
            ViewBag.Message = "Không tìm thấy sản phẩm nào thuộc danh mục Áo.";
        }
        return View(model);
    }
    public async Task<IActionResult> Quan(string filter = "")
    {
        var sanPhams = await _homeRepository.SapXep(13, filter);
        var model = new TheLoai
        {
            SanPhams = sanPhams.ToList() ?? new List<SanPham>()
        };

        ViewBag.SelectedFilter = filter;
        if (!model.SanPhams.Any())
        {
            ViewBag.Message = "Không tìm thấy sản phẩm nào thuộc danh mục Áo.";
        }
        return View(model);
    }
    public async Task<IActionResult> Ao(string filter = "")
    {
        var sanPhams = await _homeRepository.SapXep(9, filter);
        var model = new TheLoai
        {
            SanPhams = sanPhams.ToList() ?? new List<SanPham>()
        };

        ViewBag.SelectedFilter = filter;
        if (!model.SanPhams.Any())
        {
            ViewBag.Message = "Không tìm thấy sản phẩm nào thuộc danh mục Áo.";
        }
        return View(model);
    }

    public async Task<IActionResult> All_SanPham(string filter = "")
    {
        var sanPhams = await _homeRepository.SapXep(0, filter);
        var model = new TheLoai
        {
            SanPhams = sanPhams.ToList() ?? new List<SanPham>()
        };

        ViewBag.SelectedFilter = filter;
        if (!model.SanPhams.Any())
        {
            ViewBag.Message = "Không tìm thấy sản phẩm nào thuộc danh mục Áo.";
        }
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
            SanPhams = sanPhams 
        };
        return View(model);
    }

    public IActionResult LichSuDatHang()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var chiTietDonHangs = _context.DbSetChiTietDonHang
        .Include(ct => ct.DonHang) 
        .Where(ct => ct.DonHang.MaNguoiDung == userId)
        .ToList();
        var model = new DonHang
        {
            ChiTietDonHangs = _context.DbSetChiTietDonHang.ToList() ?? new List<ChiTietDonHang>()
        };
        return View(model);
    }


    [HttpGet]
    public async Task<IActionResult> SearchProducts(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return Json(new { results = new List<object>(), message = "Vui lòng nhập từ khóa tìm kiếm." });
        }

        try
        {
            var products = await _homeRepository.SearchProducts(query);
            var result = products.Select(sp => new
            {
                MaSanPham = sp.MaSanPham,
                TenSanPham = sp.TenSanPham ?? "Không có tên",
                HinhAnh = sp.HinhAnh ?? "",
                Size = sp.Size ?? "N/A",
                Gia = sp.Gia,
                SoLuong = sp.SoLuong
            }).ToList();

            if (!result.Any())
            {
                return Json(new { results = new List<object>(), message = "Không tìm thấy sản phẩm nào." });
            }

            return Json(new { results = result });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Lỗi khi tìm kiếm sản phẩm.");
            return Json(new { results = new List<object>(), message = "Có lỗi xảy ra khi tìm kiếm." });
        }
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
