using Microsoft.AspNetCore.Mvc;
using TimelineAPI.Data;
using Microsoft.EntityFrameworkCore;
using TimelineAPI.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TimelineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimelineController : ControllerBase
    {
        private readonly TimelineServiceContext _context;

        public TimelineController(TimelineServiceContext context)
        {
            _context = context;
        }

        // GET: api/<TimelineController>
        [HttpGet]
        public async Task<IEnumerable<TimelineTweet>> GetAsync()
        {
            return await _context.TimelineTweet.ToListAsync();
        }

        // GET api/<TimelineController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TimelineController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TimelineController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TimelineController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
