using StudentManagementSystemShared.Models;
using StudentManagementSystemShared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemShared.StudentRepository
{
	public interface IAttendanceRepository
	{
		Task AddAsync(StudentAttendance attendance);

		Task UpdateAsync(StudentAttendance attendance);

		Task DeleteAsync(Guid id);

		Task<StudentAttendance?> GetByIdAsync(Guid id);

		Task<List<StudentAttendance>> GetByClassAndDateAsync(
			Guid classId,
			DateTime date);

		Task<List<StudentAttendance>> GetStudentAttendanceAsync(
			Guid studentId);
		Task<StudentAttendance?> GetAttendanceAsync(Guid studentId,
			DateTime date);
		Task<double> GetAttendancePercentageAsync(
			Guid studentId);
		Task<List<StudentAttendance>> GetMonthlyAttendanceAsync(
		   Guid classId,
		   int year,
		   int month);
		Task<List<AttendanceSummaryViewModel>> GetMonthlySummaryAsync(
	Guid classId,
	int year,
	int month);
	}
}
