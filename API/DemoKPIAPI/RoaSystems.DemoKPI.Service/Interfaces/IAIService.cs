using RoaSystems.DemoKPI.Model.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoaSystems.DemoKPI.Service.Interfaces
{
    public interface IAIService
    {
        Task<ChatResponseDTO> GenerateResponseAsync(ChatRequestDTO request);
    }
}
