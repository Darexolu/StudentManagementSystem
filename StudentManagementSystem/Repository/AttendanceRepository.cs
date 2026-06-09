using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Utility;
using StudentManagementSystemShared.Models;
using StudentManagementSystemShared.StudentRepository;
using StudentManagementSystemShared.ViewModels;
using System;

namespace StudentManagementSystem.Repository
{
	public class AttendanceRepository : IAttendanceRepository
	{
		private readonly ApplicationDbContext _context;

		public AttendanceRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<StudentAttendance>> GetByClassAndDateAsync(
			Guid classId,
			DateTime date)
		{
			return await _context.StudentAttendances
				.Include(x => x.Student)
				.Where(x =>
					x.SchoolClassId == classId &&
					x.AttendanceDate.Date == date.Date)
				.ToListAsync();
		}

		public async Task<StudentAttendance?> GetAttendanceAsync(
			Guid studentId,
			DateTime date)
		{
			return await _context.StudentAttendances
				.FirstOrDefaultAsync(x =>
					x.StudentId == studentId &&
					x.AttendanceDate.Date == date.Date);
		}

		public async Task AddAsync(StudentAttendance attendance)
		{
			_context.StudentAttendances.Add(attendance);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(StudentAttendance attendance)
		{
			_context.StudentAttendances.Update(attendance);
			await _context.SaveChangesAsync();
		}

		public async Task<List<StudentAttendance>> GetStudentAttendanceAsync(
			Guid studentId)
		{
			return await _context.StudentAttendances
				.Where(x => x.StudentId == studentId)
				.OrderByDescending(x => x.AttendanceDate)
				.ToListAsync();
		}

		public async Task DeleteAsync(Guid id)
		{
			var attendance = await _context.StudentAttendances
				.FirstOrDefaultAsync(x => x.Id == id);

			if (attendance != null)
			{
				_context.StudentAttendances.Remove(attendance);
				await _context.SaveChangesAsync();
			}
		}
		public async Task<StudentAttendance?> GetByIdAsync(Guid id)
		{
			return await _context.StudentAttendances
				.Include(x => x.Student)
				.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<double> GetAttendancePercentageAsync(
			Guid studentId)
		{
			var records = await _context.StudentAttendances
				.Where(x => x.StudentId == studentId)
				.ToListAsync();

			if (!records.Any())
				return 0;

			var presentCount = records.Count(x =>
				x.Status == AttendanceStatus.Present);

			return (double)presentCount / records.Count * 100;
		}

		public async Task<List<StudentAttendance>> GetMonthlyAttendanceAsync(
			Guid classId,
			int year,
			int month)
		{
			return await _context.StudentAttendances
				.Include(x => x.Student)
				.Where(x =>
					x.SchoolClassId == classId &&
					x.AttendanceDate.Year == year &&
					x.AttendanceDate.Month == month)
				.ToListAsync();
		}
		public async Task<List<AttendanceSummaryViewModel>> GetMonthlySummaryAsync(
	Guid classId,
	int year,
	int month)
		{
			var records = await _context.StudentAttendances
				.Include(x => x.Student)
				.Where(x =>
					x.SchoolClassId == classId &&
					x.AttendanceDate.Year == year &&
					x.AttendanceDate.Month == month)
				.ToListAsync();

			var result = records
				.GroupBy(x => new
				{
					x.StudentId,
					Name = x.Student.FirstName + " " + x.Student.MiddleName + " " + x.Student.LastName
				})
				.Select(g =>
				{
					var total = g.Count();

					var present = g.Count(x =>
						x.Status == AttendanceStatus.Present);

					var absent = g.Count(x =>
						x.Status == AttendanceStatus.Absent);

					return new AttendanceSummaryViewModel
					{
						StudentId = g.Key.StudentId,
						StudentName = g.Key.Name,
						PresentDays = present,
						AbsentDays = absent,
						TotalDays = total,
						AttendancePercentage =
							total == 0
							? 0
							: (double)present / total * 100
					};
				})
				.OrderBy(x => x.StudentName)
				.ToList();

			return result;
		}
	}
}
