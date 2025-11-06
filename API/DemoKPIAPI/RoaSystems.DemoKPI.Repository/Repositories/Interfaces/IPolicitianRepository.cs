using RoaSystems.DemoKPI.Model.Model;

namespace RoaSystems.DemoKPI.Repository.Repositories.Interfaces
{
    public interface IPolicitianRepository
    {
        Task<IEnumerable<Politician>> GetAllAsync();
        Task<Politician?> GetByIdAsync(int id);
        Task<IEnumerable<Politician>> GetByNameAsync(string name);
        Task<Politician> AddAsync(Politician politician);
        Task<bool> UpdateAsync(Politician politician);
        Task<bool> DeleteAsync(Politician politician    );
        Task<bool> UnDeleteAsync(int id);
    }
}