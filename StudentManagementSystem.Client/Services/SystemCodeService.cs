using StudentManagementSystemShared.Models;
using StudentManagementSystemShared.StudentRepository;
using System.Net.Http;
using System.Net.Http.Json;

namespace StudentManagementSystem.Client.Services
{
    public class SystemCodeService : ISystemCodeRepository
    {
        private readonly HttpClient _httpClient;
        public SystemCodeService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public Task<SystemCode> AddAsync(SystemCode mod)
        {
            throw new NotImplementedException();
        }

        public Task<SystemCode> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SystemCode>> GetAllAsync()
        {
            var data = await _httpClient.GetAsync("api/SystemCodes/GetAllSystemCodes");
            var response = await data.Content.ReadFromJsonAsync<List<SystemCode>>();
            return response;
        }

        public Task<SystemCode> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SystemCode> UpdateAsync(SystemCode mod)
        {
            throw new NotImplementedException();
        }
    }
}
