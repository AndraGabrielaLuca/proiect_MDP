using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect_MDP.Data;
using proiect_MDP.Models;

namespace proiect_MDP.Pages.Companii
{
    public class IndexModel : PageModel
    {
        private readonly proiect_MDP.Data.proiect_MDPContext _context;

        public IndexModel(proiect_MDP.Data.proiect_MDPContext context)
        {
            _context = context;
        }

        public IList<Companie> Companie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Companie != null)
            {
                Companie = await _context.Companie.ToListAsync();
            }
        }
    }
}
