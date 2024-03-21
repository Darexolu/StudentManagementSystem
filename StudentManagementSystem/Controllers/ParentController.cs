using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystemShared.Models;
using StudentManagementSystemShared.StudentRepository;


namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly IParentRepository _parentRepository;

        private readonly ApplicationDbContext _context;

        public ParentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Parents
        [HttpGet("All-Parents")]
        public async Task<ActionResult<IEnumerable<Parent>>> GetAllParents()
        {
            return await _context.Parents.ToListAsync();
        }

        // GET: api/Parents/5
        [HttpGet("Single-Parent{id}")]
        public async Task<ActionResult<Parent>> GetSingleParent(int id)
        {
            var parent = await _context.Parents.FindAsync(id);

            if (parent == null)
            {
                return NotFound();
            }

            return parent;
        }

        // PUT: api/Parents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Update-Parent")]
        public async Task<ActionResult<Parent>> UpdateParentAsync(Parent parent)
        {
            _context.Update(parent);
            await _context.SaveChangesAsync();
            return Ok(parent);
        }

       
        [HttpPost("Add-Parent")]
        public async Task<ActionResult<Parent>> AddNewParentAsync(Parent parent)
        {
            var newparent = await _parentRepository.AddParentAsync(parent);
            return Ok(newparent);
        }


        // DELETE: api/Parents/5
        [HttpDelete("Delete-Parent/{id}")]
        public async Task<IActionResult> DeleteParent(int id)
        {
            var parent = await _context.Parents.FindAsync(id);
            if (parent == null)
            {
                return NotFound();
            }

            _context.Parents.Remove(parent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParentExists(int id)
        {
            return _context.Parents.Any(e => e.Id == id);
        }
    }
}
