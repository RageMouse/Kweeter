using FollowerAPI.Data;
using FollowerAPI.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FollowerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class FollowerController : ControllerBase
    {
        private readonly DbServiceContext _context;

        public FollowerController(DbServiceContext context)
        {
            _context = context;
        }

        // GET: api/<FollowerController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Follow>>> Get()
        {
            return await _context.Follow.ToListAsync();
        }

        // GET api/<FollowerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Follow>> Get(int id)
        {
            var follow = await _context.Follow.FindAsync(id);
            if (follow == null)
            {
                return NotFound();
            }

            return follow;
        }

        // POST api/<FollowerController>
        [HttpPost]
        public async Task<ActionResult<Follow>> Post([FromBody] Follow follow)
        {
            _context.Follow.Add(follow);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = follow.Id }, follow);
        }

        // DELETE api/<FollowerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var follow = _context.Follow.Find(id);

            if (follow != null)
            {
                _context.Follow.Remove(follow);
            }

            NotFound();
        }
    }
}
