using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "Kullanıcı Adı Alanı Gereklidir.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre Alanı Gereklidir.")]
        public string Password { get; set; }
    }
}
