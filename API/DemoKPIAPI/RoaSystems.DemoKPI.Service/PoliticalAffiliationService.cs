using RoaSystems.DemoKPI.Model.Model.DTO;
using RoaSystems.DemoKPI.Repository.Repositories.Interfaces;
using RoaSystems.DemoKPI.Service.Interfaces;

namespace RoaSystems.DemoKPI.Service
{
    public class PoliticalAffiliationService : IPoliticalAffiliationService
    {
        private readonly IPoliticalAffiliationRepository _politicalAffiliationRepository;

        public PoliticalAffiliationService(IPoliticalAffiliationRepository politicalAffiliationRepository)
        {
            _politicalAffiliationRepository = politicalAffiliationRepository;
        }

        public async Task<IEnumerable<PoliticalAffiliationResponsetDTO>> GetAllAsync()
        { 
            var politicalAffiliations = await _politicalAffiliationRepository.GetAllAsync();
            return PoliticalAffiliationResponsetDTO.ToDTOList(politicalAffiliations);
        }
        
        public async Task<PoliticalAffiliationResponsetDTO?> GetByIdAsync(int id)
        {             
            var politicalAffiliation = await _politicalAffiliationRepository.GetByIdAsync(id);
            return PoliticalAffiliationResponsetDTO.ToDTO(politicalAffiliation);
        }   

        public async Task<IEnumerable<PoliticalAffiliationResponsetDTO>> GetByPoliticalPartyIdAsync(int politicalPartyId)
        {   
            var politicalAffiliations = await _politicalAffiliationRepository.GetByPoliticalPartyIdAsync(politicalPartyId);
            return PoliticalAffiliationResponsetDTO.ToDTOList(politicalAffiliations);
        }   

        public async Task<IEnumerable<PoliticalAffiliationResponsetDTO>> GetByPoliticianIdAsync(int politicianId)
        {   
            var politicalAffiliations = await _politicalAffiliationRepository.GetByPoliticianIdAsync(politicianId);
            return PoliticalAffiliationResponsetDTO.ToDTOList(politicalAffiliations);
        }

        public async Task<IEnumerable<PoliticalAffiliationResponsetDTO>> GetByDatesAsync(DateTime? DateFrom = null, DateTime? DateTo = null)
        {   var politicalAffiliations = await _politicalAffiliationRepository.GetByDatesAsync(DateFrom, DateTo);
            return PoliticalAffiliationResponsetDTO.ToDTOList(politicalAffiliations);
        }


        public async Task<PoliticalAffiliationResponsetDTO> AddAsync(PoliticalAffiliationRequestDTO politicalAffiliation)
        {             
            var entity = PoliticalAffiliationRequestDTO.ToEntity(politicalAffiliation);
            var addedEntity =  await _politicalAffiliationRepository.AddAsync(entity);
            return PoliticalAffiliationResponsetDTO.ToDTO(addedEntity);
        }   

        public async Task<bool> UpdateAsync(PoliticalAffiliationRequestDTO politicalAffiliation)
        {             
            var entity = PoliticalAffiliationRequestDTO.ToEntity(politicalAffiliation);
            return await _politicalAffiliationRepository.UpdateAsync(entity);
        }   

        public async Task<bool> DeleteAsync(PoliticalAffiliationRequestDTO politicalAffiliation)
        {             
            var entity = PoliticalAffiliationRequestDTO.ToEntity(politicalAffiliation);
            return await _politicalAffiliationRepository.DeleteAsync(entity);
        }
        public async Task<bool> UnDeleteAsync(int id)
        {
             return await _politicalAffiliationRepository.UnDeleteAsync(id);
        }
    }
}