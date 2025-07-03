using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web_Adidas.Data;
using Web_Adidas.Models;

namespace Web_Adidas.Controllers;

public class HomeController : Controller
{
    //private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }
  

    public IActionResult Index()
    {
        var model = new TheLoai
        {
            SanPhams = _context.DbSetSanPham.ToList() ?? new List<SanPham>() // Khởi tạo danh sách rỗng nếu null
        };
        return View(model);
    }
    public IActionResult SamBa()
    {
        var model = new TheLoai
        {
            SanPhams = _context.DbSetSanPham.ToList() ?? new List<SanPham>() // Khởi tạo danh sách rỗng nếu null
        };
        return View(model);
    }
    public IActionResult TrangSanPham()
    {
        return View();
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
