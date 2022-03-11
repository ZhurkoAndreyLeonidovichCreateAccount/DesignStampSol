using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataLayer.Data;
using DataLayer.Entities;

namespace DesignStamp.Areas
{
    public class CreateModel : PageModel
    {
        private readonly DataLayer.Data.ApplicationDbContext _context;

        public CreateModel(DataLayer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Column Column { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Columns.Add(Column);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
