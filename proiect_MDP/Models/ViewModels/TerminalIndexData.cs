using System.Security.Policy;

namespace proiect_MDP.Models.ViewModels
{
    public class TerminalIndexData
    {
        public IEnumerable<Terminal> Terminale { get; set; }
        public IEnumerable<Zbor> Zboruri { get; set; }
    }
}
