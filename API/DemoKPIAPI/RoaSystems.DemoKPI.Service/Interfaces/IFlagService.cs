using RoaSystems.DemoKPI.Model.Model;

namespace RoaSystems.DemoKPI.Service.Interfaces
{
    public interface IFlagService
    {
        Task<IEnumerable<FlagResponseDTO>> GetAllAsync();
        Task<FlagResponseDTO?> GetByIdAsync(int id);
        Task<IEnumerable<FlagResponseDTO>> GetByIssueIdAsync(int issueId);
        Task<IEnumerable<FlagResponseDTO>> GetByFlagTypeAsync(string flagType);
        Task<FlagResponseDTO> AddAsync(FlagRequestDTO flag);
        Task<bool> UpdateAsync(FlagRequestDTO flag);
        Task<bool> DeleteAsync(FlagRequestDTO flag);
        Task<bool> UnDeleteAsync(int id);
    }
}
