using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace underground_innovation.Models.ViewModels
{
    public class NewUser
    {
        [Required]
        [EmailAddress]
        public string username { get; set; }

        [Required]
        [MinLength(8)]
        public string password { get; set; }
    }
}
