using RoaSystems.DemoKPI.Model.Model.Base;

namespace RoaSystems.DemoKPI.Model.Model
{
    public partial class PositionOccupied : BaseEntity
    {
        public int Id { get; set; }
        public int PoliticianId { get; set; }
        public int PositionId { get; set; }
        public string? SeparationReasonOfficial { get; set; }
        public string? SeparationReasonReal { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? Reason { get; set; }
        public virtual Politician Politician { get; set; }
        public virtual ICollection<Issue> Issues { get; set; } = new List<Issue>();
        public virtual Position Position { get; set; }
    }
}
