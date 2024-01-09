using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace proiect_MDP.Models
{
    public class Zbor
    {
        public int ID { get; set; }
        public string Destinatie { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }

        [Display(Name ="Data zborului")]
        [DataType(DataType.Date)]
        public DateTime ZborDate { get; set; }

        public int? CompanieID { get; set; }
        public Companie? Companie { get; set; }

        public int? TerminalID { get; set; }
        public Terminal? Terminal { get; set; }


        public ICollection<ZborCategorie>? ZborCategorii { get; set; }
    }
}
