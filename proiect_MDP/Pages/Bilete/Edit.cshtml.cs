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

namespace proiect_MDP.Pages.Bilete
{
    public class EditModel : PageModel
    {
        private readonly proiect_MDP.Data.proiect_MDPContext _context;

        public EditModel(proiect_MDP.Data.proiect_MDPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bilet Bilet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bilet == null)
            {
                return NotFound();
            }

            var bilet =  await _context.Bilet.FirstOrDefaultAsync(m => m.ID == id);
            if (bilet == null)
            {
                return NotFound();
            }
            Bilet = bilet;
           ViewData["UtilizatorID"] = new SelectList(_context.Utilizator, "ID", "ID");
           ViewData["ZborID"] = new SelectList(_context.Zbor, "ID", "ID");
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

            _context.Attach(Bilet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BiletExists(Bilet.ID))
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

        private bool BiletExists(int id)
        {
          return (_context.Bilet?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
