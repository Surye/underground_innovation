using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UndergroundInnovation.Models
{
    [Table("ForumPosts")]
    public class ForumPost : IDatedEntity
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }

        public string AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public ApplicationUser Author { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int ForumId { get; set; }
        [ForeignKey("ForumId")]
        public Forum Forum { get; set; }

        [Column("created_at")]
        public DateTime CreatedDate { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedDate { get; set; }
    }
}