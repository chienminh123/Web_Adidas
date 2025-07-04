using System.ComponentModel.Design;
using Web_Adidas.Models;

namespace Web_Adidas.repositories
{
    public interface IcartRepository
    {
        Task<int> AddItem(int spId,int SoLuong);
        Task<int> DeleteItem(SanPham spId);
        Task<GioHang> UserCart(int id);
        Task<GioHang> getCart(string userId);
        Task<int> getCartItemCount(string userId);
        Task<bool> CheckOut(CheckOut model);
    }
}
