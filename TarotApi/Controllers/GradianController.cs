using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;

public class GradioResponse
{
    public string ImagePath { get; set; }
    public int Value { get; set; }
}
public class PredictionRequest
{
    public bool FeedbackEnabled { get; set; }
    public int MaxFeedbackImgs { get; set; }
    public string Prompt { get; set; }
    public string NegativePrompt { get; set; }
    public int SamplingSteps { get; set; }
    public float CfgScale { get; set; }
    public float FeedbackStart { get; set; }
    public float FeedbackEnd { get; set; }
    public float FeedbackMinWeight { get; set; }
    public float FeedbackMaxWeight { get; set; }
    public float NegFeedbackScale { get; set; }
    public int BatchSize { get; set; }
    public int Seed { get; set; }
    public int FnIndex { get; set; }
}

[ApiController]
[Route("api/predictions2")]
public class SomeController : ControllerBase
{
    // Сервис для взаимодействия с Gradio
    private readonly GradioService _gradioService;

    // Конструктор контроллера, который принимает GradioService через механизм внедрения зависимостей
    public SomeController(GradioService gradioService)
    {
        _gradioService = gradioService;
    }

    [HttpGet("GetPrediction")]
    public async Task<IActionResult> GetPrediction([FromQuery] PredictionRequest request)
    {
        
        PredictionRequest req1 = new PredictionRequest();
        req1.FeedbackStart = 1;
        req1.FeedbackEnabled = true;
        req1.MaxFeedbackImgs = 1;
        req1.Prompt = "chicken";
        req1.NegativePrompt = "cat";
        req1.SamplingSteps = 1;
        req1.CfgScale = 1;
        req1.FeedbackEnd = 1;
        req1.FeedbackMinWeight = 1;
        req1.FeedbackMaxWeight = 1;
        req1.NegFeedbackScale = 1;
        req1.BatchSize = 4;
        req1.Seed = 1;
        req1.FnIndex = 0;

        var result = await _gradioService.GetPredictionAsync(req1);
        Console.WriteLine(result);
        if (result != null)
        {
            var gradioResponse = JsonSerializer.Deserialize<GradioResponse>(result.ToString());
           
            return Ok(gradioResponse);
        }

        return BadRequest("Error getting prediction from Gradio");

    }
}