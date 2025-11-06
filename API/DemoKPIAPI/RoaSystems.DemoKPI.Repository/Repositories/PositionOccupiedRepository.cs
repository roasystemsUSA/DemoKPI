using Microsoft.EntityFrameworkCore;
using RoaSystems.DemoKPI.Model.Model;
using RoaSystems.DemoKPI.Repository.Repositories.Interfaces;

namespace RoaSystems.DemoKPI.Repository.Repositories
{
    public class PositionOccupiedRepository : IPositionOccupiedRepository
    {
        private readonly ApplicationDBContext _context;

        public PositionOccupiedRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PositionOccupied>> GetAllAsync()
        {
            return await _context.PositionsOccupied.ToListAsync();
        }

        public async Task<PositionOccupied?> GetByIdAsync(int id)
        {
            return await _context.PositionsOccupied
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<PositionOccupied>> GetByPoliticianIdAsync(int politicianId)
        {
            return await _context.PositionsOccupied.Where(x => x.PoliticianId == politicianId)
                .ToListAsync();
        }

        public async Task<IEnumerable<PositionOccupied>> GetByPositionIdAsync(int positionId)
        {
            return await _context.PositionsOccupied.Where(x => x.PositionId == positionId)
                .ToListAsync();
        }

        public async Task<IEnumerable<PositionOccupied>> GetByDatesAsync(DateTime? DateFrom = null, DateTime? DateTo = null)
        {
            var query = _context.PositionsOccupied.AsQueryable();
            if (DateFrom.HasValue)
            {
                query = query.Where(po => po.FromDate >= DateFrom.Value);
            }
            if (DateTo.HasValue)
            {
                query = query.Where(po => po.ToDate <= DateTo.Value || po.ToDate == null);
            }
            return await query.ToListAsync();
        }

        public async Task<PositionOccupied> AddAsync(PositionOccupied positionOccupied)
        {
            _context.PositionsOccupied.Add(positionOccupied);
            await _context.SaveChangesAsync();
            return positionOccupied;
        }

        public async Task<bool> UpdateAsync(PositionOccupied positionOccupied)
        {
            var existing = await _context.PositionsOccupied.FindAsync(positionOccupied.Id);
            if (existing == null) return false;
            existing.PoliticianId = positionOccupied.PoliticianId;
            existing.PositionId = positionOccupied.PositionId;
            existing.SeparationReasonOfficial = positionOccupied.SeparationReasonOfficial;
            existing.SeparationReasonReal = positionOccupied.SeparationReasonReal;
            existing.FromDate = positionOccupied.FromDate;
            existing.ToDate = positionOccupied.ToDate;
            existing.Reason = positionOccupied.Reason;
            existing.CreatedBy = positionOccupied.CreatedBy;
            existing.CreationDate = positionOccupied.CreationDate;
            existing.Deleted = positionOccupied.Deleted;
            existing.DeletedBy = positionOccupied.DeletedBy;
            existing.DeletedDate = positionOccupied.DeletedDate;
            existing.LastUpdatedBy = positionOccupied.LastUpdatedBy;
            existing.LastUpdateDate = positionOccupied.LastUpdateDate;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(PositionOccupied positionOccupied)
        {
            var existing = await _context.PositionsOccupied.FindAsync(positionOccupied.Id);
            if (existing == null) return false;
            existing.Deleted = true;
            existing.DeletedDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UnDeleteAsync(int id)
        {
            var existing = await _context.PositionsOccupied.FindAsync(id);
            if (existing == null) return false;
            existing.Deleted = false;
            existing.DeletedBy = null;
            existing.DeletedDate = null;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> KillAsync(int id)
        {
            var existing = await _context.PositionsOccupied.FindAsync(id);
            if (existing == null) return false;
            _context.PositionsOccupied.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}