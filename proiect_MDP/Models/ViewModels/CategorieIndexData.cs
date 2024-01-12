using proiect_MDP.Models;
using System.Security.Policy;

namespace proiect_MDP.Models.ViewModels
{
    public class CategorieIndexData
    {
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<Zbor> Zboruri { get; set; }
    }
}
