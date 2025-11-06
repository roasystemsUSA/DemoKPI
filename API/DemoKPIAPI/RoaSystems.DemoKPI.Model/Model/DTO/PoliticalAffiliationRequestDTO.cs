using RoaSystems.DemoKPI.Model.Model.Base;

namespace RoaSystems.DemoKPI.Model.Model.DTO
{
	public partial class PoliticalAffiliationRequestDTO : BaseEntity
	{
        // public int Id { get; set; }
        public int PoliticianId { get; set; }
        public int? PoliticalPartyId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? SeparationReasonOfficial { get; set; }
        public string? SeparationReasonReal { get; set; }
        // public virtual Politician Politician { get; set; }
        //public virtual PoliticalPartyRequestDTO? PoliticalParty { get; set; }

        public static PoliticalAffiliationRequestDTO ToDTO(PoliticalAffiliation politicalAffiliation)
		{
			return new PoliticalAffiliationRequestDTO
            {
				PoliticianId = politicalAffiliation.PoliticianId,
				PoliticalPartyId = politicalAffiliation.PoliticalPartyId,
				FromDate = politicalAffiliation.FromDate,
				ToDate = politicalAffiliation.ToDate,
				SeparationReasonOfficial = politicalAffiliation.SeparationReasonOfficial,
				SeparationReasonReal = politicalAffiliation.SeparationReasonReal
			};
		}

		public static PoliticalAffiliation ToEntity(PoliticalAffiliationRequestDTO politicalAffiliationRequestDTO)
		{
			return new PoliticalAffiliation
            {
				PoliticianId = politicalAffiliationRequestDTO.PoliticianId,
				PoliticalPartyId = politicalAffiliationRequestDTO.PoliticalPartyId,
				FromDate = politicalAffiliationRequestDTO.FromDate,
				ToDate = politicalAffiliationRequestDTO.ToDate,
				SeparationReasonOfficial = politicalAffiliationRequestDTO.SeparationReasonOfficial,
				SeparationReasonReal = politicalAffiliationRequestDTO.SeparationReasonReal
            };
		}

		public static IEnumerable<PoliticalAffiliationRequestDTO> ToDTOList(IEnumerable<PoliticalAffiliation> politicalAffiliationsEntities)
		{
			return politicalAffiliationsEntities.Select(p => ToDTO(p)).ToList();
        }


		public static IEnumerable<PoliticalAffiliation> ToEntityList(IEnumerable<PoliticalAffiliationRequestDTO> politicalAffiliationsDTO)
		{
			return politicalAffiliationsDTO.Select(p => ToEntity(p)).ToList();
		}
    }
}