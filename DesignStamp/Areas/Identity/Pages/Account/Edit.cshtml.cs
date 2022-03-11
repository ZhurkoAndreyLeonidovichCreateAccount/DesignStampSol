using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DesignStamp.Areas.Identity.Pages.Account
{
    public class EditModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<EditModel> _logger;

        public EditModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<EditModel> logger)

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;

        }
        [BindProperty]
        public ApplicationUser User1 { get; set; }
        public async Task<IActionResult> OnGetAsync( string name)
        {
            //ReturnUrl = returnUrl;

            User1 =await _userManager.FindByNameAsync(name);
            return Page();
            
        }
    }
}
