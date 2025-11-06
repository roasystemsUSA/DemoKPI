using RoaSystems.DemoKPI.Model.Model;

namespace RoaSystems.DemoKPI.Repository.Repositories.Interfaces
{
    public interface IPositionOccupiedRepository
    {
        Task<IEnumerable<PositionOccupied>> GetAllAsync();
        Task<PositionOccupied?> GetByIdAsync(int id);

        Task<IEnumerable<PositionOccupied>> GetByPoliticianIdAsync(int politicianId);
        Task<IEnumerable<PositionOccupied>> GetByPositionIdAsync(int positionId);
        Task<IEnumerable<PositionOccupied>> GetByDatesAsync(DateTime? DateFrom = null, DateTime? DateTo = null);

        Task<PositionOccupied> AddAsync(PositionOccupied positionOccupied);
        Task<bool> UpdateAsync(PositionOccupied positionOccupied);
        Task<bool> DeleteAsync(PositionOccupied positionOccupied);
        Task<bool> UnDeleteAsync(int id);
    }
}