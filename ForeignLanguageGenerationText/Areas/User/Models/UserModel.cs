

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ForeignLanguageGenerationText.Areas.User.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Введите имя пользователя")]
        [MinLength(2, ErrorMessage = "Имя пользователя должно быть не менее 2-х символов")]
        [MaxLength(30, ErrorMessage = "Имя пользователя должно быть не более 30 символов")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; } = string.Empty;

        [BindNever]
        public List<string> LearnedWords { get; set; } = new List<string>();
    }
}
