using Microsoft.EntityFrameworkCore;
using RoaSystems.DemoKPI.Model.Model;
using RoaSystems.DemoKPI.Repository.Repositories.Interfaces;

namespace RoaSystems.DemoKPI.Repository.Repositories
{
    public class PoliticianRepository : IPolicitianRepository
    {
        private readonly ApplicationDBContext _context;

        public PoliticianRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Politician>> GetAllAsync()
        {
            return await _context.Politicians.ToListAsync();
        }

        public async Task<Politician?> GetByIdAsync(int id)
        {
            return await _context.Politicians
                    .Include(p => p.PoliticalAffiliations)
                        .ThenInclude(pa => pa.PoliticalParty)
                    .Include(p => p.PositionsOccupied)
                        .ThenInclude(i => i.Issues)
                            .ThenInclude(f => f.Flags)
                    .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Politician>> GetByNameAsync(string name)
        {
            return await _context.Politicians.Where(x => x.FirstName.Contains(name) || x.LastName.Contains(name))
                    .Include(p => p.PoliticalAffiliations)
                        .ThenInclude(pa => pa.PoliticalParty)
                    .Include(p => p.PositionsOccupied)
                        .ThenInclude(i => i.Issues)
                            .ThenInclude(f => f.Flags)
                    .ToListAsync();
        }

        public async Task<Politician> AddAsync(Politician politician)
        {
            _context.Politicians.Add(politician);
            await _context.SaveChangesAsync();
            return politician;
        }
        public async Task<bool> UpdateAsync(Politician politician)
        {
            var existing = await _context.Politicians.FindAsync(politician.Id);
            if (existing == null) return false;
            existing.FirstName = politician.FirstName;
            existing.LastName = politician.LastName;
            existing.DateOfBirth = politician.DateOfBirth;
            existing.PlaceOfBirth = politician.PlaceOfBirth;
            existing.CreatedBy = politician.CreatedBy;
            existing.CreationDate = politician.CreationDate;
            existing.Deleted = politician.Deleted;
            existing.DeletedBy = politician.DeletedBy;
            existing.DeletedDate = politician.DeletedDate;
            existing.LastUpdatedBy = politician.LastUpdatedBy;
            existing.LastUpdateDate = politician.LastUpdateDate;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Politician politician)
        {
            var existing = await _context.Politicians.FindAsync(politician.Id);
            if (existing == null) return false;
            existing.Deleted = true;
            existing.DeletedDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UnDeleteAsync(int id)
        {
            var existing = await _context.Politicians.FindAsync(id);
            if (existing == null) return false;
            existing.Deleted = false;
            existing.DeletedBy = null;
            existing.DeletedDate = null;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> KillAsync(int id)
        {
            var existing = await _context.Politicians.FindAsync(id);
            if (existing == null) return false;
            _context.Politicians.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
