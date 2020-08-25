using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skill4.Models
{
    public partial class ServiceProviderMaps
    {
        [Key]
        public long ServiceSysId { get; set; }
        public long ServiceProviderSysId { get; set; }
        public bool Verified { get; set; }
        public string CityCode { get; set; }
        public double AvgCharge { get; set; }

    }
}
