using DataLayer.Data;
using DesignStamp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Controllers
{
    //[Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        

        public AdminController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
          

        }

        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult GetAllUsers()
        {
            var users = _userManager.GetUsersInRoleAsync("user").Result;
            return View(users);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult> Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                if (model.Avatar != null)
                {
                    user.AvatarImage = new byte[(int)model.Avatar.Length];
                    await model.Avatar.OpenReadStream().ReadAsync(user.AvatarImage, 0, (int)model.Avatar.Length);

                }
                var result = await _userManager.CreateAsync(user, model.Password);


                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "user");
                    return RedirectToAction("GetAllUsers");
                }

                else
                {
                    AddErrorsFromResult(result);
                }


            }
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            return View(user);

        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("GetAllUsers");
                }
                else
                {
                    return View("Error", result.Errors);
                }
            }
            else
            {
                return View("Error", new string[] { "Пользователь не найден" });
            }
        }


        [Authorize(Roles = "admin,user")]
        public async Task<ActionResult> Edit(string id, string returnUrl)
        {
            ViewData["Url"] = returnUrl;
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            CreateModel create = new CreateModel { Id=user.Id , Email = user.Email };
            
            if (user != null)
            {
                return View(create);
            }
            else
            {
                return RedirectToAction("GetAllUsers");
            }
        }

        [Authorize(Roles = "admin,user")]
        [HttpPost]
        public async Task<ActionResult> Edit(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByIdAsync(model.Id);
                user.UserName = model.Email;
                user.Email = model.Email;
                if (model.Avatar != null)
                {
                    user.AvatarImage = new byte[(int)model.Avatar.Length];
                    await model.Avatar.OpenReadStream().ReadAsync(user.AvatarImage, 0, (int)model.Avatar.Length);

                }

                var result = await _userManager.UpdateAsync(user);
                //_context.SaveChanges();

                if (result.Succeeded)
                {
                   
                    return RedirectToAction("GetAllUsers");
                }
            }

            return View(model);



        }
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(" ", error.Description);
            }
        }




    }
}
