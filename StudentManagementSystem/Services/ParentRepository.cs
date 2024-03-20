using StudentManagementSystem.Data;
using StudentsManagementShared.Models;
using StudentsManagementShared.StudentRepository;

namespace StudentManagementSystem.Services
{

    //Episode 9 24mins 54secs
    public class ParentRepository : IParentRepository
    {
        private readonly ApplicationDbContext _context;
        public ParentRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public Task<Parent> AddAsync(Parent mod)
        {
            throw new NotImplementedException();
        }

        public Task<Parent> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Parent>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Parent> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Parent> UpdateAsync(Parent mod)
        {
            throw new NotImplementedException();
        }
    }
}
