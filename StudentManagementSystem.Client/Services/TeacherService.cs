using StudentManagementSystemShared.Models;
using StudentManagementSystemShared.StudentRepository;
using System.Net.Http.Json;

namespace StudentManagementSystem.Client.Services
{
    public class TeacherService : ITeacherRepository
    {
        private readonly HttpClient _httpClient;
        public TeacherService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<Teacher> AddTeacherAsync(Teacher mod)
        {
            var data = await _httpClient.PostAsJsonAsync("api/Teacher/Add-Teacher", mod);
            var response = await data.Content.ReadFromJsonAsync<Teacher>();
            return response;
        }
        public async Task<Teacher> DeleteAsync(int id)
        {
            var data = await _httpClient.DeleteAsync($"api/Teacher/Delete-Teacher/{id}");
            var response = await data.Content.ReadFromJsonAsync<Teacher>();
            return response;
        }
        public async Task<List<Teacher>> GetAllAsync()
        {
            var data = await _httpClient.GetAsync("api/Teacher/All-Teachers");
            var response = await data.Content.ReadFromJsonAsync<List<Teacher>>();
            return response;
        }
        public async Task<Teacher> GetTeacherByIdAsync(int id)
        {

            var data = await _httpClient.GetAsync($"api/Teacher/Single-Teacher/{id}");
            var response = await data.Content.ReadFromJsonAsync<Teacher>();
            return response;
        }
        public async Task<Teacher> UpdateTeacherAsync(Teacher mod)
        {
            var data = await _httpClient.PutAsJsonAsync($"api/Teacher/Update-Teacher/{mod.Id}", mod);
            var response = await data.Content.ReadFromJsonAsync<Teacher>();
            return response;
        }
    }
}
