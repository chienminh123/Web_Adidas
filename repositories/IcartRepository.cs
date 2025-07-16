using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using Web_Adidas.Models;

namespace Web_Adidas.repositories
{
    public interface IcartRepository
    {
        Task<int> AddItem(int spId,int SoLuong);
        Task<int> DeleteItem(int spId);
        Task<int> DecreaseItem(int spId);
        
         Task<GioHang> getCart(string userId);
        Task<int> getCartItemCount(string userId);
        Task<bool> CheckOut(CheckOut model);
        //Task<string> GetUserId();
        Task<bool> CancelOrder(int maDonHang);
        Task<List<ChiTietDonHang>> GetOrderDetails(int maDonHang);
    }
}
