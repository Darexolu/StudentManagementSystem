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

            private readonly ApplicationDbContext _context;

            public TeacherController(ApplicationDbContext context)
            {
                _context = context;
            }

        // GET: api/Teachers
        [HttpGet("All-Teachers")]
            public async Task<ActionResult<IEnumerable<Teacher>>> GetAllTeachers()
            {
                return await _context.Teachers.ToListAsync();
            }

        // GET: api/Teachers/5
        [HttpGet("Single-Teacher{id}")]
            public async Task<ActionResult<Teacher>> GetSingleTeacher(int id)
            {
                var teacher = await _context.Teachers.FindAsync(id);

                if (teacher == null)
                {
                    return NotFound();
                }

                return teacher;
            }

           
        // PUT: api/Teacher/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update-Teacher/{id}")]
        public async Task<IActionResult> UpdateTeacherAsync(int id, Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest();
            }

            _context.Entry(teacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        [HttpPost("Add-Teacher")]
            public async Task<ActionResult<Teacher>> AddNewTeacherAsync(Teacher teacher)
            {
            var newparent = await _teacherRepository.AddTeacherAsync(teacher);
                return Ok(newparent);
            }


        // DELETE: api/Teachers/5
        [HttpDelete("Delete-Teacher/{id}")]
            public async Task<IActionResult> DeleteTeacher(int id)
            {
                var teacher = await _context.Teachers.FindAsync(id);
                if (teacher == null)
                {
                    return NotFound();
                }

                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool TeacherExists(int id)
            {
                return _context.Teachers.Any(e => e.Id == id);
            }
        }
}
