using StudentManagementSystemShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemShared.StudentRepository
{
	public interface ISchoolClassRepository
	{
		Task<List<SchoolClass>> GetAllAsync();

		Task<SchoolClass?> GetByIdAsync(Guid id);

		Task AddAsync(SchoolClass model);

		Task UpdateAsync(SchoolClass model);

		Task DeleteAsync(Guid id);

		Task<int> GetCountAsync();
	}
}
