using RoaSystems.DemoKPI.Model.Model;

namespace RoaSystems.DemoKPI.Repository.Repositories.Interfaces
{
    public interface IPoliticalPartyRepository
    {
        Task<IEnumerable<PoliticalParty>> GetAllAsync();
        Task<PoliticalParty?> GetByIdAsync(int id);
        Task<IEnumerable<PoliticalParty>> GetByNameAsync(string name);
        Task<PoliticalParty> AddAsync(PoliticalParty application);
        Task<bool> UpdateAsync(PoliticalParty application);
        Task<bool> DeleteAsync(PoliticalParty politicalParty);
        Task<bool> UnDeleteAsync(int id);
    }
}
