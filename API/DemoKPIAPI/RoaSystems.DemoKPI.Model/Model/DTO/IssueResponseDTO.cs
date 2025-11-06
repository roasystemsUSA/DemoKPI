using RoaSystems.DemoKPI.Model.Model.Base;

namespace RoaSystems.DemoKPI.Model.Model
{
    public partial class IssueResponseDTO : BaseEntity
    {
        public int Id { get; set; }
        public int PositionOccupedId { get; set; }
        public string? IssueDesc { get; set; }
        public string Status { get; set; } = null!; // Indicates if the issue was probed, or is in dispute. 
        public string? IssueSourceURL { get; set; }
        //public virtual PositionOccupied PositionOccupied { get; set; } // = new List<PositionOccupied>();
        //public virtual ICollection<FlagRequestDTO> Flags { get; set; } = new List<FlagRequestDTO>();

        public static IssueResponseDTO ToDTO(Issue issue)
        {
            return new IssueResponseDTO
            {
                Id = issue.Id,
                PositionOccupedId = issue.PositionOccupedId,
                IssueDesc = issue.IssueDesc,
                Status = issue.Status,
                IssueSourceURL = issue.IssueSourceURL
            };
        }

        public static Issue ToEntity(IssueResponseDTO issueDTO)
        {
            return new Issue
            {
                Id = issueDTO.Id,
                PositionOccupedId = issueDTO.PositionOccupedId,
                IssueDesc = issueDTO.IssueDesc,
                Status = issueDTO.Status,
                IssueSourceURL = issueDTO.IssueSourceURL
            };
        }


        public static IEnumerable<IssueResponseDTO> ToDTOList(IEnumerable<Issue> issues)
        {
            return issues.Select(p => ToDTO(p)).ToList();
        }


        public static IEnumerable<Issue> ToEntityList(IEnumerable<IssueResponseDTO> issuesDTO)
        {
            return issuesDTO.Select(p => ToEntity(p)).ToList();
        }

    }
}