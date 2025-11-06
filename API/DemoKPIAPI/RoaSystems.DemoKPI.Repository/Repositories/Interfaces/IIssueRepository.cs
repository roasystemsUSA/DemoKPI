using RoaSystems.DemoKPI.Model.Model;

namespace RoaSystems.DemoKPI.Repository.Repositories.Interfaces
{
    public interface IIssueRepository
    {
        Task<IEnumerable<Issue>> GetAllAsync();
        Task<Issue?> GetByIdAsync(int id);
        Task<IEnumerable<Issue>> GetByPositionOccupedIdAsync(int positionOccpiedId);
        Task<IEnumerable<Issue>> GetByIssueDescAsync(string issueDesc);
        Task<IEnumerable<Issue>> GetByStatusAsync(string status);
        Task<Issue> AddAsync(Issue issue);
        Task<bool> UpdateAsync(Issue issue);
        Task<bool> DeleteAsync(Issue issue);
        Task<bool> UnDeleteAsync(int id);
    }
}
