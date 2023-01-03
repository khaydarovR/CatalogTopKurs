using System.ComponentModel.DataAnnotations;

namespace CatalogTop.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(250, ErrorMessage = "Превышена допустимая длина")]
        [MinLength(4, ErrorMessage = "Мало символов")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Не корректная почта")]
        [Compare("Email", ErrorMessage = "Не корректная почта")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(250, ErrorMessage = "Превышена допустимая длина")]
        [MinLength(4, ErrorMessage = "Мало символов")]
        [DataType(DataType.Password, ErrorMessage = "Не корректный пароль")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Повторите пороль правильно")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string? PasswordConfirm { get; set; }
    }
}
