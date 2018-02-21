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
    [Route("api/Project")]
    public class ProjectController : Controller
    {
        // GET: api/Project
        [HttpGet]
        public List<Project> Get()
        {
            using (var db = new ApplicationDbContext())
            {
                var projectList = db.Projects.Include(proj => proj.ProjectMembers).ToList();

                return projectList;
            }
        }

        // GET: api/Project/5
        [HttpGet("{id}")]
        public Project Get(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var project = db.Projects.Include(proj => proj.ProjectMembers)
                    .Where(b => b.Id == id).FirstOrDefault();

                return project;
            }
        }
        
        // POST: api/Project
        [HttpPost]
        public Project Post(string admin, [FromBody]Project project)
        {
            using (var db = new ApplicationDbContext())
            {
                var membership = new ProjectMembers();
                db.Add(project);
                membership.Admin = true;
                membership.Project = project;
                membership.UserId = admin;
                db.Add(membership);
                db.SaveChanges();
                return project;
            }
        }
        
        // PUT: api/Project/5
        [HttpPut("{id}")]
        public Project Put(int id, [FromBody]Project newProject)
        {
            using (var db = new ApplicationDbContext())
            {
                var project = Get(id);
                project.Title = newProject.Title;
                project.Description = newProject.Description;

                db.Add(project);
                db.SaveChanges();
                return project;
            }
        }

        // DELETE: api/Project/5
        [HttpDelete("{id}")]
        public Project Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var project = Get(id);
                db.Remove(project);
                db.SaveChanges();
                return project;
            }
        }
    }
}
