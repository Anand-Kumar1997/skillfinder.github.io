using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skill4.Models
{
    public partial class Services
    {
        [Key]
        public long ServiceSysId { get; set; }
        public string ServiceTitle { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool Activated { get; set; }
        public bool Deleted { get; set; }
    }
}
