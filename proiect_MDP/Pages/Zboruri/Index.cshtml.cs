using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect_MDP.Data;
using proiect_MDP.Models;

namespace proiect_MDP.Pages.Zboruri
{
    public class IndexModel : PageModel
    {
        private readonly proiect_MDP.Data.proiect_MDPContext _context;

        public IndexModel(proiect_MDP.Data.proiect_MDPContext context)
        {
            _context = context;
        }
        public IList<Zbor> Zbor { get;set; } = default!;
        public ZborData ZborD { get; set; }
        public int ZborID { get; set; }
        public int CategorieID { get; set; }
        public async Task OnGetAsync(int? id, int? categorieID)
        {
            ZborD = new ZborData();

            ZborD.Zboruri = await _context.Zbor
            .Include(b => b.Terminal)
            .Include(b => b.ZborCategorii)
            .ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .OrderBy(b => b.Destinatie)
            .ToListAsync();
            if (id != null)
            {
                ZborID = id.Value;
                Zbor zbor = ZborD.Zboruri
                .Where(i => i.ID == id.Value).Single();
                ZborD.Categorii = zbor.ZborCategorii.Select(s => s.Categorie);
            }
        }
    }
}
