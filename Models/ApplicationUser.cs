using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public ICollection<ProjectMembers> ProjectMembers { get; } = new List<ProjectMembers>();
        public ICollection<UserPollAnswers> UserPollAnswers { get; } = new List<UserPollAnswers>();

        public List<Forum> Forums { get; set; }
        public List<Poll> Polls { get; set; }

        
    }
}
