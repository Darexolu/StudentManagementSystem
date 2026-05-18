using StudentManagementSystemShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemShared.StudentRepository
{
	public interface ISubjectRepository
	{
		Task<List<Subject>> GetAllAsync();
		Task<Subject?> GetByIdAsync(Guid id);
		Task AddAsync(Subject model);
		Task UpdateAsync(Subject model);
		Task DeleteAsync(Guid id);
	}
}
