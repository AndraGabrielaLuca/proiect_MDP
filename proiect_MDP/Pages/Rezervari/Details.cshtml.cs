using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect_MDP.Data;
using proiect_MDP.Models;

namespace proiect_MDP.Pages.Rezervari
{
    public class DetailsModel : PageModel
    {
        private readonly proiect_MDP.Data.proiect_MDPContext _context;

        public DetailsModel(proiect_MDP.Data.proiect_MDPContext context)
        {
            _context = context;
        }

      public Rezervare Rezervare { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rezervare == null)
            {
                return NotFound();
            }

            var rezervare = await _context.Rezervare.FirstOrDefaultAsync(m => m.ID == id);
            if (rezervare == null)
            {
                return NotFound();
            }
            else 
            {
                Rezervare = rezervare;
            }
            return Page();
        }
    }
}
