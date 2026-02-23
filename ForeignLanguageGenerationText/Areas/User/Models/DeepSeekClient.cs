using Newtonsoft.Json.Linq;
using System.Text;

namespace ForeignLanguageGenerationText.Areas.User.Models
{
    public class DeepSeekClient
    {
        private string apiKey = "sk-a81f83989f67442ca87dd7b2de0ab39e";
        public async Task<string> AskDeepSeek(string message)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                var request = new
                {
                    model = "deepseek-chat",
                    messages = new[] { new { role = "user", content = message } }
                };

                var content = new StringContent(
                    Newtonsoft.Json.JsonConvert.SerializeObject(request),
                    Encoding.UTF8,
                    "application/json");

                var response = await client.PostAsync("https://api.deepseek.com/v1/chat/completions", content);
                var jsonResponse = await response.Content.ReadAsStringAsync();

                var result = JObject.Parse(jsonResponse);
                return result["choices"]?[0]?["message"]?["content"]?.ToString() ?? "Нет ответа";
            }
        }
    }
}
