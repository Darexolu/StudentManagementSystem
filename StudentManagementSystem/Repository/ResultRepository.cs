using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystemShared.Models;
using StudentManagementSystemShared.StudentRepository;

namespace StudentManagementSystem.Repository
{
	public class ResultRepository : IResultRepository
	{
		private readonly ApplicationDbContext _context;

		public ResultRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Result> AddAsync(Result model)
		{
			model.Total = model.Test1 + model.Test2 + model.Assignment + model.Exam;

			model.Grade = GetGrade(model.Total);

			var data = _context.Results.Add(model).Entity;

			await _context.SaveChangesAsync();
			await CalculateStatistics(model.SchoolClassId, model.SubjectId);

			return data;
		}
		public async Task<Result> UpdateAsync(Result model)
		{
			var result = await _context.Results
				.FirstOrDefaultAsync(x => x.Id == model.Id);

			if (result == null)
				return null;

			result.Test1 = model.Test1;
			result.Test2 = model.Test2;
			result.Assignment = model.Assignment;
			result.Exam = model.Exam;
			result.Total = result.Test1 + result.Test2 + result.Assignment + result.Exam;

			result.Grade = GetGrade(result.Total);

			result.TeacherRemark = model.TeacherRemark;
			result.PrincipalComment = model.PrincipalComment;

			await _context.SaveChangesAsync();

			await CalculateStatistics(result.SchoolClassId, result.SubjectId);

			return result;
		}

		public async Task<Result> DeleteAsync(Guid id)
		{
			var data = await _context.Results.FirstOrDefaultAsync(x => x.Id == id);

			if (data == null)
				return null;

			_context.Results.Remove(data);

			await _context.SaveChangesAsync();

			return data;
		}

		public async Task<List<Result>> GetAllAsync()
		{
			return await _context.Results
				.Include(x => x.Student)
				.Include(x => x.Subject)
				.Include(x => x.SchoolClass)
				.ToListAsync();
		}

		public async Task<Result> GetByIdAsync(Guid id)
		{
			return await _context.Results
				.Include(x => x.Student)
				.Include(x => x.Subject)
				.Include(x => x.SchoolClass)
				.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<List<Result>> GetStudentResults(Guid studentId)
		{
			return await _context.Results
				.Where(x => x.StudentId == studentId)
				.ToListAsync();
		}

		public async Task<List<Result>> GetClassResults(Guid classId)
		{
			return await _context.Results
				.Where(x => x.SchoolClassId == classId)
				.ToListAsync();
		}


		private string GetGrade(decimal total)
		{
			if (total >= 70)
				return "A";

			if (total >= 60)
				return "B";

			if (total >= 50)
				return "C";

			if (total >= 45)
				return "D";

			if (total >= 40)
				return "E";
			return "F";
		}

		private async Task CalculateStatistics(Guid classId, Guid subjectId)
		{
			var results = await _context.Results
				.Where(x => x.SchoolClassId == classId && x.SubjectId == subjectId)
				.ToListAsync();

			if (!results.Any())
				return;

			var highest = results.Max(x => x.Total);
			var lowest = results.Min(x => x.Total);
			var average = results.Average(x => x.Total);

			var ordered = results
				.OrderByDescending(x => x.Total)
				.ToList();

			for (int i = 0; i < ordered.Count; i++)
			{
				ordered[i].Position = i + 1;
				ordered[i].HighestScore = highest;
				ordered[i].LowestScore = lowest;
				ordered[i].ClassAverage = (decimal)average;
			}

			await _context.SaveChangesAsync();
		}

		public async Task<List<Result>> GetByFiltersAsync(
	Guid classId,
	Guid subjectId,
	string term,
	string session)
		{
			return await _context.Results
				.Include(x => x.Student)
				.Include(x => x.Subject)
				.Where(x =>
					x.SchoolClassId == classId &&
					x.SubjectId == subjectId &&
					x.Term == term &&
					x.Session == session)
				.OrderBy(x => x.Student.FirstName)
				.ToListAsync();
		}
		public async Task<List<Result>> GetByClassSubjectTermSessionAsync(
	Guid classId,
	Guid subjectId,
	string term,
	string session)
		{
			return await _context.Results
				.Where(x =>
					x.SchoolClassId == classId &&
					x.SubjectId == subjectId &&
					x.Term == term &&
					x.Session == session)
				.ToListAsync();
		}
		public async Task<Result?> GetStudentResultAsync(
	Guid studentId,
	Guid classId,
	Guid subjectId,
	string term,
	string session)
		{
			return await _context.Results.FirstOrDefaultAsync(x =>
				x.StudentId == studentId &&
				x.SchoolClassId == classId &&
				x.SubjectId == subjectId &&
				x.Term == term &&
				x.Session == session);
		}
		public async Task<List<Result>> GetStudentResultSheetAsync(
	Guid studentId,
	string term,
	string session)
		{
			return await _context.Results
				.Include(x => x.Subject)
				.Include(x => x.SchoolClass)
				.Where(x =>
					x.StudentId == studentId &&
					x.Term == term &&
					x.Session == session)
				.OrderBy(x => x.Subject.Name)
				.ToListAsync();
		}
	}
}
