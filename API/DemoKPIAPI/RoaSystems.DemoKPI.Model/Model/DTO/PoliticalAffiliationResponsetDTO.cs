using RoaSystems.DemoKPI.Model.Model.Base;

namespace RoaSystems.DemoKPI.Model.Model.DTO
{
    public partial class PoliticalAffiliationResponsetDTO : BaseEntity
    {
        public int Id { get; set; }
        public int PoliticianId { get; set; }
        public int? PoliticalPartyId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? SeparationReasonOfficial { get; set; }
        public string? SeparationReasonReal { get; set; }
        // public virtual Politician Politician { get; set; }
        public virtual PoliticalPartyResponsetDTO? PoliticalParty { get; set; }

        public static PoliticalAffiliationResponsetDTO ToDTO(PoliticalAffiliation politicalAffiliation)
        {
            return new PoliticalAffiliationResponsetDTO
            {
                Id = politicalAffiliation.Id,
                PoliticianId = politicalAffiliation.PoliticianId,
                PoliticalPartyId = politicalAffiliation.PoliticalPartyId,
                FromDate = politicalAffiliation.FromDate,
                ToDate = politicalAffiliation.ToDate,
                SeparationReasonOfficial = politicalAffiliation.SeparationReasonOfficial,
                SeparationReasonReal = politicalAffiliation.SeparationReasonReal,
                PoliticalParty = politicalAffiliation.PoliticalParty != null ? PoliticalPartyResponsetDTO.ToDTO(politicalAffiliation.PoliticalParty) : null
            };
        }

        public static PoliticalAffiliation ToEntity(PoliticalAffiliationResponsetDTO politicalAffiliationDTO)
        {
            return new PoliticalAffiliation
            {
                Id = politicalAffiliationDTO.Id,
                PoliticianId = politicalAffiliationDTO.PoliticianId,
                PoliticalPartyId = politicalAffiliationDTO.PoliticalPartyId,
                FromDate = politicalAffiliationDTO.FromDate,
                ToDate = politicalAffiliationDTO.ToDate,
                SeparationReasonOfficial = politicalAffiliationDTO.SeparationReasonOfficial,
                SeparationReasonReal = politicalAffiliationDTO.SeparationReasonReal                
            };

        }

        public static IEnumerable<PoliticalAffiliationResponsetDTO> ToDTOList(IEnumerable<PoliticalAffiliation> politicalAffiliationsEntities)
        {
            return politicalAffiliationsEntities.Select(p => ToDTO(p)).ToList();
        }


        public static IEnumerable<PoliticalAffiliation> ToEntityList(IEnumerable<PoliticalAffiliationResponsetDTO> politicalAffiliationsDTO)
        {
            return politicalAffiliationsDTO.Select(p => ToEntity(p)).ToList();
        }

    }
}
