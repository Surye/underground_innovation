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
    [Route("api/ForumPost")]
    public class ForumPostController : Controller
    {
        // GET: api/ForumPost
        [HttpGet]
        public List<ForumPost> Get()
        {
            using (var db = new ApplicationDbContext())
            {
                var ForumPostList = db.ForumPosts.ToList();

                return ForumPostList;
            }
        }

        // GET: api/ForumPost/5
        [HttpGet("{id}")]
        public ForumPost Get(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var ForumPost = db.ForumPosts
                    .Where(b => b.Id == id).FirstOrDefault();

                return ForumPost;
            }
        }
        
        // POST: api/ForumPost
        [HttpPost]
        public ForumPost Post([FromBody]ForumPost forumPost)
        {
            using (var db = new ApplicationDbContext())
            {
                forumPost.AuthorId = "13dc3112-2427-4275-bcad-368021f01a2b";
                db.Add(forumPost);
                db.SaveChanges();
                db.Entry(forumPost).Reference(b => b.Author).Load();
                return forumPost;
            }
        }
        
        // PUT: api/ForumPost/5
        [HttpPut("{id}")]
        public ForumPost Put(int id, [FromBody]ForumPost newForumPost)
        {
            using (var db = new ApplicationDbContext())
            {
                var ForumPost = Get(id);
                ForumPost.Content = newForumPost.Content;

                db.Add(ForumPost);
                db.SaveChanges();
                return ForumPost;
            }
        }

        // DELETE: api/ForumPost/5
        [HttpDelete("{id}")]
        public ForumPost Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var forumPost = Get(id);
                db.Remove(forumPost);
                db.SaveChanges();
                return forumPost;
            }
        }
    }
}
