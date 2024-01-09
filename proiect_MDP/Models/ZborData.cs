namespace proiect_MDP.Models
{
    public class ZborData
    {
        public IEnumerable<Zbor> Zboruri { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<ZborCategorie> ZborCategorii { get; set; } 
    }
}
