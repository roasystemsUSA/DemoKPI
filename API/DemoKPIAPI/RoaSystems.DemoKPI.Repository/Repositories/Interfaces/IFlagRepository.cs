using RoaSystems.DemoKPI.Model.Model;

namespace RoaSystems.DemoKPI.Repository.Repositories.Interfaces
{
    public interface IFlagRepository
    {
        Task<IEnumerable<Flag>> GetAllAsync();
        Task<Flag?> GetByIdAsync(int id);
        Task<IEnumerable<Flag>> GetByIssueIdAsync(int issueId);
        Task<IEnumerable<Flag>> GetByFlagTypeAsync(string flagType);
        Task<Flag> AddAsync(Flag flag);
        Task<bool> UpdateAsync(Flag flag);
        Task<bool> DeleteAsync(Flag flag);
        Task<bool> UnDeleteAsync(int id);
    }
}