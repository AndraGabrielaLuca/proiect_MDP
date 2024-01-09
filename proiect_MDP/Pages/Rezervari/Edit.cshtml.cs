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

namespace proiect_MDP.Pages.Rezervari
{
    public class EditModel : PageModel
    {
        private readonly proiect_MDP.Data.proiect_MDPContext _context;

        public EditModel(proiect_MDP.Data.proiect_MDPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rezervare Rezervare { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rezervare == null)
            {
                return NotFound();
            }

            var rezervare =  await _context.Rezervare.FirstOrDefaultAsync(m => m.ID == id);
            if (rezervare == null)
            {
                return NotFound();
            }
            Rezervare = rezervare;
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

            _context.Attach(Rezervare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RezervareExists(Rezervare.ID))
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

        private bool RezervareExists(int id)
        {
          return (_context.Rezervare?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
