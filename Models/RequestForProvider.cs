using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skill4.Models
{
    public partial class RequestForProvider
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ServiceName {get; set;}
        public DateTime RequestedOn { get; set; }

         public bool Activated { get; set; }
        public bool Deleted { get; set; }
    }
}