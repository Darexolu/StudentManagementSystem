using StudentManagementSystemShared.Models;
using StudentManagementSystemShared.StudentRepository;
using System.Net.Http.Json;

namespace StudentManagementSystem.Client.Services
{
    public class ParentService : IParentRepository
    {
        private readonly HttpClient _httpClient;
        public ParentService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<Parent> AddParentAsync(Parent mod)
        {
            var data = await _httpClient.PostAsJsonAsync("api/Parent/Add-Parent", mod);
            var response = await data.Content.ReadFromJsonAsync<Parent>();
            return response;
        }
        public async Task<Parent> DeleteAsync(int id)
        {
            var data = await _httpClient.DeleteAsync($"api/Parent/Delete-Parent/{id}");
            var response = await data.Content.ReadFromJsonAsync<Parent>();
            return response;
        }
        public async Task<List<Parent>> GetAllAsync()
        {
            var data = await _httpClient.GetAsync("api/Parent/All-Parents");
            var response = await data.Content.ReadFromJsonAsync<List<Parent>>();
            return response;
        }
        public async Task<Parent> GetByIdAsync(int id)
        {

            var data = await _httpClient.GetAsync($"api/Parent/Single-Parent/{id}");
            var response = await data.Content.ReadFromJsonAsync<Parent>();
            return response;
        }
        public async Task<Parent> UpdateAsync(Parent mod)
        {
            var data = await _httpClient.PostAsJsonAsync("api/Parent/Update-Parent", mod);
            var response = await data.Content.ReadFromJsonAsync<Parent>();
            return response;
        }
    }
}
