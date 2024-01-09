using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect_MDP.Data;
using proiect_MDP.Models;

namespace proiect_MDP.Pages.Utilizatori
{
    public class DeleteModel : PageModel
    {
        private readonly proiect_MDP.Data.proiect_MDPContext _context;

        public DeleteModel(proiect_MDP.Data.proiect_MDPContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Utilizator Utilizator { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Utilizator == null)
            {
                return NotFound();
            }

            var utilizator = await _context.Utilizator.FirstOrDefaultAsync(m => m.ID == id);

            if (utilizator == null)
            {
                return NotFound();
            }
            else 
            {
                Utilizator = utilizator;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Utilizator == null)
            {
                return NotFound();
            }
            var utilizator = await _context.Utilizator.FindAsync(id);

            if (utilizator != null)
            {
                Utilizator = utilizator;
                _context.Utilizator.Remove(Utilizator);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
