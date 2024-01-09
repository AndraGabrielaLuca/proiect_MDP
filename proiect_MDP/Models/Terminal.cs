
using System.ComponentModel.DataAnnotations;

namespace proiect_MDP.Models
{
    public class Terminal
    {
        public int ID { get; set; }

        [Display(Name = "Nume terminal")]
        public string TerminalName { get; set; }
        public ICollection<Zbor>? Zboruri { get; set; }
    }
}
