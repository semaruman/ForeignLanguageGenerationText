namespace ForeignLanguageGenerationText.Areas.User.ViewModels
{
    public class PromtViewModel
    {
        public string PromtString {  get; set; }

        public PromtViewModel(string promtString)
        {
            PromtString = promtString;
        }
    }
}
