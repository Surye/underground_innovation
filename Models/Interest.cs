using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UndergroundInnovation.Models
{
    public class Interest
    {
        [Key]
        public int InterestId { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }

        public ICollection<ApplicationUserInterest> ApplicationUserInterests { get; } = new List<ApplicationUserInterest>();
    }
}
