using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystemShared.Models;

namespace StudentsManagementShared.StudentRepository
{
    public interface IStudentRepository
    {
        Task<Student> AddStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(Student student);
        Task<Student> DeleteStudentAsync(int studentId);
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int studentId);
    }
}
