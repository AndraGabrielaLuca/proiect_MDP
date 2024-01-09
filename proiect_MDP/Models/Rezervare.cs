using System.ComponentModel.DataAnnotations;

namespace proiect_MDP.Models
{
    public class Rezervare
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
