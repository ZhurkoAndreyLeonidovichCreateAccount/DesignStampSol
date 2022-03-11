using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DesignStamp.Areas.Identity.Pages.Account
{
    public class AllAcountsModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;

        public AllAcountsModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger)

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;

        }

        public IList<ApplicationUser> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _userManager.GetUsersInRoleAsync("user");
        }
    }
}
