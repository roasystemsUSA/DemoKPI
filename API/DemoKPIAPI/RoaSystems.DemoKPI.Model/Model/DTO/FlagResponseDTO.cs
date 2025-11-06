using RoaSystems.DemoKPI.Model.Model.Base;

namespace RoaSystems.DemoKPI.Model.Model
{
    public partial class FlagResponseDTO : BaseEntity
    {
		public int Id { get; set; }
		public int IssueId { get; set; }
		public string FlagType { get; set; } = null!;

        public static FlagResponseDTO ToDTO(Flag flag)
        {
            return new FlagResponseDTO
            {
                Id = flag.Id,
                IssueId = flag.IssueId,
                FlagType = flag.FlagType
            };
        }

        public static Flag ToEntity(FlagResponseDTO flagDTO)
        {
            return new Flag
            {
                Id = flagDTO.Id,
                IssueId = flagDTO.IssueId,
                FlagType = flagDTO.FlagType
            };
        }


        public static IEnumerable<FlagResponseDTO> ToDTOList(IEnumerable<Flag> flags)
        {
            return flags.Select(p => ToDTO(p)).ToList();
        }


        public static IEnumerable<Flag> ToEntityList(IEnumerable<FlagResponseDTO> flagsDTO)
        {
            return flagsDTO.Select(p => ToEntity(p)).ToList();
        }
    }
}