using StudentManagementSystem.Shared.Models;
using StudentsManagementShared.StudentRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagementSystem.Client.Services
{
    public class StudentService : IStudentRepository
    {
        private readonly HttpClient _httpClient;
        public StudentService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            var newstudent = await _httpClient.PostAsJsonAsync("api/Student/Add-Student", student);
            var response = await newstudent.Content.ReadFromJsonAsync<Student>();
            return response;
        }

        public async Task<Student> DeleteStudentAsync(int studentId)
        {
            var deletestudent = await _httpClient.PostAsJsonAsync("api/Student/Delete-Student", studentId);
            var response = await deletestudent.Content.ReadFromJsonAsync<Student>();
            return response;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {

            var allstudents = await _httpClient.GetAsync("api/Student/All-Students");
            var response = await allstudents.Content.ReadFromJsonAsync<List<Student>>();
            return response;
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            var singlestudent = await _httpClient.GetAsync("api/Student/Single-Student");
            var response = await singlestudent.Content.ReadFromJsonAsync<Student>();
            return response;
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            var updatestudent = await _httpClient.PostAsJsonAsync("api/Student/Update-Student", student);
            var response = await updatestudent.Content.ReadFromJsonAsync<Student>();
            return response;
        }

        
    }
}
