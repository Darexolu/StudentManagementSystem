using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystemShared.Models;
using StudentManagementSystemShared.StudentRepository;

namespace StudentManagementSystem.Services
{

   
    public class ParentRepository : IParentRepository
    {
        private readonly ApplicationDbContext _context;
        public ParentRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Parent> AddParentAsync(Parent mod)
        {

            if (mod == null) return null;

            var newparent = _context.Parents.Add(mod).Entity;
            await _context.SaveChangesAsync();
            return newparent;
        }

        public async Task<Parent> DeleteAsync(int id)
        {
            var data = await _context.Parents.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;

            _context.Parents.Remove(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<List<Parent>> GetAllAsync()
        {
            var data = await _context.Parents.Include(x=>x.Student).
                ToListAsync();
            return data;
        }

        public async Task<Parent> GetByIdAsync(int id)
        {
            var data = await _context.Parents.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;
            return data;
        }

        public async Task<Parent> UpdateAsync(Parent mod)
        {
            if (mod == null) return null;
            var data = _context.Parents.Update(mod).Entity;
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
