using RoaSystems.DemoKPI.Model.Model;
using RoaSystems.DemoKPI.Repository.Repositories.Interfaces;
using RoaSystems.DemoKPI.Service.Interfaces;

namespace RoaSystems.DemoKPI.Service
{
    public class IssueService : IIssueService
    {
        private readonly IIssueRepository _issueRepository;

        public IssueService(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }

        public async Task<bool> DeleteAsync(IssueRequestDTO issueDTO)
        {
            var issue = IssueRequestDTO.ToEntity(issueDTO);
            return await _issueRepository.DeleteAsync(issue);
        }

        public async Task<IEnumerable<IssueResponseDTO>> GetAllAsync()
        {
            var issues = await _issueRepository.GetAllAsync();
            return issues.Select(IssueResponseDTO.ToDTO);  
        }

        public async Task<IssueResponseDTO?> GetByIdAsync(int id)
        {
            var issue = await _issueRepository.GetByIdAsync(id);
            return IssueResponseDTO.ToDTO(issue);
        }

        public async Task<IEnumerable<IssueResponseDTO>> GetByIssueDescAsync(string issueDesc)
        {
            var issues = await _issueRepository.GetByIssueDescAsync(issueDesc);
            return issues.Select(IssueResponseDTO.ToDTO);
        }

        public async Task<IEnumerable<IssueResponseDTO>> GetByPositionOccupedIdAsync(int positionOccpiedId)
        {
            var issues = await _issueRepository.GetByPositionOccupedIdAsync(positionOccpiedId);
            return issues.Select(IssueResponseDTO.ToDTO);
        }

        public async Task<IEnumerable<IssueResponseDTO>> GetByStatusAsync(string status)
        {
            var issues = await _issueRepository.GetByStatusAsync(status);
            return issues.Select(IssueResponseDTO.ToDTO);
        }

        public async Task<IssueResponseDTO> AddAsync(IssueRequestDTO issueDTO)
        {
            var issue = await _issueRepository.AddAsync(IssueRequestDTO.ToEntity(issueDTO));
            return IssueResponseDTO.ToDTO(issue);
        }

        public async Task<bool> UnDeleteAsync(int id)
        {
            var result = await _issueRepository.UnDeleteAsync(id);
            return result;
        }

        public async Task<bool> UpdateAsync(IssueRequestDTO issueDTO)
        {
            var result = await _issueRepository.UpdateAsync(IssueRequestDTO.ToEntity(issueDTO));
            return result;
        }
    }
}