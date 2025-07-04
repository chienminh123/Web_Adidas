using Web_Adidas.Data;
using Microsoft.EntityFrameworkCore;
using Web_Adidas.Models;
using Microsoft.AspNetCore.Identity;

namespace Web_Adidas.repositories
{
    public class CartRepo : IcartRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private IHttpContextAccessor _contextAccessor;
        public CartRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GioHang> getCart(string userId)
        {
            var cart = await _dbContext.DbSetGioHang.FirstOrDefaultAsync(u => u.MaNguoiDung == userId);
            return cart;
        }

        public async Task<int> AddItem(int spId, int SoLuong)
        {
            throw new UnauthorizedAccessException("Người dùng chưa đăng nhập");
        }

        public async Task<int> DeleteItem(SanPham spId)
        {
            throw new NotImplementedException();
        }

        public async Task<GioHang> UserCart(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> getCartItemCount(string userId)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> CheckOut(CheckOut model)
        {
            using var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                var userId = UserCart();
                if (string.IsNullOrEmpty(userId))
                {
                    throw new UnauthorizedAccessException("Người dùng chưa đăng nhập");
                }

                var cart = await getCart(userId);
                if(cart is null)
                {
                    throw new InvalidOperationException("Lỗi , giỏ hàng trống ");
                }

                var ChiTietGiohang = _dbContext.DbSetChiTietGioHang
                    .Where(s => s.MaChiTietGioHang == cart.MaGioHang).ToList(); 
                if(ChiTietGiohang.Count==0)
                {
                    throw new InvalidOperationException("Giỏ hàng trống ");
                }

                var trangthaidonhang = _dbContext.DbSetTrangThaiDonHang.FirstOrDefault(s => s.TenTrangThaiDonHang == "Chờ xử lý ");
                    if (trangthaidonhang is null)
                    {
                        throw new InvalidOperationException("Đơn hàng đang chờ xử lý ");
                    }

                var order = new DonHang
                {
                    MaNguoiDung = userId,
                    NgayTaoDonHang = DateTime.UtcNow,
                    SDT=model.Sdt,
                    PTThanhToan=model.PtThanhToan,
                    DiaChi=model.DiaChi,
                    ThanhToan=false,
                    //TrangThaiDonHang=trangthaidonhang.MaTrangThaiDonHang

                };
                _dbContext.DbSetDonHang.Add(order);
                _dbContext.SaveChanges();
                foreach(var item in ChiTietGiohang)
                {
                    var chitietdonhang = new ChiTietDonHang
                    {
                        MaSanPham = item.MaSanPham,
                        //MaDonHang = order.MaDonHang,
                        SoLuong = item.SoLuong,
                        DonGia = item.DonGia,

                    };
                    //_dbContext.DbSetChiTietDonHang.Add();
                }
            }
            catch
            {

            }
            throw new NotImplementedException();
        }

        private string UserCart()
        {
           
            var httpContext = _contextAccessor.HttpContext;
            //kiem tra
            if (httpContext?.User != null)
            {
                return _userManager.GetUserId(httpContext.User);

            }
            return null;
        }

        
    }
}