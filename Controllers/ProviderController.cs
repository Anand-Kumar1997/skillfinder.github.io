using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skill4.Models;


namespace Skill4.Controllers
{
    public class ProviderController : Controller
    {
        private readonly AppDbContext _cc;
        public ProviderController(AppDbContext cc)
        {
            _cc=cc;
        }
        public IActionResult Pro()  
        {
            return View();
        }
    }
}