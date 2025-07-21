using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using Web_Adidas.Data;
using Web_Adidas.Models;
using Web_Adidas.repositories;

namespace Web_Adidas.Controllers
{
    public class CartController : Controller
    {
        private readonly IHomeRepository _homeRepository;
        private readonly ApplicationDbContext _context;
        private readonly IcartRepository _cartRepository;
        public CartController(ApplicationDbContext context, IcartRepository cartRepository)
        {
            _context = context;
            _cartRepository = cartRepository;
        }

        [HttpGet] // Sử dụng HttpGet để lấy dữ liệu
        public async Task<IActionResult> GetCartItemCount()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                // Nếu người dùng chưa đăng nhập, trả về 0 hoặc xử lý theo nhu cầu
                return Json(new { totalCartItems = 0 });
            }
            var totalCartItems = await _cartRepository.getCartItemCount(userId);
            return Json(new { totalCartItems = totalCartItems });
        }

        public IActionResult ThanhToan()
        {



            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [Authorize] // Đảm bảo người dùng đã đăng nhập
        public async Task<IActionResult> ChiTietDonHang(int maDonHang)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            

            // Tìm đơn hàng của người dùng
            var donHang = await _context.DbSetDonHang
                .Include(dh => dh.ChiTietDonHangs)
                    .ThenInclude(ct => ct.SanPham) // Nạp thông tin sản phẩm
                .FirstOrDefaultAsync(dh => dh.MaDonHang == maDonHang && dh.MaNguoiDung == userId);

            if (donHang == null)
            {
                ViewBag.Message = "Không tìm thấy đơn hàng.";
                return View(new DonHang { ChiTietDonHangs = new List<ChiTietDonHang>() });
            }

            return View(donHang);
        }

        [Authorize] // Yêu cầu người dùng đăng nhập để xem giỏ hàng
        public async Task<IActionResult> ViewCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var cart = await _cartRepository.getCart(userId);
            if (cart == null)
            {
                cart = new GioHang
                {
                    MaNguoiDung = userId,
                    ChiTietGioHangs = new List<ChiTietGioHang>()
                };
                ViewBag.Message = "Giỏ hàng của bạn trống.";
            }
            else if (cart.ChiTietGioHangs == null)
            {
                cart.ChiTietGioHangs = new List<ChiTietGioHang>();
                ViewBag.Message = "Giỏ hàng của bạn trống.";
            }

            return View(cart);
        }
        // Action để thêm sản phẩm vào giỏ hàng (sử dụng POST)
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddItemToCart(int spId , int soLuong =1 )
        {
            try
            {
                var currentQuantity = await _cartRepository.AddItem(spId, soLuong);
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var totalCartItems = await _cartRepository.getCartItemCount(userId);
                return Json(new { success = true, message = $"Đã thêm sản phẩm vào giỏ hàng. Tổng số lượng của sản phẩm này: {currentQuantity}", totalCartItems = totalCartItems });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm sản phẩm vào giỏ hàng: {ex.Message}");
                return StatusCode(500, new { success = false, message = "Có lỗi xảy ra khi thêm sản phẩm vào giỏ hàng." });
            }
        }


        // Action để xóa sản phẩm khỏi giỏ hàng (sử dụng POST)
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RemoveItemFromCart(int spId)
        {
            try
            {
                // Tạo một đối tượng SanPham tạm thời chỉ với MaSanPham để truyền vào DeleteItem
                
                var remainingItems = await _cartRepository.DeleteItem(spId);
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var totalCartItems = await _cartRepository.getCartItemCount(userId);
                return Json(new { success = true, message = "Đã xóa sản phẩm khỏi giỏ hàng.", totalCartItems = totalCartItems });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa sản phẩm khỏi giỏ hàng: {ex.Message}");
                return StatusCode(500, new { success = false, message = "Có lỗi xảy ra khi xóa sản phẩm khỏi giỏ hàng." });
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DecreaseItemFromCart(int spId)
        {
            try
            {
                // Tạo một đối tượng SanPham tạm thời chỉ với MaSanPham để truyền vào DeleteItem

                var remainingItems = await _cartRepository.DecreaseItem(spId);
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var totalCartItems = await _cartRepository.getCartItemCount(userId);
                return Json(new { success = true, message = "Đã giảm số lượng ", totalCartItems = totalCartItems });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa sản phẩm khỏi giỏ hàng: {ex.Message}");
                return StatusCode(500, new { success = false, message = "Có lỗi xảy ra khi xóa sản phẩm khỏi giỏ hàng." });
            }
        }

        // Action để xử lý Checkout
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Checkout(CheckOut model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Dữ liệu thanh toán không hợp lệ.",
                    errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }

            try
            {

                bool result = await _cartRepository.CheckOut(model);
                if (result)
                {
                    
                    return Json(new { success = true, message = "Đặt hàng thành công!" });
                }
                else
                {
                    
                    return StatusCode(500, new { success = false, message = "Có lỗi xảy ra khi đặt hàng. Vui lòng thử lại." });
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { success = false, message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { success = false, message = ex.Message }); // Giỏ hàng trống, v.v.
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xử lý checkout: {ex.Message}");
                return StatusCode(500, new { success = false, message = "Có lỗi không xác định xảy ra khi đặt hàng." });
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CancelOrder(int maDonHang)
        {
            try
            {
                bool result = await _cartRepository.CancelOrder(maDonHang);
                if (result)
                {
                    return Json(new { success = true, message = "Đã hủy đơn hàng thành công." });
                }
                else
                {
                    return Json(new { success = false, message = "Có lỗi xảy ra khi hủy đơn hàng. Vui lòng thử lại." });
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { success = false, message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi hủy đơn hàng: {ex.Message}");
                return StatusCode(500, new { success = false, message = "Có lỗi không xác định xảy ra khi hủy đơn hàng." });
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetOrderDetails(int maDonHang)
        {
            try
            {
                var chiTietDonHangs = await _cartRepository.GetOrderDetails(maDonHang);
                if (chiTietDonHangs == null || !chiTietDonHangs.Any())
                {
                    return Json(new { success = false, message = "Không tìm thấy chi tiết đơn hàng." });
                }

                var items = chiTietDonHangs.Select(ct => new
                {
                    TenSanPham = ct.SanPham?.TenSanPham ?? "Sản phẩm không xác định",
                    SoLuong = ct.SoLuong,
                    DonGia = ct.DonGia
                }).ToList();

                return Json(new { success = true, items });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy chi tiết đơn hàng: {ex.Message}");
                return StatusCode(500, new { success = false, message = "Có lỗi xảy ra khi lấy chi tiết đơn hàng." });
            }
        }
    }
}
