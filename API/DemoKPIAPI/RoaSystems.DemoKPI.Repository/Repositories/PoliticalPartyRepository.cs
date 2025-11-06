using Microsoft.EntityFrameworkCore;
using RoaSystems.DemoKPI.Model.Model;
using RoaSystems.DemoKPI.Repository.Repositories.Interfaces;

namespace RoaSystems.DemoKPI.Repository.Repositories
{
    public class PoliticalPartyRepository : IPoliticalPartyRepository
    {
        private readonly ApplicationDBContext _context;

        public PoliticalPartyRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PoliticalParty>> GetAllAsync()
        {
            return await _context.PoliticalParties.ToListAsync();
        }

        public async Task<PoliticalParty?> GetByIdAsync(int id)
        {
            return await _context.PoliticalParties
                .Include(p => p.PoliticalAffiliations)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IEnumerable<PoliticalParty>> GetByNameAsync(string name)
        {
            return await _context.PoliticalParties.Where(x => x.Name.Contains(name))
                .Include(p => p.PoliticalAffiliations)
                .ToListAsync();
        }

        public async Task<PoliticalParty> AddAsync(PoliticalParty politicalParty)
        {
            _context.PoliticalParties.Add(politicalParty);
            await _context.SaveChangesAsync();
            return politicalParty;
        }
        public async Task<bool> UpdateAsync(PoliticalParty politicalParty)
        {
            var existing = await _context.PoliticalParties.FindAsync(politicalParty.Id);
            if (existing == null) return false;
            existing.Description = politicalParty.Description;
            existing.Name = politicalParty.Name;
            existing.Url = politicalParty.Url;
            existing.CreatedBy = politicalParty.CreatedBy;
            existing.CreationDate = politicalParty.CreationDate;
            existing.Deleted = politicalParty.Deleted;
            existing.DeletedBy = politicalParty.DeletedBy;
            existing.DeletedDate = politicalParty.DeletedDate;
            existing.LastUpdatedBy = politicalParty.LastUpdatedBy;
            existing.LastUpdateDate = politicalParty.LastUpdateDate;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(PoliticalParty politicalParty)
        {
            var existing = await _context.PoliticalParties.FindAsync(politicalParty.Id);
            if (existing == null) return false;
            existing.Deleted = true;
            existing.DeletedDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UnDeleteAsync(int id)
        {
            var existing = await _context.PoliticalParties.FindAsync(id);
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
