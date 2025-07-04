using Microsoft.AspNetCore.Identity;
using Web_Adidas.PhanQuyen;

namespace Web_Adidas.Data
{
    public class DataSeed
    {
        public static async Task KhoiTaoDL(IServiceProvider dichVu)
        {
            var quanlyNguoidung = dichVu.GetService<UserManager<IdentityUser>>();
            var quanlyVaitro = dichVu.GetService<RoleManager<IdentityRole>>();

            await quanlyVaitro.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await quanlyVaitro.CreateAsync(new IdentityRole(Roles.User.ToString()));

            var quantri = new IdentityUser
            {
                UserName = "admin@Adidas.com",
                Email = "admin@Adidas.com",
                EmailConfirmed = true
            };

            var nguoidungtrongCSDL = await quanlyNguoidung.FindByEmailAsync(quantri.Email);
            if(nguoidungtrongCSDL is null)
            {
                var ketqua = await quanlyNguoidung.CreateAsync(quantri, "admin@12345");
                if (ketqua.Succeeded)
                {
                    await quanlyNguoidung.AddToRoleAsync(quantri, Roles.Admin.ToString());

                }
                else
                {
                    foreach(var error in ketqua.Errors)
                    {
                        Console.WriteLine(error.Description);
                    }
                }


            }
        }
    }
}
