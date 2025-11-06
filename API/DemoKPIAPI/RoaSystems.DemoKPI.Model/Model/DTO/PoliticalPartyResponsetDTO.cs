using RoaSystems.DemoKPI.Model.Model.Base;

namespace RoaSystems.DemoKPI.Model.Model.DTO
{
    public partial class PoliticalPartyResponsetDTO : BaseEntity
    {
        public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Orientation { get; set; }
		public string Url { get; set; }
		public string Logo { get; set; } = string.Empty;

        public static PoliticalPartyResponsetDTO ToDTO(PoliticalParty politicalParty)
        {
            return new PoliticalPartyResponsetDTO
            {
                Id = politicalParty.Id,
                Name = politicalParty.Name,
                Description = politicalParty.Description,
                Orientation = politicalParty.Orientation,
                Url = politicalParty.Url,
                Logo = politicalParty.Logo
            };
        }

        public static PoliticalParty ToEntity(PoliticalPartyResponsetDTO politicalPartyDTO)
        {
            return new PoliticalParty
            {
                Id = politicalPartyDTO.Id,
                Name = politicalPartyDTO.Name,
                Description = politicalPartyDTO.Description,
                Orientation = politicalPartyDTO.Orientation,
                Url = politicalPartyDTO.Url,
                Logo = politicalPartyDTO.Logo
            };

        }

        public static IEnumerable<PoliticalPartyResponsetDTO> ToDTOList(IEnumerable<PoliticalParty> politicalPartiesEntities)
        {
            return politicalPartiesEntities.Select(p => ToDTO(p)).ToList();
        }


        public static IEnumerable<PoliticalParty> ToEntityList(IEnumerable<PoliticalPartyResponsetDTO> politicalPartiesDTO)
        {
            return politicalPartiesDTO.Select(p => ToEntity(p)).ToList();
        }

    }
}
