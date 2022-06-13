using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RabbitMQ;
using TweetAPI.Data;
using TweetAPI.Model;
using TweetAPI.RabbitMQ;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TweetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class TweetController : ControllerBase
    {
        private readonly TweetServiceContext _context;
        private readonly Consumer _consumer;

        public TweetController(TweetServiceContext context)
        {
            _context = context;
            _consumer = new Consumer();
        }

        // GET: api/<TweetController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tweet>>> Get()
        {
            return await _context.Tweet.ToListAsync();
        }

        // GET api/<TweetController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tweet>> Get(int id)
        {
            var tweet = await _context.Tweet.FindAsync(id);

            if (tweet == null)
            {
                return NotFound();
            }

            return tweet;
        }

        // POST api/<TweetController>
        [HttpPost]
        public async Task<ActionResult<Tweet>> Post([FromBody] Tweet tweet)
        {
            _context.Tweet.Add(tweet);
            await _context.SaveChangesAsync();

            Producer.Send(tweet.Message);

            return CreatedAtAction(nameof(Get), new { id = tweet.Id }, tweet);
        }

        // DELETE api/<TweetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var tweet =  _context.Tweet.Find(id);

            if(tweet != null)
            {
                tweet.IsDeleted = true;
            }

            NotFound();
        }
    }
}
