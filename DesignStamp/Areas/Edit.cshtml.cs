using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataLayer.Data;
using DataLayer.Entities;

namespace DesignStamp.Areas
{
    public class EditModel : PageModel
    {
        private readonly DataLayer.Data.ApplicationDbContext _context;

        public EditModel(DataLayer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Column).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColumnExists(Column.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ColumnExists(int id)
        {
            return _context.Columns.Any(e => e.Id == id);
        }
    }
}
