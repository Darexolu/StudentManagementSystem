using StudentManagementSystemShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemShared.StudentRepository
{
	public interface IClassSubjectRepository
	{
		Task<List<ClassSubject>> GetAllAsync();

		Task<ClassSubject?> GetByIdAsync(Guid id);

		Task<List<ClassSubject>> GetByClassIdAsync(Guid? classId);

		Task AddAsync(ClassSubject model);

		Task UpdateAsync(ClassSubject model);

		Task DeleteAsync(Guid id);
		Task<ClassSubject?> GetByClassAndSubjectAsync(Guid? classId, Guid subjectId);
	}
}
