using RoaSystems.DemoKPI.Model.Model.Base;

namespace RoaSystems.DemoKPI.Model.Model
{
    public partial class Position : BaseEntity
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string? Description { get; set; }
		public string? Scope { get; set; }

        public virtual ICollection<PositionOccupied> PositionsOccupied { get; set; } = new List<PositionOccupied>();
    }
}