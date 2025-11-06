using RoaSystems.DemoKPI.Model.Model.Base;

namespace RoaSystems.DemoKPI.Model.Model.DTO
{
	public partial class PoliticalPartyRequestDTO : BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Orientation { get; set; }
		public string Url { get; set; }
		public string Logo { get; set; } = string.Empty;

		public static PoliticalPartyRequestDTO ToDTO(PoliticalParty politicalParty)
		{
			return new PoliticalPartyRequestDTO
			{
				Name = politicalParty.Name,
				Description = politicalParty.Description,
				Orientation = politicalParty.Orientation,
				Url = politicalParty.Url,
				Logo = politicalParty.Logo
			};
		}

		public static PoliticalParty ToEntity(PoliticalPartyRequestDTO politicalPartyDTO)
		{
			return new PoliticalParty
			{
				Name = politicalPartyDTO.Name,
				Description = politicalPartyDTO.Description,
				Orientation = politicalPartyDTO.Orientation,
				Url = politicalPartyDTO.Url,
				Logo = politicalPartyDTO.Logo
			};

		}

		public static IEnumerable<PoliticalPartyRequestDTO> ToDTOList(IEnumerable<PoliticalParty> politicalPartiesEntities)
		{
			return politicalPartiesEntities.Select(p => ToDTO(p)).ToList();
        }


		public static IEnumerable<PoliticalParty> ToEntityList(IEnumerable<PoliticalPartyRequestDTO> politicalPartiesDTO)
		{
			return politicalPartiesDTO.Select(p => ToEntity(p)).ToList();
		}
    }
}