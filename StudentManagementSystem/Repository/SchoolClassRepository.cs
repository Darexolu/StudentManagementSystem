using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystemShared.Models;
using StudentManagementSystemShared.StudentRepository;

namespace StudentManagementSystem.Repository
{
	public class SchoolClassRepository : ISchoolClassRepository
	{
		private readonly ApplicationDbContext _context;

		public SchoolClassRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<SchoolClass>> GetAllAsync()
		{
			return await _context.SchoolClasses
				.Where(x => !x.Deleted)
				.OrderBy(x => x.Name)
				.ToListAsync();
		}

		public async Task<SchoolClass?> GetByIdAsync(Guid id)
		{
			return await _context.SchoolClasses
				.FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);
		}

		public async Task AddAsync(SchoolClass model)
		{
			model.Id = Guid.NewGuid();

			_context.SchoolClasses.Add(model);

			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(SchoolClass model)
		{
			var data = await _context.SchoolClasses
				.FirstOrDefaultAsync(x => x.Id == model.Id);

			if (data == null)
				return;

			data.Name = model.Name;
			data.Level = model.Level;
			data.Arm = model.Arm;

			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(Guid id)
		{
			var data = await _context.SchoolClasses
				.FirstOrDefaultAsync(x => x.Id == id);

			if (data == null)
				return;

			data.Deleted = true;

			await _context.SaveChangesAsync();
		}

		public async Task<int> GetCountAsync()
		{
			return await _context.SchoolClasses.CountAsync();
		}
	}
}
