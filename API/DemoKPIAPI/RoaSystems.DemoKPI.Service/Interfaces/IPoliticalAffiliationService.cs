using RoaSystems.DemoKPI.Model.Model.DTO;

namespace RoaSystems.DemoKPI.Service.Interfaces
{
    public interface IPoliticalAffiliationService
    {
        Task<IEnumerable<PoliticalAffiliationResponsetDTO>> GetAllAsync();
        Task<PoliticalAffiliationResponsetDTO?> GetByIdAsync(int id);


        Task<IEnumerable<PoliticalAffiliationResponsetDTO>> GetByPoliticalPartyIdAsync(int politicalPartyId);
        Task<IEnumerable<PoliticalAffiliationResponsetDTO>> GetByPoliticianIdAsync(int politicianId);
        Task<IEnumerable<PoliticalAffiliationResponsetDTO>> GetByDatesAsync(DateTime? DateFrom = null, DateTime? DateTo = null);


        Task<PoliticalAffiliationResponsetDTO> AddAsync(PoliticalAffiliationRequestDTO politicalAffiliation);
        Task<bool> UpdateAsync(PoliticalAffiliationRequestDTO politicalAffiliation);
        Task<bool> DeleteAsync(PoliticalAffiliationRequestDTO politicalAffiliation);
        Task<bool> UnDeleteAsync(int id);
    }
}
