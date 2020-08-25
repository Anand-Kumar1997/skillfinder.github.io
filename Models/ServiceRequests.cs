using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skill4.Models
{
    public partial class ServiceRequests
    {
        [Key]
        public long RequestSysId { get; set; }
        public long UserSysId { get; set; }
        public long ServiceSysId { get; set; }
        public string CityCode { get; set; }
        public long ServiceProviderSysId { get; set; }
        public DateTime RequestOn { get; set; }
        public byte RequestStatus { get; set; }
        public DateTime UpdatedOn { get; set; }
        public byte Rating { get; set; }
    }
}
