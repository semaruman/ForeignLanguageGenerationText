using System.ComponentModel.DataAnnotations;

namespace ForeignLanguageGenerationText.Areas.User.ViewModels
{
    public class WordViewModel
    {
        [Required(ErrorMessage = "Введите слово")]
        [MinLength(1)]
        [MaxLength(40)]
        public string Word {  get; set; }
    }
}
