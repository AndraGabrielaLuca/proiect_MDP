using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using proiect_MDP.Data;
using proiect_MDP.Models;


namespace proiect_MDP.Pages.Zboruri
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : ZborCategoriiPageModel
    {
        private readonly proiect_MDP.Data.proiect_MDPContext _context;

        public CreateModel(proiect_MDP.Data.proiect_MDPContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["TerminalID"] = new SelectList(_context.Set<Terminal>(), "ID", "TerminalName");
            ViewData["CompanieID"] = new SelectList(_context.Set<Companie>(), "ID", "FullName");
            var zbor = new Zbor();
            zbor.ZborCategorii = new List<ZborCategorie>();
            PopulateAssignedCategoryData(_context, zbor);

            return Page();
        }

        [BindProperty]
        public Zbor Zbor { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newZbor = new Zbor();
            if (selectedCategories != null)
            {
                newZbor.ZborCategorii = new List<ZborCategorie>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new ZborCategorie
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newZbor.ZborCategorii.Add(catToAdd);
                }
            }
            Zbor.ZborCategorii = newZbor.ZborCategorii;
            _context.Zbor.Add(Zbor);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
