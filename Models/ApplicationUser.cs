using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using underground_innovation.Models;

namespace UndergroundInnovation.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }


        public string Unit { get; set; }
        public string Rank { get; set; }
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        public ICollection<ApplicationUserInterest> ApplicationUserInterests { get; } = new List<ApplicationUserInterest>();
    }
}
