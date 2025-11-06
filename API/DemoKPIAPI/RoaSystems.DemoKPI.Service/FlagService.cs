using RoaSystems.DemoKPI.Model.Model;
using RoaSystems.DemoKPI.Repository.Repositories.Interfaces;
using RoaSystems.DemoKPI.Service.Interfaces;

namespace RoaSystems.DemoKPI.Service
{
    public class FlagService : IFlagService
    {
        private readonly IFlagRepository _flagRepository;
        public FlagService(IFlagRepository flagRepository)
        {
            _flagRepository = flagRepository;
        }

        public async Task<IEnumerable<FlagResponseDTO>> GetAllAsync()
        {
            var flags = await _flagRepository.GetAllAsync();
            return flags.Select(FlagResponseDTO.ToDTO);
        }

        public async Task<FlagResponseDTO?> GetByIdAsync(int id)
        {
            var flag = await _flagRepository.GetByIdAsync(id);
            return FlagResponseDTO.ToDTO(flag);
        }

        public async Task<IEnumerable<FlagResponseDTO>> GetByIssueIdAsync(int issueId)
        {
            var flags = await _flagRepository.GetByIssueIdAsync(issueId);
            return flags.Select(FlagResponseDTO.ToDTO);
        }

        public async Task<IEnumerable<FlagResponseDTO>> GetByFlagTypeAsync(string flagType)
        {
            var flags = await _flagRepository.GetByFlagTypeAsync(flagType);
            return flags.Select(FlagResponseDTO.ToDTO);
        }

        public async Task<FlagResponseDTO> AddAsync(FlagRequestDTO flagDTO)
        {
            var flag = FlagRequestDTO.ToEntity(flagDTO);
            var addedFlag = await _flagRepository.AddAsync(flag);
            var response = FlagResponseDTO.ToDTO(addedFlag);
            return response;
        }

        public async Task<bool> DeleteAsync(FlagRequestDTO flagDTO)
        {
            var flag = FlagRequestDTO.ToEntity(flagDTO);    
            return await _flagRepository.DeleteAsync(flag);
        }

        public async Task<bool> UnDeleteAsync(int id)
        {
            return await _flagRepository.UnDeleteAsync(id);
        }

        public async Task<bool> UpdateAsync(FlagRequestDTO flagDTO)
        {
            var flag = FlagRequestDTO.ToEntity(flagDTO);    
            return await _flagRepository.UpdateAsync(flag);
        }
    }
}
