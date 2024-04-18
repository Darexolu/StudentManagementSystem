using StudentManagementSystemShared.Models;
using StudentManagementSystemShared.StudentRepository;
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

        public async Task<Student> DeleteStudentAsync(int id)
        {
            var deletestudent = await _httpClient.DeleteAsync($"api/Student/Delete-Student/{id}");
            var response = await deletestudent.Content.ReadFromJsonAsync<Student>();
            return response;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {

            var allstudents = await _httpClient.GetAsync("api/Student/All-Students");
            var response = await allstudents.Content.ReadFromJsonAsync<List<Student>>();
            return response;
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var singlestudent = await _httpClient.GetAsync($"api/Student/Single-Student/{id}");
            var response = await singlestudent.Content.ReadFromJsonAsync<Student>();
            return response;
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            var updatestudent = await _httpClient.PutAsJsonAsync($"api/Student/Update-Student/{student.Id}", student);
            if (updatestudent.IsSuccessStatusCode)
            {
                // The update was successful
                return true;
            }
            else
            {
                // The update failed
                return false;
            }
        }


    }
}
