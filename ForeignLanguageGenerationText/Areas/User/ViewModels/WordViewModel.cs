using System.ComponentModel.DataAnnotations;

namespace ForeignLanguageGenerationText.Areas.User.ViewModels
{
    public class WordViewModel
    {
        [Required(ErrorMessage = "Введите слово")]
        public string Word {  get; set; }
    }
}
