using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace proiect_MDP.Models
{
    public class Companie
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
