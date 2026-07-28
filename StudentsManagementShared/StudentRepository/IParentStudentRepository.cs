using StudentManagementSystemShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemShared.StudentRepository
{
	public interface IParentStudentRepository
	{
		Task<ParentStudent> AddAsync(ParentStudent model);

		Task UpdateAsync(ParentStudent model);

		Task DeleteByParentIdAsync(Guid parentId);

		Task DeleteAsync(Guid id);

		Task<List<ParentStudent>> GetAllAsync();

		Task<List<ParentStudent>> GetByParentIdAsync(Guid parentId);

		Task<List<ParentStudent>> GetByStudentIdAsync(Guid studentId);

		Task<ParentStudent?> GetAsync(Guid parentId, Guid studentId);
	}
}
