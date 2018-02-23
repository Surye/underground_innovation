using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UndergroundInnovation.Models
{
    public class ReplyViewModel
    {
        public string Type { get; set; }
        public Poll Poll { get; set; }
        public ForumPost Reply { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
