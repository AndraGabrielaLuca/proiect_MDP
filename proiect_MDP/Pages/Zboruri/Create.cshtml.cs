using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using proiect_MDP.Data;
using proiect_MDP.Models;

namespace proiect_MDP.Pages.Zboruri
{
    public class CreateModel : PageModel
    {
        private readonly proiect_MDP.Data.proiect_MDPContext _context;

        public CreateModel(proiect_MDP.Data.proiect_MDPContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["TerminalID"] = new SelectList(_context.Set<Terminal>(), "ID", "TerminalName");
            return Page();
        }

        [BindProperty]
        public Zbor Zbor { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Zbor == null || Zbor == null)
            {
                return Page();
            }

            _context.Zbor.Add(Zbor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
