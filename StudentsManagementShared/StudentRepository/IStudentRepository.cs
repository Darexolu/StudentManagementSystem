﻿using StudentManagementSystemShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemShared.StudentRepository
{
    public interface IStudentRepository
    {
        Task<Student> AddStudentAsync(Student student);
        Task<bool> UpdateStudentAsync(Student student);
        Task<Student> DeleteStudentAsync(int studentId);
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int studentId);
    }
}
