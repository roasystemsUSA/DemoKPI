using Google.GenAI;
using Microsoft.Extensions.Configuration;
using RoaSystems.DemoKPI.Model.Model.DTO;
using RoaSystems.DemoKPI.Service.Interfaces;

namespace RoaSystems.DemoKPI.Service
{
    public class AIService : IAIService
    {
        private readonly string _apiKey;

        public AIService(IConfiguration config)
        {
            _apiKey = config["Gemini:ApiKey"] ?? throw new Exception("The GeminiAI API Key is needed");
        }

        public async Task<ChatResponseDTO> GenerateResponseAsync(ChatRequestDTO request)
        {
            var client = new Client(apiKey: _apiKey);
            var response = await client.Models.GenerateContentAsync(
              model: "gemini-2.5-flash", contents: request.Prompt
            );
            var result = new ChatResponseDTO
            {
                TextoRespuesta = response.Candidates[0].Content.Parts[0].Text,
                ModeloUtilizado = "gemini-2.5-flash",
                FechaGeneracion = DateTime.UtcNow
            };
            return result;
        }

    }
}
