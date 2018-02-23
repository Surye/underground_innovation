using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UndergroundInnovation.Data;
using UndergroundInnovation.Models;

namespace UndergroundInnovation.Controllers
{
    [Produces("application/json")]
    [Route("api/Poll")]
    public class PollController : Controller
    {
        // GET: api/Poll
        [HttpGet]
        public List<Poll> Get()
        {
            using (var db = new ApplicationDbContext())
            {
                var PollList = db.Polls.Include(forum => forum.PollAnswers).ToList();

                return PollList;
            }
        }

        // GET: api/Poll/5
        [HttpGet("{id}")]
        public Poll Get(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var Poll = db.Polls
                    .Where(b => b.Id == id).Include(forum => forum.PollAnswers).FirstOrDefault();

                return Poll;
            }
        }
        
        // POST: api/Poll
        [HttpPost]
        public Poll Post(string admin, [FromBody]Poll poll)
        {
            using (var db = new ApplicationDbContext())
            {
                poll.AuthorId = "13dc3112-2427-4275-bcad-368021f01a2b";
                db.Add(poll);
                db.SaveChanges();
                return poll;
            }
        }
        
        // PUT: api/Poll/5
        [HttpPut("{id}")]
        public Poll Put(int id, [FromBody]Poll newPoll)
        {
            using (var db = new ApplicationDbContext())
            {
                var Poll = Get(id);
                Poll.Question = newPoll.Question;
                Poll.Description = newPoll.Description;

                db.Add(Poll);
                db.SaveChanges();
                return Poll;
            }
        }

        // DELETE: api/Poll/5
        [HttpDelete("{id}")]
        public Poll Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var poll = Get(id);
                db.Remove(poll);
                db.SaveChanges();
                return poll;
            }
        }
    }
}
