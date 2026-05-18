using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystemShared.Models;
using StudentManagementSystemShared.StudentRepository;

namespace StudentManagementSystem.Repository
{
	public class ClassSubjectRepository : IClassSubjectRepository
	{
		private readonly ApplicationDbContext _context;

		public ClassSubjectRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<ClassSubject>> GetAllAsync()
		{
			var classSubject = await _context.ClassSubjects
				.Include(x => x.SchoolClass)
				.Include(x => x.Subject)
				.Include(x => x.Teacher)
				.Where(x => !x.Deleted)
				.ToListAsync();
			return classSubject;
		}

		public async Task<ClassSubject?> GetByIdAsync(Guid id)
		{
			return await _context.ClassSubjects
				.Include(x => x.SchoolClass)
				.Include(x => x.Subject)
				.Include(x => x.Teacher)
				.FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);
		}

		public async Task<List<ClassSubject>> GetByClassIdAsync(Guid classId)
		{
			return await _context.ClassSubjects
				.Include(x => x.Subject)
				.Include(x => x.Teacher)
				.Where(x => x.SchoolClassId == classId && !x.Deleted)
				.ToListAsync();
		}

		public async Task AddAsync(ClassSubject model)
		{
			model.Id = Guid.NewGuid();

			_context.ClassSubjects.Add(model);

			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(ClassSubject model)
		{
			var data = await _context.ClassSubjects.FirstOrDefaultAsync(x => x.Id == model.Id);

			if (data == null) return;

			data.SchoolClassId = model.SchoolClassId;
			data.SubjectId = model.SubjectId;
			data.TeacherId = model.TeacherId;

			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(Guid id)
		{
			var data = await _context.ClassSubjects.FirstOrDefaultAsync(x => x.Id == id);

			if (data == null) return;

			data.Deleted = true;

			await _context.SaveChangesAsync();
		}
	}
}
