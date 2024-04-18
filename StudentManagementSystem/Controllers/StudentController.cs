using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystemShared.Models;
using StudentManagementSystemShared.StudentRepository;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }
        [HttpGet("All-Students")]
        public async Task<ActionResult<List<Student>>> GetAllStudentsAsync()
        {
            Console.WriteLine("Calling GetAllStudentsAsync API...");
            var students = await _studentRepository.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("Single-Student/{id}")]
        public async Task<ActionResult<Student>> GetSingleStudentAsync(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            return Ok(student);
        }

        [HttpPost("Add-Student")]
        public async Task<ActionResult<Student>> AddNewStudentAsync(Student student)
        {
            var newstudent = await _studentRepository.AddStudentAsync(student);
            return Ok(newstudent);
        }

        [HttpDelete("Delete-Student/{id}")]
        public async Task<ActionResult<Student>> DeleteStudentAsync(int id)
        {
            var deletestudent = await _studentRepository.DeleteStudentAsync(id);
            return Ok(deletestudent);
        }

        [HttpPut("Update-Student/{id}")]
        public async Task<ActionResult<Student>> UpdateStudentAsync(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest("Student ID mismatch");
            }

            var updatedStudent = await _studentRepository.UpdateStudentAsync(student);
            if (updatedStudent == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            return Ok(updatedStudent);
        }



    }
}
