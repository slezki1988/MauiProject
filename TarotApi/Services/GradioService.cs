using System.Net.Http;
using System.Text;

public class GradioService
{
    private readonly HttpClient _httpClient;

    public GradioService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetPredictionAsync(PredictionRequest request)
    {
        // Формируем строку запроса из параметров PredictionRequest
        var queryString = new StringBuilder("?");

        queryString.Append("FeedbackEnabled=" + request.FeedbackEnabled);
        queryString.Append("&MaxFeedbackImgs=" + request.MaxFeedbackImgs);
        queryString.Append("&Prompt=" + Uri.EscapeDataString(request.Prompt));
        queryString.Append("&NegativePrompt=" + Uri.EscapeDataString(request.NegativePrompt));
        queryString.Append("&SamplingSteps=" + request.SamplingSteps);
        queryString.Append("&CfgScale=" + request.CfgScale);
        queryString.Append("&FeedbackStart=" + request.FeedbackStart);
        queryString.Append("&FeedbackEnd=" + request.FeedbackEnd);
        queryString.Append("&FeedbackMinWeight=" + request.FeedbackMinWeight);
        queryString.Append("&FeedbackMaxWeight=" + request.FeedbackMaxWeight);
        queryString.Append("&NegFeedbackScale=" + request.NegFeedbackScale);
        queryString.Append("&BatchSize=" + request.BatchSize);
        queryString.Append("&Seed=" + request.Seed);
        queryString.Append("&FnIndex=" + request.FnIndex);  
        // ... и так далее для всех параметров

        var url = "https://dvruette-fabric--dxn4w.hf.space/" + queryString.ToString();

        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        else
        {
            // Здесь можно добавить обработку ошибок или логирование
            return null;
        }
    }
}