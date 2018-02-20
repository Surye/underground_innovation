using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UndergroundInnovation.Models
{
    public class UserPollAnswers : IDatedEntity
    {
        public int PollAnswerId { get; set; }
        public PollAnswer PollAnswer { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [Column("created_at")]
        public DateTime CreatedDate { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedDate { get; set; }
    }
}
