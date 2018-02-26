using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UndergroundInnovation.Models
{
    [Table("PollAnswers")]
    public class PollAnswer
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        public string AnswerText { get; set; }
        public bool Deactivated { get; set; }

        [Required]
        public int? PollId { get; set; }
        public Poll Poll { get; set; }

        [NotMapped]
        public int CurrentSelections {
            get
            {
                //return UserPollAnswers.Count;
                if (Id.HasValue)
                    return new Random(Id.Value).Next(15);
                else
                    return 0;
            }
        }

        public ICollection<UserPollAnswers> UserPollAnswers { get; } = new List<UserPollAnswers>();
    }
}
