using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web_Adidas.Models;

namespace Web_Adidas.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }
    public DbSet<ChiTietDonHang> DbSetChiTietDonHang { get; set; }
    public DbSet<ChiTietGioHang> DbSetChiTietGioHang { get; set; }
    public DbSet<DonHang> DbSetDonHang { get; set; }
    public DbSet<GioHang> DbSetGioHang { get; set; }
    public DbSet<SanPham> DbSetSanPham { get; set; }
    public DbSet<TheLoai> DbSetTheLoai { get; set; }
    public DbSet<TrangThaiDonHang> DbSetTrangThaiDonHang { get; set; }
}
