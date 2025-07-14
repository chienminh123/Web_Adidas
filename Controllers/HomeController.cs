using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
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
            SanPhams = _context.DbSetSanPham.ToList() ?? new List<SanPham>() // Khởi tạo danh sách rỗng nếu null
        }
        ;
        return View(model);
        //return View();

    }
    public IActionResult SamBa()
    {
        var model = new TheLoai
        {
            SanPhams = _context.DbSetSanPham.ToList() ?? new List<SanPham>() // Khởi tạo danh sách rỗng nếu null
        };
        return View(model);
    }
    public IActionResult Gazelle()
    {
        var model = new TheLoai
        {
            SanPhams = _context.DbSetSanPham.ToList() ?? new List<SanPham>() // Khởi tạo danh sách rỗng nếu null
        };
        return View(model);
    }
    public IActionResult Adizero()
    {
        var model = new TheLoai
        {
            SanPhams = _context.DbSetSanPham.ToList() ?? new List<SanPham>() // Khởi tạo danh sách rỗng nếu null
        };
        return View(model);
    }
    public IActionResult Superstar()
    {
        var model = new TheLoai
        {
            SanPhams = _context.DbSetSanPham.ToList() ?? new List<SanPham>() // Khởi tạo danh sách rỗng nếu null
        };
        return View(model);
    }
    public IActionResult Sports()
    {
        var model = new TheLoai
        {
            SanPhams = _context.DbSetSanPham.ToList() ?? new List<SanPham>() // Khởi tạo danh sách rỗng nếu null
        };
        return View(model);
    }
    public IActionResult Dep()
    {
        var model = new TheLoai
        {
            SanPhams = _context.DbSetSanPham.ToList() ?? new List<SanPham>() // Khởi tạo danh sách rỗng nếu null
        };
        return View(model);
    }
    public IActionResult Quan()
    {
        var model = new TheLoai
        {
            SanPhams = _context.DbSetSanPham.ToList() ?? new List<SanPham>() // Khởi tạo danh sách rỗng nếu null
        };
        return View(model);
    }
    public IActionResult Ao()
    {
        var model = new TheLoai
        {
            SanPhams = _context.DbSetSanPham.ToList() ?? new List<SanPham>() // Khởi tạo danh sách rỗng nếu null
        };
        return View(model);
    }
    public IActionResult All_SanPham()
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
