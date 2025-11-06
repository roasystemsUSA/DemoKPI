using RoaSystems.DemoKPI.Model.Model.Base;

namespace RoaSystems.DemoKPI.Model.Model
{
    public class Politician : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PlaceOfBirth { get; set; } = null;
        public virtual ICollection<PoliticalAffiliation> PoliticalAffiliations { get; set; } = new List<PoliticalAffiliation>();
        public virtual ICollection<PositionOccupied> PositionsOccupied { get; set; } = new List<PositionOccupied>();

    }
}