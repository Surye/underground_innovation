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
                var ForumList = db.Forums.ToList();

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
                    .Where(b => b.Id == id).FirstOrDefault();

                return Forum;
            }
        }
        
        // POST: api/Forum
        [HttpPost]
        public Forum Post(string admin, [FromBody]Forum forum)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Add(forum);
                db.SaveChanges();
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