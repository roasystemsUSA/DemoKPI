using RoaSystems.DemoKPI.Model.Model.Base;

namespace RoaSystems.DemoKPI.Model.Model
{
    public partial class PoliticalParty : BaseEntity
    {
        public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Orientation { get; set; }
		public string Url { get; set; }
		public string Logo { get; set; } = string.Empty;
        public virtual ICollection<PoliticalAffiliation> PoliticalAffiliations { get; set; } = new List<PoliticalAffiliation>();
    }
}
