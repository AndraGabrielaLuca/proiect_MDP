using System.Security.Policy;

namespace proiect_MDP.Models.ViewModels
{
    public class CompanieIndexData
    {
        public IEnumerable<Companie> Companii { get; set; }
        public IEnumerable<Zbor> Zboruri { get; set; }
    }
}
