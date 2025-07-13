using Web_Adidas.Data;
using Microsoft.EntityFrameworkCore;
using Web_Adidas.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Web_Adidas.repositories
{
    public class CartRepo : IcartRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public CartRepo(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        public async Task<GioHang> getCart(string userId)
        {
            var cart = await _dbContext.DbSetGioHang
                .Include(g => g.ChiTietGioHangs)
                    .ThenInclude(ci => ci.SanPham)
                .FirstOrDefaultAsync(u => u.MaNguoiDung == userId);

            if (cart != null)
            {
                // Lọc bỏ các ChiTietGioHang có SanPham là null
                cart.ChiTietGioHangs = cart.ChiTietGioHangs
                    .Where(ci => ci.SanPham != null)
                    .ToList();

                // (Tùy chọn) Xóa các ChiTietGioHang không hợp lệ khỏi cơ sở dữ liệu
                var invalidItems = cart.ChiTietGioHangs
                    .Where(ci => ci.SanPham == null)
                    .ToList();
                if (invalidItems.Any())
                {
                    _dbContext.DbSetChiTietGioHang.RemoveRange(invalidItems);
                    await _dbContext.SaveChangesAsync();
                }
            }

            return cart;

           
        }

        private string GetUserId()
        {
            var httpConText = _contextAccessor.HttpContext;
            if (httpConText?.User != null)
            {
                return _userManager.GetUserId(httpConText.User);
            }
            return null;
        }
        public async Task<int> AddItem(int spId, int SoLuong)
        {
            // Lấy ID của người dùng hiện tại.
            string userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                // Nếu người dùng chưa đăng nhập, ném ngoại lệ.
                throw new UnauthorizedAccessException("Người dùng chưa đăng nhập.");
            }

            try
            {
                // Lấy giỏ hàng của người dùng.
                var cart = await getCart(userId); // Sử dụng getCart để lấy cả chi tiết nếu cần
                if (cart == null)
                {
                    // Nếu người dùng chưa có giỏ hàng, tạo một giỏ hàng mới.
                    cart = new GioHang
                    {
                        MaNguoiDung = userId
                    };
                    _dbContext.DbSetGioHang.Add(cart);
                    await _dbContext.SaveChangesAsync(); // Lưu giỏ hàng mới để có MaGioHang.
                }

                // Tìm sản phẩm trong cơ sở dữ liệu để lấy thông tin giá.
                var product = await _dbContext.DbSetSanPham.FindAsync(spId);
                if (product == null)
                {
                    // Nếu sản phẩm không tồn tại, trả về 0 hoặc ném ngoại lệ.
                    Console.WriteLine($"Sản phẩm với ID {spId} không tồn tại.");
                    return 0;
                }

                // Kiểm tra xem sản phẩm đã có trong chi tiết giỏ hàng của người dùng này chưa.
                // Quan trọng: Phải kiểm tra MaGioHang và MaSanPham
                var cartItem = await _dbContext.DbSetChiTietGioHang
                                .FirstOrDefaultAsync(ci => ci.MaGioHang == cart.MaGioHang && ci.MaSanPham == spId);

                if (cartItem == null)
                {
                    // Nếu sản phẩm chưa có trong giỏ hàng, thêm mới một mục chi tiết giỏ hàng.
                    cartItem = new ChiTietGioHang
                    {
                        MaGioHang = cart.MaGioHang,
                        MaSanPham = spId,
                        SoLuong = SoLuong,
                        DonGia = product.Gia*SoLuong
                    };
                    _dbContext.DbSetChiTietGioHang.Add(cartItem);
                }
                else
                {
                    // Nếu sản phẩm đã có, cập nhật số lượng và đơn giá.
                    cartItem.SoLuong += SoLuong;
                    cartItem.DonGia = product.Gia * cartItem.SoLuong;// Đảm bảo giá được cập nhật theo giá hiện tại của sản phẩm.
                }

                await _dbContext.SaveChangesAsync(); // Lưu các thay đổi vào cơ sở dữ liệu.
                return cartItem.SoLuong; // Trả về tổng số lượng của sản phẩm đó trong giỏ hàng.
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu có bất kỳ vấn đề nào xảy ra trong quá trình thêm vào giỏ hàng.
                Console.WriteLine($"Lỗi khi thêm sản phẩm vào giỏ hàng: {ex.Message}");
                return 0; // Trả về 0 để báo hiệu lỗi.
            }
        }

        public async Task<int> DecreaseItem(int spId)
        {
            string userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("Người dùng chưa đăng nhập.");
            }

            try
            {
                var cart = await getCart(userId);
                if (cart == null)
                {
                    Console.WriteLine($"Không tìm thấy giỏ hàng cho người dùng: {userId}");
                    return 0; // Giỏ hàng không tồn tại
                }

                // Tìm chi tiết giỏ hàng cần xóa dựa trên MaGioHang của giỏ và MaSanPham của sản phẩm
                var cartItem = await _dbContext.DbSetChiTietGioHang
                                .FirstOrDefaultAsync(ci => ci.MaGioHang == cart.MaGioHang && ci.MaSanPham == spId);

                if (cartItem == null)
                {
                    Console.WriteLine($"Sản phẩm với ID {spId} không tìm thấy trong giỏ hàng của người dùng {userId}.");
                    return 0; // Sản phẩm không có trong giỏ hàng
                }
                else if (cartItem.SoLuong == 1)
                {
                    _dbContext.DbSetChiTietGioHang.Remove(cartItem);
                }
                else
                {
                    cartItem.SoLuong = cartItem.SoLuong - 1;
                    cartItem.DonGia = cartItem.SoLuong * cartItem.SanPham.Gia;
                }

                
                await _dbContext.SaveChangesAsync();

                // Trả về số lượng item còn lại trong giỏ hàng sau khi xóa
                return await getCartItemCount(userId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa sản phẩm khỏi giỏ hàng: {ex.Message}");
                return 0; // Báo hiệu lỗi
            }
        }
        public async Task<int> DeleteItem(int spId)
        {
            string userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("Người dùng chưa đăng nhập.");
            }

            try
            {
                var cart = await getCart(userId);
                if (cart == null)
                {
                    Console.WriteLine($"Không tìm thấy giỏ hàng cho người dùng: {userId}");
                    return 0; // Giỏ hàng không tồn tại
                }

                // Tìm chi tiết giỏ hàng cần xóa dựa trên MaGioHang của giỏ và MaSanPham của sản phẩm
                var cartItem = await _dbContext.DbSetChiTietGioHang
                                .FirstOrDefaultAsync(ci => ci.MaGioHang == cart.MaGioHang && ci.MaSanPham == spId);

                if (cartItem == null)
                {
                    Console.WriteLine($"Sản phẩm với ID {spId} không tìm thấy trong giỏ hàng của người dùng {userId}.");
                    return 0; // Sản phẩm không có trong giỏ hàng
                }
                else 
                {
                    _dbContext.DbSetChiTietGioHang.Remove(cartItem);
                }
                await _dbContext.SaveChangesAsync();

                // Trả về số lượng item còn lại trong giỏ hàng sau khi xóa
                return await getCartItemCount(userId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa sản phẩm khỏi giỏ hàng: {ex.Message}");
                return 0; // Báo hiệu lỗi
            }
        }


        /// <summary>
        /// Lấy giỏ hàng của người dùng theo ID giỏ hàng. (Có vẻ không cần thiết nếu đã có getCart(userId))
        /// </summary>
        /// <param name="id">ID của giỏ hàng.</param>
        /// <returns>Đối tượng GioHang.</returns>
        

        /// <summary>
        /// Lấy tổng số lượng sản phẩm trong giỏ hàng của một người dùng.
        /// </summary>
        /// <param name="userId">ID của người dùng.</param>
        /// <returns>Tổng số lượng sản phẩm.</returns>
        public async Task<int> getCartItemCount(string userId)
        {
         
            if (string.IsNullOrEmpty(userId))
            {
                userId = GetUserId();
            }
            var data = await (
                from cart in _dbContext.DbSetGioHang
                join ChiTietGioHang in _dbContext.DbSetChiTietGioHang
                on cart.MaGioHang equals ChiTietGioHang.MaGioHang
                where cart.MaNguoiDung == userId
                select new { ChiTietGioHang.MaGioHang }).ToListAsync();
            return data.Count();
        }

        public async Task<bool> CheckOut(CheckOut model)
        {
            // Bắt đầu một giao dịch để đảm bảo tính toàn vẹn dữ liệu.
            using var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                // Lấy ID của người dùng hiện tại.
                var userId = GetUserId();
                if (string.IsNullOrEmpty(userId))
                {
                    throw new UnauthorizedAccessException("Người dùng chưa đăng nhập.");
                }

                // Lấy giỏ hàng của người dùng.
                var cart = await getCart(userId);
                if (cart is null)
                {
                    throw new InvalidOperationException("Lỗi, giỏ hàng trống.");
                }

                // Lấy tất cả các chi tiết sản phẩm trong giỏ hàng.
                var ChiTietGiohang = await _dbContext.DbSetChiTietGioHang
                    .Where(s => s.MaGioHang == cart.MaGioHang).ToListAsync();
                if (ChiTietGiohang.Count == 0)
                {
                    throw new InvalidOperationException("Giỏ hàng trống.");
                }

                // Lấy trạng thái đơn hàng "Chờ xử lý".
                var trangthaidonhang = await _dbContext.DbSetTrangThaiDonHang.FirstOrDefaultAsync(s => s.TenTrangThaiDonHang == "Chờ xử lý");

                if (trangthaidonhang is null)
                {
                    throw new InvalidOperationException("Không tìm thấy trạng thái đơn hàng 'Chờ xử lý'.");
                }

                // Tạo một đơn hàng mới.
                var order = new DonHang
                {
                    MaNguoiDung = userId,
                    NgayTaoDonHang = DateTime.UtcNow,
                    SDT = model.Sdt,
                    PTThanhToan = model.PtThanhToan,
                    DiaChi = model.DiaChi,
                    ThanhToan = false, // Mặc định là chưa thanh toán.
                    MaTrangThaiDonHang = trangthaidonhang.MaTrangThaiDonHang // Gán ID trạng thái đơn hàng.
                };
                _dbContext.DbSetDonHang.Add(order);
                await _dbContext.SaveChangesAsync(); // Lưu đơn hàng để có MaDonHang.

                // Duyệt qua từng sản phẩm trong giỏ hàng để tạo chi tiết đơn hàng.
                foreach (var item in ChiTietGiohang)
                {
                    var chitietdonhang = new ChiTietDonHang
                    {
                        MaSanPham = item.MaSanPham,
                        MaDonHang = order.MaDonHang, // Gán MaDonHang từ đơn hàng vừa tạo.
                        SoLuong = item.SoLuong,
                        DonGia = item.DonGia,
                    };
                    _dbContext.DbSetChiTietDonHang.Add(chitietdonhang); // Thêm chi tiết đơn hàng.

                    // Xóa sản phẩm khỏi giỏ hàng sau khi đã chuyển vào đơn hàng.
                    _dbContext.DbSetChiTietGioHang.Remove(item);
                }
                await _dbContext.SaveChangesAsync(); // Lưu các thay đổi (thêm chi tiết đơn hàng, xóa chi tiết giỏ hàng).

                transaction.Commit(); // Commit giao dịch nếu mọi thứ thành công.
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback(); // Rollback giao dịch nếu có lỗi.
                Console.WriteLine($"Lỗi khi thanh toán: {ex.Message}"); // Ghi log lỗi.
                return false;
            }
        }

       
        /// Lấy ID của người dùng hiện tại từ HttpContext.
        
        /// <returns>ID người dùng dưới dạng chuỗi hoặc null nếu không có.</returns>
        
    }
}
