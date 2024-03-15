using StudentsManagementShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagementShared.StudentRepository
{
    public interface ISystemCodeDetailRepository
    {

        Task<SystemCodeDetail> AddAsync(SystemCodeDetail mod);

        Task<SystemCodeDetail> UpdateAsync(SystemCodeDetail mod);

        Task<SystemCodeDetail> DeleteAsync(int id);

        Task<List<SystemCodeDetail>> GetAllAsync();

        Task<SystemCodeDetail> GetByIdAsync(int id);

        Task<List<SystemCodeDetail>> GetByCodeAsync(string code);

    }
}
