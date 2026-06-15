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

		Task<List<Result>> GetByFiltersAsync(
	      Guid classId,
	      Guid subjectId,
	      string term,
	      string session);
		Task<List<Result>> GetByClassSubjectTermSessionAsync(
          Guid classId,
          Guid subjectId,
         string term,
         string session);
		Task<Result> GetStudentResultAsync(
		  Guid studentId,
		  Guid classId,
		  Guid subjectId,
		  string term,
		 string session);
		Task<List<Result>> GetStudentResultSheetAsync(
	Guid studentId,
	string term,
	string session);

	}

}

