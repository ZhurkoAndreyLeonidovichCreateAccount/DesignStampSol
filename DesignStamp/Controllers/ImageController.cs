using DataLayer.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Controllers
{
    [Authorize]
    public class ImageController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        IWebHostEnvironment _env;
        public ImageController(UserManager<ApplicationUser>
        userManager, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _env = env;
        }
        public async Task<FileResult> GetAvatar(string name)
        {

            ApplicationUser user;
            if(name==null)
             user = await _userManager.GetUserAsync(User);
            else
                user = await _userManager.FindByEmailAsync(name);

            if (user?.AvatarImage != null)
                return File(user.AvatarImage, "image/...");
            else
            {
                var avatarPath = "/images/avatar.jpg";
                return File(_env.WebRootFileProvider
                .GetFileInfo(avatarPath)
                .CreateReadStream(), "Image/...");
            }
        }

        public async Task<FileResult> GetPicture()
        {
           
            
               var user = await _userManager.GetUserAsync(User);
                    
            
            if (user?.AvatarImage != null)
                return File(user.AvatarImage, "image/...");
            else
            {
                var avatarPath = "/images/avatar.jpg";
                return File(_env.WebRootFileProvider
                .GetFileInfo(avatarPath)
                .CreateReadStream(), "Image/...");
            }
        }
    }
}
