using Microsoft.EntityFrameworkCore;
using RoaSystems.DemoKPI.Model.Model;
using RoaSystems.DemoKPI.Repository.Repositories.Interfaces;

namespace RoaSystems.DemoKPI.Repository.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        private readonly ApplicationDBContext _context;

        public IssueRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Issue>> GetAllAsync()
        {
            return await _context.Issues.ToListAsync();
        }

        public async Task<Issue?> GetByIdAsync(int id)
        {
            return await _context.Issues
                .Include(p => p.Flags)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Issue>> GetByPositionOccupedIdAsync(int positionOccupedId)
        {
            return await _context.Issues.Where(x => x.PositionOccupedId == positionOccupedId)
                .Include(p => p.Flags)
                .ToListAsync();
        }

        public async Task<IEnumerable<Issue>> GetByIssueDescAsync(string issueDesc)
        {
            return await _context.Issues.Where(x => x.IssueDesc.Contains(issueDesc))
                .Include(p => p.Flags)
                .ToListAsync();
        }

        public async Task<IEnumerable<Issue>> GetByStatusAsync(string status)
        {
            return await _context.Issues.Where(x => x.Status.Contains(status))
                .Include(p => p.Flags)
                .ToListAsync();
        }

        public async Task<Issue> AddAsync(Issue issue)
        {
            _context.Issues.Add(issue);
            await _context.SaveChangesAsync();
            return issue;
        }

        public async Task<bool> UpdateAsync(Issue issue)
        {
            var existing = await _context.Issues.FindAsync(issue.Id);
            if (existing == null) return false;
            existing.IssueDesc = issue.IssueDesc;
            existing.Status = issue.Status;
            existing.IssueSourceURL = issue.IssueSourceURL;
            existing.PositionOccupedId = issue.PositionOccupedId;
            existing.CreatedBy = issue.CreatedBy;
            existing.CreationDate = issue.CreationDate;
            existing.Deleted = issue.Deleted;
            existing.DeletedBy = issue.DeletedBy;
            existing.DeletedDate = issue.DeletedDate;
            existing.LastUpdatedBy = issue.LastUpdatedBy;
            existing.LastUpdateDate = issue.LastUpdateDate;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Issue issue)
        {
            var existing = await _context.Issues.FindAsync(issue.Id);
            if (existing == null) return false;
            existing.Deleted = true;
            existing.DeletedDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UnDeleteAsync(int id)
        {
            var existing = await _context.Issues.FindAsync(id);
            if (existing == null) return false;
            existing.Deleted = false;
            existing.DeletedBy = null;
            existing.DeletedDate = null;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> KillAsync(int id)
        {
            var existing = await _context.PoliticalParties.FindAsync(id);
            if (existing == null) return false;
            _context.PoliticalParties.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
