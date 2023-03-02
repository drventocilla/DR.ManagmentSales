using System.ComponentModel.DataAnnotations;

namespace DR.ManagmentSales.API.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Login es requerido")]
        public string Login { get; }
        [Required(ErrorMessage = "Password es requerido")]
        public string Password { get; }

        public LoginModel(string login, string password)
        {
            Login = login;
            Password = password;
        }
    } 
}
