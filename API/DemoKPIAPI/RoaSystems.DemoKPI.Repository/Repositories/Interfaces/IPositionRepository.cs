using RoaSystems.DemoKPI.Model.Model;

namespace RoaSystems.DemoKPI.Repository.Repositories.Interfaces
{
    public interface IPositionRepository
    {
        Task<IEnumerable<Position>> GetAllAsync();
        Task<Position?> GetByIdAsync(int id);
        Task<IEnumerable<Position>> GetByNameAsync(string name);
        Task<Position> AddAsync(Position position);
        Task<bool> UpdateAsync(Position position);
        Task<bool> DeleteAsync(Position position);
        Task<bool> UnDeleteAsync(int id);
    }
}