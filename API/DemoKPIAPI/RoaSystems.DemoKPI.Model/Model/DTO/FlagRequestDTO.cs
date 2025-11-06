using RoaSystems.DemoKPI.Model.Model.Base;

namespace RoaSystems.DemoKPI.Model.Model
{
    public partial class FlagRequestDTO : BaseEntity
    {
		public int IssueId { get; set; }
		public string FlagType { get; set; } = null!;

        public static FlagRequestDTO ToDTO(Flag flag)
        {
            return new FlagRequestDTO
            {
                IssueId = flag.IssueId,
                FlagType = flag.FlagType
            };
        }

        public static Flag ToEntity(FlagRequestDTO flagDTO)
        {
            return new Flag
            {
                IssueId = flagDTO.IssueId,
                FlagType = flagDTO.FlagType
            };
        }


        public static IEnumerable<FlagRequestDTO> ToDTOList(IEnumerable<Flag> flags)
        {
            return flags.Select(p => ToDTO(p)).ToList();
        }


        public static IEnumerable<Flag> ToEntityList(IEnumerable<FlagRequestDTO> flagsDTO)
        {
            return flagsDTO.Select(p => ToEntity(p)).ToList();
        }

    }
}