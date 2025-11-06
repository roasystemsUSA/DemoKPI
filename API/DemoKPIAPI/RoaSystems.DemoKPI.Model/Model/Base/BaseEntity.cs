namespace RoaSystems.DemoKPI.Model.Model.Base
{
    public partial class BaseEntity
    {
        public string CreatedBy { get; set; } = null!;

        public DateTime CreationDate { get; set; }

        public string? LastUpdatedBy { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public bool Deleted { get; set; }

        public string? DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }
    }
}
