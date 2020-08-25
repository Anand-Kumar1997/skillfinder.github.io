using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skill4.Models
{
    public class CitiesClass
    {
        [Key]
        public string CityCode { get; set; }
        public string CityName { get; set; }
    }
}