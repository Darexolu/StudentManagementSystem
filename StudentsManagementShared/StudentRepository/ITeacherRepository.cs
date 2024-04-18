using StudentManagementSystemShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemShared.StudentRepository
{
    public interface ITeacherRepository
    {
        Task<Teacher> AddTeacherAsync(Teacher mod);
        Task<Teacher> UpdateTeacherAsync(Teacher mod);
        Task<Teacher> DeleteAsync(int id);
        Task<List<Teacher>> GetAllAsync();
        Task<Teacher> GetTeacherByIdAsync(int id);
    }
}
