using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace proiect_MDP.Models
{
    public class Bilet
    {
        public int ID { get; set; }
        public int? UtilizatorID { get; set; }
        public Utilizator? Utilizator { get; set; }
        public int? ZborID { get; set; }
        public Zbor? Zbor { get; set; }

        [Display(Name = "Data zborului")]
        [DataType(DataType.Date)]
        public DateTime PlecareDate { get; set; }
    }
}
