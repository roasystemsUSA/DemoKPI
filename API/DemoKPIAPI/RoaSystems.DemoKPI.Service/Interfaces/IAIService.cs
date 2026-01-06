using RoaSystems.DemoKPI.Model.Model.DTO;

namespace RoaSystems.DemoKPI.Service.Interfaces
{
    public interface IAIService
    {
        Task<ChatResponseDTO> GenerateResponseAsync(ChatRequestDTO request);
    }
}
