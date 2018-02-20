using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UndergroundInnovation.Models
{
    public interface IDatedEntity
    {
        [Column("created_at")]
        DateTime CreatedDate { get; set; }
        [Column("updated_at")]
        DateTime UpdatedDate { get; set; }
    }
}
