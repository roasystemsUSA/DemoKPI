using Microsoft.EntityFrameworkCore;
using RoaSystems.DemoKPI.Model.Model;
using RoaSystems.DemoKPI.Repository.Repositories.Interfaces;

namespace RoaSystems.DemoKPI.Repository.Repositories
{
    public class FlagRepository : IFlagRepository
    {
        private readonly ApplicationDBContext _context;

        public FlagRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Flag>> GetAllAsync()
        {
            return await _context.Flags.ToListAsync();
        }

        public async Task<Flag?> GetByIdAsync(int id)
        {
            return await _context.Flags
                .Include(f => f.Issue)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Flag>> GetByFlagTypeAsync(string name)
        {
            return await _context.Flags.Where(x => x.FlagType.Contains(name))
                .Include(f => f.Issue)
                .ToListAsync();
        }

        public async Task<IEnumerable<Flag>> GetByIssueIdAsync(int issueId)
        {
            return await _context.Flags
                .Include(f => f.Issue)
                .Where(f => f.IssueId == issueId)
                .ToListAsync();
        }

        public async Task<Flag> AddAsync(Flag flag)
        {
            _context.Flags.Add(flag);
            await _context.SaveChangesAsync();
            return flag;
        }
        public async Task<bool> UpdateAsync(Flag flag)
        {
            var existing = await _context.Flags.FindAsync(flag.Id);
            if (existing == null) return false;
            existing.FlagType = flag.FlagType;
            existing.IssueId = flag.IssueId;
            existing.CreatedBy = flag.CreatedBy;
            existing.CreationDate = flag.CreationDate;
            existing.Deleted = flag.Deleted;
            existing.DeletedBy = flag.DeletedBy;
            existing.DeletedDate = flag.DeletedDate;
            existing.LastUpdatedBy = flag.LastUpdatedBy;
            existing.LastUpdateDate = flag.LastUpdateDate;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Flag flag)
        {
            var existing = await _context.Flags.FindAsync(flag.Id);
            if (existing == null) return false;
            existing.Deleted = true;
            existing.DeletedDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UnDeleteAsync(int id)
        {
            var existing = await _context.Flags.FindAsync(id);
            if (existing == null) return false;
            existing.Deleted = false;
            existing.DeletedBy = null;
            existing.DeletedDate = null;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> KillAsync(int id)
        {
            var existing = await _context.Flags.FindAsync(id);
            if (existing == null) return false;
            _context.Flags.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}