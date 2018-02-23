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
        public int? Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Required]
        public string AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public ApplicationUser Author { get; set; }
        [NotMapped]
        public string AuthorName => this.Author?.FullName;


        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        [NotMapped]
        public List<ReplyViewModel> Replies
        {
            get
            {
                List<ReplyViewModel> ret = new List<ReplyViewModel>();
                foreach(var poll in this.Polls ?? Enumerable.Empty<Poll>())
                {
                    ret.Add(
                        new ReplyViewModel
                        {
                            Type = "poll",
                            Poll = poll,
                            CreatedDate = poll.CreatedDate
                        }
                    );
                }
                foreach (var post in this.Posts ?? Enumerable.Empty<ForumPost>())
                {
                    ret.Add(
                        new ReplyViewModel
                        {
                            Type = "reply",
                            Reply = post,
                            CreatedDate = post.CreatedDate
                        }
                    );
                }
                
                return ret.OrderBy(o => o.CreatedDate).ToList();
            }
        }

        public List<Poll> Polls { get; set; }
        public List<ForumPost> Posts { get; set; }

        [Required]
        [Column("created_at")]
        public DateTime? CreatedDate { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedDate { get; set; }
    }
}
