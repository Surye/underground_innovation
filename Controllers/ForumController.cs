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
    [Route("api/Forum")]
    public class ForumController : Controller
    {
        // GET: api/Forum
        [HttpGet]
        public List<Forum> Get()
        {
            using (var db = new ApplicationDbContext())
            {
                var projectId = int.Parse(HttpContext.Request.Query["projectId"].ToString());
                var ForumList = db.Forums.Where(b => b.ProjectId == projectId)
                    .Include(forum => forum.Polls).ThenInclude(poll => poll.PollAnswers)
                    .Include(forum => forum.Posts).ThenInclude(post => post.Author)
                    .Include(forum => forum.Author).ToList();
                return ForumList;
            }
        }

        // GET: api/Forum/5
        [HttpGet("{id}")]
        public Forum Get(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var Forum = db.Forums
                    .Where(b => b.Id == id)
                    .Include(forum => forum.Polls).ThenInclude(poll => poll.PollAnswers)
                    .Include(forum => forum.Posts).ThenInclude(post => post.Author)
                    .Include(forum => forum.Author).FirstOrDefault();

                return Forum;
            }
        }
        
        // POST: api/Forum
        [HttpPost]
        public Forum Post(string admin, [FromBody]Forum forum)
        {
            using (var db = new ApplicationDbContext())
            {
                forum.AuthorId = "13dc3112-2427-4275-bcad-368021f01a2b";
                db.Add(forum);
                db.SaveChanges();
                db.Entry(forum).Reference(b => b.Author).Load();
                return forum;
            }
        }
        
        // PUT: api/Forum/5
        [HttpPut("{id}")]
        public Forum Put(int id, [FromBody]Forum newForum)
        {
            using (var db = new ApplicationDbContext())
            {
                var Forum = Get(id);
                Forum.Title = newForum.Title;
                Forum.Description = newForum.Description;
                Forum.AuthorId = "13dc3112-2427-4275-bcad-368021f01a2b";
                db.Add(Forum);
                db.SaveChanges();
                return Forum;
            }
        }

        // DELETE: api/Forum/5
        [HttpDelete("{id}")]
        public Forum Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var forum = Get(id);
                db.Remove(forum);
                db.SaveChanges();
                return forum;
            }
        }
    }
}
