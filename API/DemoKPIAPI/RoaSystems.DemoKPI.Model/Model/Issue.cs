using RoaSystems.DemoKPI.Model.Model.Base;

namespace RoaSystems.DemoKPI.Model.Model
{
    public partial class Issue : BaseEntity
    {
		public int Id { get; set; }
		public int PositionOccupedId { get; set; }
		public string? IssueDesc { get; set; }
		public string Status { get; set; } = null!; // Indicates if the issue was probed, or is in dispute. 
		public string? IssueSourceURL { get; set; }
        public virtual PositionOccupied PositionOccupied { get; set; } // = new List<PositionOccupied>();
        public virtual ICollection<Flag> Flags { get; set; } = new List<Flag>();
    }
}