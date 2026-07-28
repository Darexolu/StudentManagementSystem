using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystemShared.Models;
using StudentManagementSystemShared.StudentRepository;

namespace StudentManagementSystem.Repository
{
	public class ParentStudentRepository : IParentStudentRepository
	{
		private readonly ApplicationDbContext _context;

		public ParentStudentRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<ParentStudent> AddAsync(ParentStudent model)
		{
			_context.ParentStudents.Add(model);
			await _context.SaveChangesAsync();

			return model;
		}

		public async Task UpdateAsync(ParentStudent model)
		{
			_context.ParentStudents.Update(model);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(Guid id)
		{
			var item = await _context.ParentStudents.FindAsync(id);

			if (item != null)
			{
				_context.ParentStudents.Remove(item);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<List<ParentStudent>> GetAllAsync()
		{
			return await _context.ParentStudents
				.Include(x => x.Parent)
				.Include(x => x.Student)
				.ToListAsync();
		}

		public async Task<List<ParentStudent>> GetByParentIdAsync(Guid parentId)
		{
			return await _context.ParentStudents
				.Include(x => x.Student)
				.Where(x => x.ParentId == parentId)
				.ToListAsync();
		}
		public async Task DeleteByParentIdAsync(Guid parentId)
		{
			var links = await _context.ParentStudents
				.Where(x => x.ParentId == parentId)
				.ToListAsync();

			if (links.Any())
			{
				_context.ParentStudents.RemoveRange(links);
				await _context.SaveChangesAsync();
			}
		}
		public async Task<List<ParentStudent>> GetByStudentIdAsync(Guid studentId)
		{
			return await _context.ParentStudents
				.Include(x => x.Parent)
				.Where(x => x.StudentId == studentId)
				.ToListAsync();
		}

		public async Task<ParentStudent?> GetAsync(Guid parentId, Guid studentId)
		{
			return await _context.ParentStudents
				.FirstOrDefaultAsync(x =>
					x.ParentId == parentId &&
					x.StudentId == studentId);
		}
	}
}