using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystemShared.Models;
using StudentManagementSystemShared.StudentRepository;

namespace StudentManagementSystem.Repository
{
	public class SubjectRepository : ISubjectRepository
	{
		private readonly ApplicationDbContext _context;

		public SubjectRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<Subject>> GetAllAsync()
		{
			return await _context.Subjects
				.Where(x => !x.Deleted)
				.OrderBy(x => x.Name)
				.ToListAsync();
		}

		public async Task<Subject?> GetByIdAsync(Guid id)
		{
			return await _context.Subjects
				.FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);
		}

		public async Task AddAsync(Subject model)
		{
			model.Id = Guid.NewGuid();
			_context.Subjects.Add(model);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Subject model)
		{
			var data = await _context.Subjects.FirstOrDefaultAsync(x => x.Id == model.Id);

			if (data == null) return;

			data.Name = model.Name;
			data.Code = model.Code;
			data.IsCore = model.IsCore;

			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(Guid id)
		{
			var data = await _context.Subjects.FirstOrDefaultAsync(x => x.Id == id);

			if (data == null) return;

			data.Deleted = true;
			await _context.SaveChangesAsync();
		}
	}
}
