using Microsoft.EntityFrameworkCore;
using RoaSystems.DemoKPI.Model.Model;
using RoaSystems.DemoKPI.Repository.Repositories.Interfaces;

namespace RoaSystems.DemoKPI.Repository.Repositories
{
    public class PoliticalAffiliationRepository : IPoliticalAffiliationRepository
    {
        private readonly ApplicationDBContext _context;

        public PoliticalAffiliationRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PoliticalAffiliation>> GetAllAsync()
        {
            return await _context.PoliticalAffiliations.ToListAsync();
        }

        public async Task<PoliticalAffiliation?> GetByIdAsync(int id)
        {
            return await _context.PoliticalAffiliations
                .Include(p => p.PoliticalParty)
                .Include(p => p.Politician)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IEnumerable<PoliticalAffiliation>> GetByPoliticalPartyIdAsync(int politicalPartyId)
        {
            return await _context.PoliticalAffiliations
                .Where(x => x.PoliticalPartyId == politicalPartyId)
                .Include(p => p.PoliticalParty)
                .Include(p => p.Politician)
                .ToListAsync();
        }

        public async Task<IEnumerable<PoliticalAffiliation>> GetByPoliticianIdAsync(int politicianId)
        {
            return await _context.PoliticalAffiliations
                .Where(x => x.PoliticianId == politicianId)
                .Include(p => p.PoliticalParty)
                .Include(p => p.Politician)
                .ToListAsync();
        }

        public async Task<IEnumerable<PoliticalAffiliation>> GetByDatesAsync(DateTime? DateFrom = null, DateTime? DateTo = null)
        {
            var query = _context.PoliticalAffiliations.AsQueryable();
            if (DateFrom.HasValue)
            {
                query = query.Where(x => x.FromDate >= DateFrom.Value);
            }
            if (DateTo.HasValue)
            {
                query = query.Where(x => x.ToDate <= DateTo.Value);
            }
            return await query
                .Include(p => p.PoliticalParty)
                .Include(p => p.Politician)
                .ToListAsync();
        }

        public async Task<PoliticalAffiliation> AddAsync(PoliticalAffiliation politicalAffiliation)
        {
            _context.PoliticalAffiliations.Add(politicalAffiliation);
            await _context.SaveChangesAsync();
            return politicalAffiliation;
        }
        public async Task<bool> UpdateAsync(PoliticalAffiliation politicalAffiliation)
        {
            var existing = await _context.PoliticalAffiliations.FindAsync(politicalAffiliation.Id);
            if (existing == null) return false;
            existing.FromDate = politicalAffiliation.FromDate;
            existing.ToDate = politicalAffiliation.ToDate;
            existing.SeparationReasonOfficial = politicalAffiliation.SeparationReasonOfficial;
            existing.SeparationReasonReal = politicalAffiliation.SeparationReasonReal;
            existing.PoliticalPartyId = politicalAffiliation.PoliticalPartyId;
            existing.PoliticianId = politicalAffiliation.PoliticianId;
            existing.DeletedDate = politicalAffiliation.DeletedDate;
            existing.LastUpdatedBy = politicalAffiliation.LastUpdatedBy;
            existing.LastUpdateDate = politicalAffiliation.LastUpdateDate;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(PoliticalAffiliation politicalAffiliation)
        {
            var existing = await _context.PoliticalAffiliations.FindAsync(politicalAffiliation.Id);
            if (existing == null) return false;
            existing.Deleted = true;
            existing.DeletedDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UnDeleteAsync(int id)
        {
            var existing = await _context.PoliticalAffiliations.FindAsync(id);
            if (existing == null) return false;
            existing.Deleted = false;
            existing.DeletedBy = null;
            existing.DeletedDate = null;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> KillAsync(int id)
        {
            var existing = await _context.PoliticalAffiliations.FindAsync(id);
            if (existing == null) return false;
            _context.PoliticalAffiliations.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
