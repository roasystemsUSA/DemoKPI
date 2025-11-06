using RoaSystems.DemoKPI.Model.Model.Base;

namespace RoaSystems.DemoKPI.Model.Model
{
    public partial class Flag : BaseEntity
    {
		public int Id { get; set; }
		public int IssueId { get; set; }
		public string FlagType { get; set; } = null!;
        public virtual Issue Issue { get; set; }

    }
}