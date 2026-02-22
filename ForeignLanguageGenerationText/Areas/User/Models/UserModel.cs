

namespace ForeignLanguageGenerationText.Areas.User.Models
{
    public class UserModel
    {
        public string UserName { get; set; } = string.Empty;
        public List<string> LearnedWords { get; set; } = new List<string>();
    }
}
