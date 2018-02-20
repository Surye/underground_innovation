using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UndergroundInnovation.Models
{
    [Table("Forums")]
    public class Forum : IDatedEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }

        public string AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public ApplicationUser Author { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }


        public List<Poll> Polls { get; set; }

        [Column("created_at")]
        public DateTime CreatedDate { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedDate { get; set; }
    }
}
