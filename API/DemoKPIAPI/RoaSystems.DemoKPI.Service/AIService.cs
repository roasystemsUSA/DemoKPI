using Microsoft.Extensions.Configuration;
using RoaSystems.DemoKPI.Model.Model.DTO;
using RoaSystems.DemoKPI.Model.Model.GoogleAI;
using RoaSystems.DemoKPI.Service.Interfaces;
using System.Net.Http.Json;

namespace RoaSystems.DemoKPI.Service
{
    public class AIService : IAIService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public AIService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _apiKey = config["Gemini:ApiKey"] ?? throw new Exception("The GeminiAI API Key is needed");
        }

        public async Task<ChatResponseDTO> GenerateResponseAsync(ChatRequestDTO request)
        {
            // La URL mágica de Google
            var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={_apiKey}";

            // Construimos el cuerpo del mensaje exactamente como Google lo pide
            var payload = new
            {
                contents = new[] {
                new { parts = new[] { new { text = request.Prompt } } }
            },
                generationConfig = new { temperature = request.Temperatura }
            };

            var response = await _httpClient.PostAsJsonAsync(url, payload);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error de Google: {error}");
            }

            var result = await response.Content.ReadFromJsonAsync<GeminiResponse>();

            return new ChatResponseDTO
            {
                TextoRespuesta = result?.Candidates?[0].Content?.Parts?[0].Text ?? "No recibí respuesta.",
                FechaGeneracion = DateTime.UtcNow
            };
        }
    }
}
