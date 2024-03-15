using Microsoft.EntityFrameworkCore;
using StudentsManagementShared.Models;
using StudentsManagementShared.StudentRepository;
using System.Net.Http;
using System.Net.Http.Json;

namespace StudentManagementSystem.Client.Services
{
    public class SystemCodeDetailsService : ISystemCodeDetailRepository
    {
        private readonly HttpClient _httpClient;
        public SystemCodeDetailsService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<SystemCodeDetail> AddAsync(SystemCodeDetail mod)
        {
            var data = await _httpClient.PostAsJsonAsync("api/SystemCodeDetails/AddNewSystemCodeDetail", mod);
            var response = await data.Content.ReadFromJsonAsync<SystemCodeDetail>();
            return response;
        }
    
        public async Task<SystemCodeDetail> DeleteAsync(int id)
        {
            var data = await _httpClient.DeleteAsync($"api/SystemCodeDetails/ DeleteSystemCodeDetail/{id}");
            var response = await data.Content.ReadFromJsonAsync<SystemCodeDetail>();
            return response;
        }

        public async Task<List<SystemCodeDetail>> GetAllAsync()
        {
            var data = await _httpClient.GetAsync("api/SystemCodeDetails/GetAllSystemCodeDetails");
            var response = await data.Content.ReadFromJsonAsync<List<SystemCodeDetail>>();
            return response;
        }

        public async Task<SystemCodeDetail> GetByIdAsync(int id)
        {
            var data = await _httpClient.GetAsync($"api/SystemCodeDetails/GetSingleSystemCodeDetail/{id}");
            var response = await data.Content.ReadFromJsonAsync<SystemCodeDetail>();
            return response;
        }

        public async Task <List<SystemCodeDetail>> GetByCodeAsync(string code)
        {
            var data = await _httpClient.GetAsync($"api/SystemCodeDetails/GetSystemCodeDetailsByCode/{code}");
            var response = await data.Content.ReadFromJsonAsync<List<SystemCodeDetail>>();
            return response;
        }

        public async Task<SystemCodeDetail> UpdateAsync(SystemCodeDetail mod)
        {
            var data = await _httpClient.GetAsync($"api/SystemCodeDetails/ UpdateSystemCodeDetail/{mod}");
            var response = await data.Content.ReadFromJsonAsync<SystemCodeDetail>();
            return response;
        }

        
    }
}
