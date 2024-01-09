using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proiect_MDP.Data;
using proiect_MDP.Models;

namespace proiect_MDP.Pages.Companii
{
    public class EditModel : PageModel
    {
        private readonly proiect_MDP.Data.proiect_MDPContext _context;

        public EditModel(proiect_MDP.Data.proiect_MDPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Companie Companie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Companie == null)
            {
                return NotFound();
            }

            var companie =  await _context.Companie.FirstOrDefaultAsync(m => m.ID == id);
            if (companie == null)
            {
                return NotFound();
            }
            Companie = companie;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Companie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanieExists(Companie.ID))
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

        private bool CompanieExists(int id)
        {
          return (_context.Companie?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
