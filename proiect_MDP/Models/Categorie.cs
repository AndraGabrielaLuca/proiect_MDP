using System.ComponentModel.DataAnnotations;

namespace proiect_MDP.Models
{
    public class Categorie
    {
        public int ID { get; set; }

        [Display(Name = "Clasa zbor")]
        public string CategorieName { get; set; }
        public ICollection<ZborCategorie>? ZborCategorii { get; set; }
    }
}
