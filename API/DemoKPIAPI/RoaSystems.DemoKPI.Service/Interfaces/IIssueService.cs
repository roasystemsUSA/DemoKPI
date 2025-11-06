using RoaSystems.DemoKPI.Model.Model;

namespace RoaSystems.DemoKPI.Service.Interfaces
{
    public interface IIssueService
    {
        Task<IEnumerable<IssueResponseDTO>> GetAllAsync();
        Task<IssueResponseDTO?> GetByIdAsync(int id);
        Task<IEnumerable<IssueResponseDTO>> GetByPositionOccupedIdAsync(int positionOccpiedId);
        Task<IEnumerable<IssueResponseDTO>> GetByIssueDescAsync(string issueDesc);
        Task<IEnumerable<IssueResponseDTO>> GetByStatusAsync(string status);
        Task<IssueResponseDTO> AddAsync(IssueRequestDTO issueDTO);
        Task<bool> UpdateAsync(IssueRequestDTO issueDTO);
        Task<bool> DeleteAsync(IssueRequestDTO issueDTO);
        Task<bool> UnDeleteAsync(int id);
    }
}
