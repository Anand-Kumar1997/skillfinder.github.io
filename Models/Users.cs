using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skill4.Models
{
    public partial class Users
    {
        [Key]

        public long UserSysId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public DateTime RegOn { get; set; }
    }
}
