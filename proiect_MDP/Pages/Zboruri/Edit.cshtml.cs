using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proiect_MDP.Data;
using proiect_MDP.Models;

namespace proiect_MDP.Pages.Zboruri
{
    public class EditModel : PageModel
    {
        private readonly proiect_MDP.Data.proiect_MDPContext _context;

        public EditModel(proiect_MDP.Data.proiect_MDPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Zbor Zbor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Zbor == null)
            {
                return NotFound();
            }

            var zbor =  await _context.Zbor.FirstOrDefaultAsync(m => m.ID == id);
            if (zbor == null)
            {
                return NotFound();
            }
            Zbor = zbor;
            ViewData["TerminalID"] = new SelectList(_context.Set<Terminal>(), "ID", "TerminalName");

            return Page();
        }

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Zbor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZborExists(Zbor.ID))
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

        private bool ZborExists(int id)
        {
          return (_context.Zbor?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
