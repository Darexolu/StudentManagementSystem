using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Shared.Models;

namespace StudentsManagementShared.StudentRepository
{
    public interface IStudentRepository
    {
        Task<Student> AddStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(Student student);
        Task<Student> DeleteStudentAsync(Student student);
        Task<List<Student>> GetAllStudentsAsync(Student student);
    }
}
