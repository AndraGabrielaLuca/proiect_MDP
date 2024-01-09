using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proiect_MDP.Models;

namespace proiect_MDP.Data
{
    public class proiect_MDPContext : DbContext
    {
        public proiect_MDPContext (DbContextOptions<proiect_MDPContext> options)
            : base(options)
        {
        }

        public DbSet<proiect_MDP.Models.Zbor> Zbor { get; set; } = default!;

        public DbSet<proiect_MDP.Models.Terminal>? Terminal { get; set; }

        public DbSet<proiect_MDP.Models.Companie>? Companie { get; set; }

        public DbSet<proiect_MDP.Models.Categorie>? Categorie { get; set; }

        public DbSet<proiect_MDP.Models.Utilizator>? Utilizator { get; set; }

        public DbSet<proiect_MDP.Models.Bilet>? Bilet { get; set; }

        public DbSet<proiect_MDP.Models.Rezervare>? Rezervare { get; set; }
    }
}
