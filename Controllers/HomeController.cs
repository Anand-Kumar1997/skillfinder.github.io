using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skill4.Models;
using Skill4.customs;

namespace Skill4.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _cc;
        public HomeController(AppDbContext cc)
        {
            _cc=cc;
        }
  [AllowAnonymous]
 public IActionResult Request()  
        {
            return View("Request");
        }
          
        [AllowAnonymous]
        public IActionResult Search()
        {
            HomeModel model = new HomeModel();
            model.cities = _cc.Citiess.ToList();
            model.services = _cc.Servicess.ToList();
            return View(model);
        }
        

        [AllowAnonymous]
        public IActionResult GetProviders(HomeModel model)   
        {
            model.serviceProviderss = _cc.ServiceProviderMapss
            .Where(x => x.CityCode == model.CityCode && x.ServiceSysId == model.ServiceSysId)
            .Select(x => new ServiceProviderModel {
                ServiceSysId = x.ServiceSysId,
                ServiceProviderSysId = x.ServiceProviderSysId,
                Verified=x.Verified,
                CityCode=x.CityCode,
                AvgCharge=x.AvgCharge
            }).ToList();

            for (int i=0; i< model.serviceProviderss.Count; i++)
            {
                var provider = _cc.ServiceProviderss.FirstOrDefault(x => x.ServiceProviderSysId == model.serviceProviderss[i].ServiceProviderSysId);
                model.serviceProviderss[i].Name = provider.Name;
                model.serviceProviderss[i].ContNo = provider.ContNo;
                model.serviceProviderss[i].AltContNo = provider.AltContNo;
                model.serviceProviderss[i].Email = provider.Email;
            }

            model.cities = _cc.Citiess.ToList();
            model.services = _cc.Servicess.ToList();
            return View("Search", model);
        }
        
        //  public IActionResult Index()
        // {
        //                                // List<CitiesClass> cl= new List<CitiesClass>();
        //                                // cl=(from c in _cc.CitiesClasss select c).ToList();
        //                                 // cl.Insert(0,new CitiesClass {CityCode="XYZ",CityName="--Select City Name--"});
        //                                 // ViewBag.message=cl;

        //     List<Cities> cl= new List<Cities>();
        //      cl=(from c in _cc.Citiess select c).ToList();
        //      cl.Insert(0,new Cities {CityCode="XYZ",CityName="--Select City Name--"});
        //     ViewBag.message=cl;

        //                                // List<Services> ca= new List<Services>();
        //                                  //  ca=(from a in _cc.Servicess select a).ToList();
        //                                     //  ca.Insert(0,new Services {ServiceSysId=0,ServiceTitle="--Select Service Name--"});
        //                                          // ViewBag.message=ca;
        //     return View();
        // }





        // [HttpGet]
        // public async Task<IActionResult> Index(string Empsearch)
        // {
        //     ViewData["GetEmployeeDetails"]=EmpSearch;
        //     var empquery= from x in _db.EmployeeTable select x;
        //     if(!String.IsNullOrEmpty(EmpSearch))
        //     {
        //         empquery=empquery.Where(x=>x.Empname.Contains(EmpSearch)||x.Email.Contains(EmpSesarch));
        //     }
        //     return View(await empquery.AsNoTracking().ToListAsync());
        // }

        // [HttpGet]
        //  public async Task<IActionResult> Index(string Empsearch)
        // {
        //      ViewData["GetEmployeeDetails"]=Empsearch;
        //      var empquery= from x in _cc.Citiess select x;
        //      if(!String.IsNullOrEmpty(Empsearch))
        //      {
        //          empquery=empquery.Where(x=>x.CityName.Contains(Empsearch));
        //      }
        //      return View(await empquery.AsNoTracking().ToListAsync());
        //  }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Privacy()  
        {
            return View();
        }

        
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
