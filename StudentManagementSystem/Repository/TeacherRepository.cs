using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystemShared.Models;
using StudentManagementSystemShared.StudentRepository;

namespace StudentManagementSystem.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _context;
        public TeacherRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Teacher> AddTeacherAsync(Teacher mod)
        {

            if (mod == null) return null;

            var newparent = _context.Teachers.Add(mod).Entity;
            await _context.SaveChangesAsync();
            return newparent;
        }


        public async Task<Teacher> DeleteAsync(Guid id)
        {
            var data = await _context.Teachers.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;

			//_context.Teachers.Remove(data);
			data.Deleted = true;
			await _context.SaveChangesAsync();
            return data;
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            var data = await _context.Teachers.Where(x => !x.Deleted).ToListAsync();
            return data;
        }

        public async Task<Teacher> GetTeacherByIdAsync(Guid id)
        {
            var data = await _context.Teachers.Where(x => x.Id == id && !x.Deleted).FirstOrDefaultAsync();
            if (data == null) return null;
            return data;
        }

        public async Task<Teacher> UpdateTeacherAsync(Teacher mod)
        {
            if (mod == null) return null;
			
			var teachers = await _context.Teachers
		.FirstOrDefaultAsync(x => x.Id == mod.Id);

			if (teachers == null)
				return null;

			teachers.FirstName = mod.FirstName;
			teachers.MiddleName = mod.MiddleName;
			teachers.LastName = mod.LastName;
			teachers.EmailAddress = mod.EmailAddress;
			teachers.PhoneNumber = mod.PhoneNumber;
			teachers.Address = mod.Address;
			teachers.Gender = mod.Gender;
			teachers.MaritalStatus = mod.MaritalStatus;
			teachers.DOB = mod.DOB;
			teachers.FacebookLink = mod.FacebookLink;
			teachers.TwitterLink = mod.TwitterLink;
			teachers.LinkedInLink = mod.LinkedInLink;
			teachers.Designation = mod.Designation;


			await _context.SaveChangesAsync();

			return teachers;
        }
		public async Task<int> GetCountAsync()
		{
			return await _context.Teachers.CountAsync();
		}
	}
}
