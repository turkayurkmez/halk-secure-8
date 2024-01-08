using System.ComponentModel.DataAnnotations;

namespace AuthProcessInWeb.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı boş olamaz")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre boş olamaz")]
        public string Password { get; set; }
    }
}
