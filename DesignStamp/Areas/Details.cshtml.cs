using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer.Data;
using DataLayer.Entities;

namespace DesignStamp.Areas
{
    public class DetailsModel : PageModel
    {
        private readonly DataLayer.Data.ApplicationDbContext _context;

        public DetailsModel(DataLayer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Column Column { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Column = await _context.Columns.FirstOrDefaultAsync(m => m.Id == id);

            if (Column == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
