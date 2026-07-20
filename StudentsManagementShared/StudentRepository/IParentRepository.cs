using StudentManagementSystemShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemShared.StudentRepository
{
    public interface IParentRepository
    {
        Task<Parent> AddParentAsync(Parent mod);
        Task<Parent> UpdateAsync(Parent mod);
        Task<Parent> DeleteAsync(Guid id);
        Task<List<Parent>> GetAllAsync();
        Task<Parent> GetByIdAsync(Guid id);
		Task<int> GetCountAsync();
	}
}
