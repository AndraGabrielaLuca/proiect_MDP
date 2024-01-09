namespace proiect_MDP.Models
{
    public class ZborCategorie
    {
        public int ID { get; set; }
        public int ZborID { get; set; }
        public Zbor Zbor { get; set; }
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }
    }
}
