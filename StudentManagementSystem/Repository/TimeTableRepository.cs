using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystemShared.Models;
using StudentManagementSystemShared.StudentRepository;

namespace StudentManagementSystem.Repository
{
	public class TimeTableRepository : ITimeTableRepository
	{
		private readonly ApplicationDbContext _context;

		public TimeTableRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<ClassTimeTable>> GetAllAsync()
		{
			return await _context.ClassTimeTables
				.Include(x => x.SchoolClass)
				.Include(x => x.Subject)
				.Include(x => x.Teacher)
				.ToListAsync();
		}

		public async Task<ClassTimeTable> AddAsync(ClassTimeTable model)
		{
			var entity = _context.ClassTimeTables.Add(model).Entity;
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<ClassTimeTable> UpdateAsync(ClassTimeTable model)
		{
			var data = await _context.ClassTimeTables
				.FirstOrDefaultAsync(x => x.Id == model.Id);

			if (data == null) return null;

			data.SchoolClassId = model.SchoolClassId;
			data.SubjectId = model.SubjectId;
			data.TeacherId = model.TeacherId;
			data.Day = model.Day;
			data.StartTime = model.StartTime;
			data.EndTime = model.EndTime;
			data.Room = model.Room;

			await _context.SaveChangesAsync();

			return data;
		}

		public async Task<ClassTimeTable> DeleteAsync(Guid id)
		{
			var data = await _context.ClassTimeTables
				.FirstOrDefaultAsync(x => x.Id == id);

			if (data == null) return null;

			_context.ClassTimeTables.Remove(data);

			await _context.SaveChangesAsync();

			return data;
		}

		public async Task<List<ClassTimeTable>> GetTeacherTimeTable(Guid teacherId)
		{
			return await _context.ClassTimeTables
				.Where(x => x.TeacherId == teacherId)
				.Include(x => x.Subject)
				.Include(x => x.SchoolClass)
				.ToListAsync();
		}

		public async Task<List<ClassTimeTable>> GetStudentTimeTable(Guid classId)
		{
			return await _context.ClassTimeTables
				.Where(x => x.SchoolClassId == classId)
				.Include(x => x.Subject)
				.Include(x => x.Teacher)
				.ToListAsync();
		}
	}
}
