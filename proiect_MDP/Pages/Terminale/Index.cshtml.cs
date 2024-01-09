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

namespace proiect_MDP.Pages.Terminale
{
    public class IndexModel : PageModel
    {
        private readonly proiect_MDP.Data.proiect_MDPContext _context;

        public IndexModel(proiect_MDP.Data.proiect_MDPContext context)
        {
            _context = context;
        }

        public IList<Terminal> Terminal { get;set; } = default!;
        public TerminalIndexData TerminalData { get; set; }
        public int TerminalID { get; set; }
        public int ZborID { get; set; }

        public async Task OnGetAsync(int? id, int? zborID)
        {
            TerminalData = new TerminalIndexData();
            TerminalData.Terminale = await _context.Terminal
            .Include(i => i.Zboruri)
            .ThenInclude(c => c.Companie)
            .OrderBy(i => i.TerminalName)
            .ToListAsync();
            if (id != null)
            {
                TerminalID = id.Value;
                Terminal terminal = TerminalData.Terminale
                .Where(i => i.ID == id.Value).Single();
                TerminalData.Zboruri = terminal.Zboruri;
            }
        }
    }
}
