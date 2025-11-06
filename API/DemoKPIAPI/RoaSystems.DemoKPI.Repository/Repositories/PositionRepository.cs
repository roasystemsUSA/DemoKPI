using Microsoft.EntityFrameworkCore;
using RoaSystems.DemoKPI.Model.Model;
using RoaSystems.DemoKPI.Repository.Repositories.Interfaces;

namespace RoaSystems.DemoKPI.Repository.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly ApplicationDBContext _context;

        public PositionRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Position>> GetAllAsync()
        {
            return await _context.Positions.ToListAsync();
        }

        public async Task<Position?> GetByIdAsync(int id)
        {
            return await _context.Positions
                .Include(p => p.PositionsOccupied)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IEnumerable<Position>> GetByNameAsync(string name)
        {
            return await _context.Positions.Where(x => x.Name.Contains(name))
                .Include(p => p.PositionsOccupied)
                .ToListAsync();
        }

        public async Task<Position> AddAsync(Position position)
        {
            _context.Positions.Add(position);
            await _context.SaveChangesAsync();
            return position;
        }

        public async Task<bool> UpdateAsync(Position position)
        {
            var existing = await _context.Positions.FindAsync(position.Id);
            if (existing == null) return false;
            existing.Description = position.Description;
            existing.Name = position.Name;
            existing.Scope = position.Scope;
            existing.CreatedBy = position.CreatedBy;
            existing.CreationDate = position.CreationDate;
            existing.Deleted = position.Deleted;
            existing.DeletedBy = position.DeletedBy;
            existing.DeletedDate = position.DeletedDate;
            existing.LastUpdatedBy = position.LastUpdatedBy;
            existing.LastUpdateDate = position.LastUpdateDate;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Position position)
        {
            var existing = await _context.Positions.FindAsync(position.Id);
            if (existing == null) return false;
            existing.Deleted = true;
            existing.DeletedDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UnDeleteAsync(int id)
        {
            var existing = await _context.Positions.FindAsync(id);
            if (existing == null) return false;
            existing.Deleted = false;
            existing.DeletedBy = null;
            existing.DeletedDate = null;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> KillAsync(int id)
        {
            var existing = await _context.Positions.FindAsync(id);
            if (existing == null) return false;
            _context.Positions.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}