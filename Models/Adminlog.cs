using System;
using System.ComponentModel.DataAnnotations;

namespace Skill4.Models
{
    public partial class Adminlog
    {

        public string Name { get; set; }

        [Key]
        public string Email { get; set; }
         public string Password { get; set; }
       
    }
}