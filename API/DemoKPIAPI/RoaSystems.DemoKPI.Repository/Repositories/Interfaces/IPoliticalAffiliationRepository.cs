using RoaSystems.DemoKPI.Model.Model;

namespace RoaSystems.DemoKPI.Repository.Repositories.Interfaces
{
    public interface IPoliticalAffiliationRepository
    {
        Task<IEnumerable<PoliticalAffiliation>> GetAllAsync();
        Task<PoliticalAffiliation?> GetByIdAsync(int id);


        Task<IEnumerable<PoliticalAffiliation>> GetByPoliticalPartyIdAsync(int politicalPartyId);
        Task<IEnumerable<PoliticalAffiliation>> GetByPoliticianIdAsync(int politicianId);
        Task<IEnumerable<PoliticalAffiliation>> GetByDatesAsync(DateTime? DateFrom = null, DateTime? DateTo = null);


        Task<PoliticalAffiliation> AddAsync(PoliticalAffiliation politicalAffiliation);
        Task<bool> UpdateAsync(PoliticalAffiliation politicalAffiliation);
        Task<bool> DeleteAsync(PoliticalAffiliation politicalAffiliation);
        Task<bool> UnDeleteAsync(int id);
    }

    /*
    public partial class PoliticalAffiliation : BaseEntity
    {
		public int Id { get; set; }
		public int PoliticianId { get; set; }
		public int? PoliticalPartyId { get; set; }
		public DateTime FromDate { get; set; }
		public DateTime? ToDate { get; set; }
		public string? SeparationReasonOfficial { get; set; }
		public string? SeparationReasonReal { get; set; }
        public virtual Politician Politician { get; set; } 
        public virtual PoliticalParty? PoliticalParty { get; set; }
    }
    */
}
