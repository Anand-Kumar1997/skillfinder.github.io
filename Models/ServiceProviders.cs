using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skill4.Models
{
    public partial class ServiceProviders
    {
        [Key]
        public long ServiceProviderSysId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool Activated { get; set; }
        public bool Deleted { get; set; }
        public string ContNo { get; set; }
        public DateTime Dob { get; set; }
        public string AltContNo { get; set; }
        public string Email { get; set; }
    }
}
