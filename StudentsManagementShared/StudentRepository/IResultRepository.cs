using StudentManagementSystemShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemShared.StudentRepository
{
	public interface IResultRepository
	{
		Task<List<Result>> GetAllAsync();

		Task<Result> AddAsync(Result model);

		Task<Result> UpdateAsync(Result model);

		Task<Result> DeleteAsync(Guid id);

		Task<Result> GetByIdAsync(Guid id);

		Task<List<Result>> GetStudentResults(Guid studentId);

		Task<List<Result>> GetClassResults(Guid classId);
	}
}
