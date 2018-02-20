using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UndergroundInnovation.Models
{
    [Table("Project")]
    public class Project : IDatedEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }

        public ICollection<ProjectMembers> ProjectMembers { get; } = new List<ProjectMembers>();

        [Column("created_at")]
        public DateTime CreatedDate { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedDate { get; set; }
    }
}
