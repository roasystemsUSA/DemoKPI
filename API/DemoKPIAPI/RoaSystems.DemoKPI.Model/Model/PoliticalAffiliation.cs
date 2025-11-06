using RoaSystems.DemoKPI.Model.Model.Base;

namespace RoaSystems.DemoKPI.Model.Model
{
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
}