using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect_MDP.Data;
using proiect_MDP.Models;
using proiect_MDP.Models.ViewModels;

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
        public CompanieIndexData CompanieData { get; set; }
        public int CompanieID { get; set; }
        public int ZborID { get; set; }
        public async Task OnGetAsync(int? id, int? ZborID)
        {
            CompanieData = new CompanieIndexData();
            CompanieData.Companii = await _context.Companie
            .Include(i => i.Zboruri)
            .ThenInclude(c => c.Terminal)
            .OrderBy(i => i.FirstName)
            .ToListAsync();
            if (id != null)
            {
                CompanieID = id.Value;
                Companie companie = CompanieData.Companii
                .Where(i => i.ID == id.Value).Single();
                CompanieData.Zboruri = companie.Zboruri;
            }
        }
    }
}
