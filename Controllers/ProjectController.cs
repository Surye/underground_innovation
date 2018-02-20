using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UndergroundInnovation.Data;
using UndergroundInnovation.Models;

namespace UndergroundInnovation.Controllers
{
    [Produces("application/json")]
    [Route("api/Project")]
    public class ProjectController : Controller
    {
        // GET: api/Project
        [HttpGet]
        public List<Project> Get()
        {
            using (var db = new ApplicationDbContext())
            {
                var projectList = db.Projects.ToList();

                return projectList;
            }
        }

        // GET: api/Project/5
        [HttpGet("{id}", Name = "Get")]
        public Project Get(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var project = db.Projects
                    .Where(b => b.Id == id).FirstOrDefault();

                return project;
            }
        }
        
        // POST: api/Project
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Project/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
