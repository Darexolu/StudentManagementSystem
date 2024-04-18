using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystemShared.Models;
using StudentManagementSystemShared.StudentRepository;

namespace StudentManagementSystem.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext  _context;
        public StudentRepository(ApplicationDbContext context)
        {
                this._context = context;
        }
        public async Task<Student> AddStudentAsync(Student student)
        {
            if (student == null) return null;
           
            var newstudent = _context.Students.Add(student).Entity;
            await _context.SaveChangesAsync();
            return newstudent;
        }

        public async Task<Student> DeleteStudentAsync(int studentId)
        {
            var student = await _context.Students.Where(x => x.Id == studentId).FirstOrDefaultAsync();
            if (student == null) return null;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            var students = await _context.Students.ToListAsync();
            return students;
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            var singlestudent = await _context.Students.SingleOrDefaultAsync(x => x.Id == studentId);
            if (singlestudent == null) return null;
        return singlestudent;
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            if (student.Id <= 0)
            {
                // Log the error as needed
                return false;
            }

            var existingStudent = await _context.Students.FindAsync(student.Id);
            if (existingStudent == null)
            {
                // Log the error as needed
                return false;
            }

            _context.Entry(existingStudent).CurrentValues.SetValues(student);
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception as needed
                return false;
            }
        }

    }
}
