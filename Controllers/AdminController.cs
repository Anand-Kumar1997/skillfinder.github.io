using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skill4.Models;
using Skill4.ViewModels;


namespace Skill4.Controllers
{
       [Authorize(Roles = "Admin")]

    public class AdminController : Controller
    {
        static DbContextOptions<AppDbContext> options = new DbContextOptions<AppDbContext>();
        private AppDbContext db = new AppDbContext(options);
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly UserManager<IdentityUser> userManager;

        public AdminController(RoleManager<IdentityRole> roleManager,
                                          UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                // We just need to specify a unique role name to create a new role
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                // Saves the role in the underlying AspNetRoles table
                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Admin");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            // Find the role by Role ID
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }

            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };

            // Retrieve all the Users
            foreach (var user in userManager.Users)
            {
                // If the user is in this role, add the username to
                // Users property of EditRoleViewModel. This model
                // object is then passed to the view for display
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model);
        }

        // This action responds to HttpPost and receives EditRoleViewModel
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;

                // Update the Role using UpdateAsync
                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            var model = new List<UserRoleViewModel>();

            foreach (var user in userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                model.Add(userRoleViewModel);
            }

            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;

                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { Id = roleId });
                }
            }

            return RedirectToAction("EditRole", new { Id = roleId });
        }

        public ActionResult Cities()
        {

            return View(db.Citiess.ToList());
        }
        public ActionResult AddCities(string CityCode)
        {
            //    return View(db.Cities.ToList());
            return View(new Cities());
        }

        [HttpPost]
        public ActionResult Save(Cities task)
        {
            if (ModelState.IsValid)
            {
                Cities newTask = new Cities();
                newTask.CityCode = task.CityCode;
                newTask.CityName = task.CityName;
                newTask.CreatedOn = DateTime.Now;
                newTask.UpdatedOn = DateTime.Now;
                newTask.Activated = true;
                newTask.Deleted = false;
                db.Citiess.Add(newTask);
                db.SaveChanges();
            }

            return RedirectToAction("Cities");
        }

            public ActionResult Services()
            {
              return View(db.Servicess.ToList());
             }
            public ActionResult AddServices(long ServiceSysId)
            {
              Services task=new Services();
              if(task == null)
                {
                  return View(new Services());
          }
          return View(task);
      }

        [HttpPost]
       public ActionResult SaveSer(Services task)
      {
          if(ModelState.IsValid)
          {
              if(task.ServiceSysId==0)
              {
                  Services newTask =new Services();
                  newTask.ServiceTitle=task.ServiceTitle;
                  newTask.CreatedOn=@DateTime.Now;
                  newTask.UpdatedOn=@DateTime.Now;
                  newTask.Activated=true;
                  newTask.Deleted=false;
                  db.Servicess.Add(newTask);
                  db.SaveChanges();
              }
              else
                {
                    Services existingTask = db.Servicess.Find(task.ServiceSysId);
                    existingTask.ServiceTitle = task.ServiceTitle;
                  
                    db.SaveChanges();
                   
                }
              return RedirectToAction("Services");
          }
          return NotFound();
      }
             public ActionResult Providers()
        {
            return View(db.ServiceProviderss.ToList());
        }
          public ActionResult AddProviders(long ServiceProviderSysId)
        {
              ServiceProviders task=new ServiceProviders();
              if(task == null)
                {
                  return View(new ServiceProviders());
          }
          return View(task);
        }

         public ActionResult Delete(long ServiceProviderSysId)
       {
           ServiceProviders pro=db.ServiceProviderss.Find(ServiceProviderSysId);
            if(pro==null)
            {
                return NotFound();
            }
            db.Remove(pro);
            db.SaveChanges();
            return RedirectToAction("Providers");
       }

         [HttpPost]
        public ActionResult SavePro(ServiceProviders task)
        {
            if (ModelState.IsValid)
            {
                ServiceProviders newTask = new ServiceProviders();
                newTask.ServiceProviderSysId = task.ServiceProviderSysId;
                newTask.Name = task.Name;
                newTask.CreatedOn = DateTime.Now;
                newTask.UpdatedOn = DateTime.Now;
                newTask.Activated = true;
                newTask.Deleted = false;
                newTask.ContNo ="123";
                newTask.Dob= DateTime.Now;
                newTask.AltContNo="1234";
                newTask.Email=task.Email;
                db.ServiceProviderss.Add(newTask);
                db.SaveChanges();
            }

            return RedirectToAction("Providers");
        }
             public ActionResult ServiceReq()
        {
            return View(db.ServiceRequestss.ToList());
        }

    public ActionResult RequestForProvider()
        {

            return View(db.RequestForProviders.ToList());
        }
        public ActionResult DeleteProReq(int Id)
       {
           RequestForProvider Req=db.RequestForProviders.Find(Id);
            if(Req==null)
            {
                return NotFound();
            }
            db.Remove(Req);
            db.SaveChanges();
            return RedirectToAction("RequestForProvider");
       }
           [HttpGet]
        public IActionResult Index2()
        {
            RequestForProvider model = new RequestForProvider();
            model.UserId = User.Identity.Name;
            return View(model);
            
        }

        [HttpPost]
        public ActionResult Index2(RequestForProvider model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    RequestForProvider newreq = new RequestForProvider();
                    newreq.UserId= User.Identity.Name;
                    newreq.RequestedOn = @DateTime.Now;
                    newreq.ServiceName = model.ServiceName;
                    newreq.Activated=false;
                    newreq.Deleted=false;
                    db.RequestForProviders.Add(newreq);
                    db.SaveChanges();

                }
                return RedirectToAction("RequestForProvider");
            }
            return NotFound();
        }
        //  public ActionResult ServiceReq()
        //  {

        //  }

           public ActionResult DeleteUser1(string CityCode)
       {
           Cities pr=db.Citiess.Find(CityCode);
            if(pr==null)
            {
                return NotFound();
            }
            db.Remove(pr);
            db.SaveChanges();
            return RedirectToAction("Cities");
       }
    
     public ActionResult Dashboard()
        {
            return View(db.Userss.ToList());
        }
    }
}