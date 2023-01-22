using System.ComponentModel.DataAnnotations;

namespace CatalogTop.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(250, ErrorMessage = "Превышена допустимая длина")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Не корректная почта")]
        [Compare("Email", ErrorMessage = "Не корректная почта")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Пороль неверный")]
        public string? Password { get; set; }

    }
}
