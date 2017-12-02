using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UndergroundInnovation.Data;
using UndergroundInnovation.Models;

namespace underground_innovation.Models
{
    public class DefaultDbContextInitializer : IDefaultDbContextInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DefaultDbContextInitializer(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
        }

        public bool EnsureCreated()
        {
            return _context.Database.EnsureCreated();
        }

        public void Migrate()
        {
            _context.Database.Migrate();
        }

        public async Task Seed()
        {
            var adminRole = new IdentityRole("Administrator");
            // Setup base roles
            if (await _roleManager.FindByNameAsync(adminRole.Name) == null) {
                await _roleManager.CreateAsync(adminRole);
            }

            var email = "user@test.com";
            if (await _userManager.FindByEmailAsync(email) == null)
            {
                var user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true,
                    
                };
                var result = await _userManager.CreateAsync(user, "T3mpp@ss!");
                result = await _userManager.AddToRoleAsync(user, adminRole.Name);
            }

            _context.SaveChanges();
        }
    }

    public interface IDefaultDbContextInitializer
    {
        bool EnsureCreated();
        void Migrate();
        Task Seed();
    }
}
