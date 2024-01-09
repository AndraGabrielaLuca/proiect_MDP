using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect_MDP.Data;
using proiect_MDP.Models;

namespace proiect_MDP.Pages.Bilete
{
    public class DetailsModel : PageModel
    {
        private readonly proiect_MDP.Data.proiect_MDPContext _context;

        public DetailsModel(proiect_MDP.Data.proiect_MDPContext context)
        {
            _context = context;
        }

      public Bilet Bilet { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bilet == null)
            {
                return NotFound();
            }

            var bilet = await _context.Bilet.FirstOrDefaultAsync(m => m.ID == id);
            if (bilet == null)
            {
                return NotFound();
            }
            else 
            {
                Bilet = bilet;
            }
            return Page();
        }
    }
}
