using RoaSystems.DemoKPI.Model.Model.Base;

namespace RoaSystems.DemoKPI.Model.Model
{
    public partial class IssueRequestDTO : BaseEntity
    {
        // public int Id { get; set; }
        public int PositionOccupedId { get; set; }
        public string? IssueDesc { get; set; }
        public string Status { get; set; } = null!; // Indicates if the issue was probed, or is in dispute. 
        public string? IssueSourceURL { get; set; }

        public static IssueRequestDTO ToDTO(Issue issue)
        {
            return new IssueRequestDTO
            {
                PositionOccupedId = issue.PositionOccupedId,
                IssueDesc = issue.IssueDesc,
                Status = issue.Status,
                IssueSourceURL = issue.IssueSourceURL
            };
        }

        public static Issue ToEntity(IssueRequestDTO issueDTO)
        {
            return new Issue
            {
                PositionOccupedId = issueDTO.PositionOccupedId,
                IssueDesc = issueDTO.IssueDesc,
                Status = issueDTO.Status,
                IssueSourceURL = issueDTO.IssueSourceURL
            };
        }


        public static IEnumerable<IssueRequestDTO> ToDTOList(IEnumerable<Issue> issues)
        {
            return issues.Select(p => ToDTO(p)).ToList();
        }


        public static IEnumerable<Issue> ToEntityList(IEnumerable<IssueRequestDTO> issuesDTO)
        {
            return issuesDTO.Select(p => ToEntity(p)).ToList();
        }

    }
}