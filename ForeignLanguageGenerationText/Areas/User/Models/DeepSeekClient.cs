using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class DeepSeekClient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _apiUrl = "https://api.deepseek.com/v1/chat/completions";

    public DeepSeekClient(string apiKey)
    {
        _apiKey = apiKey;
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
    }

    public async Task<string> SendToDeepSeekAsync(string userMessage)
    {
        try
        {
            var requestBody = new
            {
                model = "deepseek-chat",
                messages = new[]
                {
                    new { role = "user", content = userMessage }
                },
                temperature = 0.7,
                stream = false
            };

            string jsonRequest = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(_apiUrl, content);

            string jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response: {jsonResponse}"); // Для отладки

            response.EnsureSuccessStatusCode();

            JObject result = JObject.Parse(jsonResponse);
            return result["choices"][0]["message"]["content"].ToString();
        }
        catch (HttpRequestException ex)
        {
            return $"Ошибка HTTP: {ex.Message}";
        }
        catch (Exception ex)
        {
            return $"Ошибка: {ex.Message}";
        }
    }
}