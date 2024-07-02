using System;
using System.ComponentModel.DataAnnotations;

namespace DevLink.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите свое имя")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Пожалуйста, введите свое настоящее имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите свое фамилию")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Пожалуйста, введите свою настоящую фамилию")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Выберите никнейм")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Слишком короткий никнейм")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите свою электоронную почту")]
        [EmailAddress(ErrorMessage = "Пожалуйста, введите подлинную электоронную почту")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Придумайте пароль")]
        [RegularExpression("^(?=.*[A-Z])(?=.*\\d)(?=.*[!@#$%^&*()_+\\-=\\[\\]{};':\"\\\\|,.<>\\/?])[A-Za-z\\d!@#$%^&*()_+\\-=\\[\\]{};':\"\\\\|,.<>\\/?]*$", ErrorMessage = "Пароль должен содержать хотя бы один спецсимвол, цифру и заглавную букву")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Пароль должен содержать минимум 8 символов")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("NewPassword", ErrorMessage = "Это не совпадает с выбранным вами паролем")]
        public string NewPasswordConfirmation { get; set; }
        public string Role { get; set; }
    }
}
