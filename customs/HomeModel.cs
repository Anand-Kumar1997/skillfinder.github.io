using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Skill4.Models;

namespace Skill4.customs
{
    public class HomeModel
    {

        public List<Cities> cities { get; set; }      
        public List<Services> services { get; set; }      
        public string CityCode { get; set; }      
        public long ServiceSysId { get; set; }          
        public List<ServiceProviderModel> serviceProviderss { get; set; }    
    }

    public class ServiceProviderModel 
    {
        public long ServiceSysId { get; set; }
        public long ServiceProviderSysId { get; set; }
        public bool Verified { get; set; }
        public string CityCode { get; set; }
        public double AvgCharge { get; set; }

        
        public string Name { get; set; }
        public string ContNo { get; set; }
        public string AltContNo { get; set; }
        public string Email { get; set; }

    }


}