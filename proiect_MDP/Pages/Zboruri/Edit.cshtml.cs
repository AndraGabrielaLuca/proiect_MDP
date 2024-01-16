using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proiect_MDP.Data;
using proiect_MDP.Models;

namespace proiect_MDP.Pages.Zboruri 
{
    [Authorize(Roles = "Admin")]
    public class EditModel : ZborCategoriiPageModel
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

            Zbor = await _context.Zbor
             .Include(b => b.Terminal)
             .Include(b => b.ZborCategorii).ThenInclude(b => b.Categorie)
             .AsNoTracking()
             .FirstOrDefaultAsync(m => m.ID == id);

            PopulateAssignedCategoryData(_context, Zbor);

            var zbor =  await _context.Zbor.FirstOrDefaultAsync(m => m.ID == id);
            if (zbor == null)
            {
                return NotFound();
            }
            Zbor = zbor;
            ViewData["TerminalID"] = new SelectList(_context.Set<Terminal>(), "ID", "TerminalName");
            ViewData["CompanieID"] = new SelectList(_context.Set<Companie>(), "ID", "FullName");
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int? id, string[]selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            //se va include Author conform cu sarcina de la lab 2
            var bookToUpdate = await _context.Zbor
            .Include(i => i.Terminal)
            .Include(i => i.ZborCategorii)
            .ThenInclude(i => i.Categorie)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (bookToUpdate == null)
            {
                return NotFound();
            }
            //se va modifica AuthorID conform cu sarcina de la lab 2
            if (await TryUpdateModelAsync<Zbor>(
            bookToUpdate,
            "Zbor",
            i => i.Destinatie, i => i.CompanieID,
            i => i.Pret, i => i.ZborDate, i => i.TerminalID))
            {
                UpdateBookCategories(_context, selectedCategories, bookToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care 
            //este editata 
            UpdateBookCategories(_context, selectedCategories, bookToUpdate);
            PopulateAssignedCategoryData(_context, bookToUpdate);
            return Page();
        }


    private bool ZborExists(int id)
        {
          return (_context.Zbor?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
