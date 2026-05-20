using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystemShared.Models;
using StudentManagementSystemShared.StudentRepository;

namespace StudentManagementSystem.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

		private readonly ITeacherRepository _repo;

		public TeacherController(ITeacherRepository repo)
		{
			_repo = repo;
		}

		// GET: api/Teachers
		[HttpGet("All-Teachers")]
            public async Task<ActionResult<IEnumerable<Teacher>>> GetAllTeachers()
            {
                return Ok(await _repo.GetAllAsync());
		}

        // GET: api/Teachers/5
        [HttpGet("Single-Teacher{id}")]
            public async Task<ActionResult<Teacher>> GetSingleTeacher(Guid id)
            {            

                return Ok(await _repo.GetTeacherByIdAsync(id));
		   }

           
        // PUT: api/Teacher/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update-Teacher/{id}")]
        public async Task<IActionResult> UpdateTeacherAsync(Guid id, Teacher teacher)
        {
			return Ok(await _repo.UpdateTeacherAsync(teacher));

		}



		[HttpPost("Add-Teacher")]
            public async Task<ActionResult<Teacher>> AddNewTeacherAsync(Teacher teacher)
            {
            var newparent = await _teacherRepository.AddTeacherAsync(teacher);
                return Ok(newparent);
            }


        // DELETE: api/Teachers/5
        [HttpDelete("Delete-Teacher/{id}")]
            public async Task<IActionResult> DeleteTeacher(Guid id)
            {

                return Ok(await _repo.DeleteAsync(id));
	     	}

            //private bool TeacherExists(Guid id)
            //{
            //    return _context.Teachers.Any(e => e.Id == id);
            //}
        }
}
