using StudentManagementSystemShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemShared.StudentRepository
{
	public interface ITimeTableRepository
	{
		Task<List<ClassTimeTable>> GetAllAsync();
		Task<ClassTimeTable> AddAsync(ClassTimeTable model);
		Task<ClassTimeTable> UpdateAsync(ClassTimeTable model);
		Task<ClassTimeTable> DeleteAsync(Guid id);

		Task<List<ClassTimeTable>> GetTeacherTimeTable(Guid teacherId);
		Task<List<ClassTimeTable>> GetStudentTimeTable(Guid classId);
	}
}
